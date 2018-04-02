[assembly: Xamarin.Forms.ExportRenderer(
    typeof(AppBibles.Views.LoginTwitterPage),
    typeof(AppBibles.iOS.Implementations.LoginTwitterPageRenderer))]

namespace AppBibles.iOS.Implementations
{
    using System;
    using System.Threading.Tasks;
    using Models;
    using Service;
    using Xamarin.Auth;
    using Xamarin.Forms.Platform.iOS;

    public class LoginTwitterPageRenderer : PageRenderer
    {
        bool done = false;

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            if (done)
            {
                return;
            }

            var authTwitter = new OAuth1Authenticator(
                consumerKey: "pHX7RNbyU0qySDfM3XGVXAo5Z",
                consumerSecret: "s2k3jVdbVMGBEUEVsvJ1Hzgc0K7RpkUoabESrob5VNDECJy2zj",
                requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
                authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
                accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
                callbackUrl: new Uri("http://www.devenvexe.com"));

            authTwitter.Completed += async (sender, eventArgs) =>
            {
                DismissViewController(true, null);
                App.HideLoginView();

                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var profile = await GetFacebookProfileAsync(accessToken);
                    await App.NavigateToProfile(profile);
                }
                else
                {
                    await App.NavigateToProfile(null);
                }
            };

            done = true;
            PresentViewController(authTwitter.GetUI(), true, null);
        }

        private async Task<FacebookResponse> GetFacebookProfileAsync(string accessToken)
        {
            var apiService = new ApiService();
            return await apiService.GetFacebook(accessToken);
        }
    }
}