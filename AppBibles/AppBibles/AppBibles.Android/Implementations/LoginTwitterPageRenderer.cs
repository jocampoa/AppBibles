[assembly: Xamarin.Forms.ExportRenderer(
    typeof(AppBibles.Views.LoginTwitterPage),
    typeof(AppBibles.Droid.Implementations.LoginTwitterPageRenderer))]

namespace AppBibles.Droid.Implementations
{
    using System;
    using System.Threading.Tasks;
    using Android.App;
    using Models;
    using Service;
    using Xamarin.Auth;
    using Xamarin.Forms.Platform.Android;

    public class LoginTwitterPageRenderer : PageRenderer
    {
        public LoginTwitterPageRenderer()
        {
            var activity = this.Context as Activity;

            var authTwitter = new OAuth1Authenticator(
                consumerKey: "pHX7RNbyU0qySDfM3XGVXAo5Z",
                consumerSecret: "s2k3jVdbVMGBEUEVsvJ1Hzgc0K7RpkUoabESrob5VNDECJy2zj",
                requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
                authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
                accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
                callbackUrl: new Uri("http://www.devenvexe.com"));

            authTwitter.Completed += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    var accessToken = eventArgs.Account.Properties["access_token"].ToString();
                    var profile = await GetTwitterProfileAsync(accessToken);
                    await App.NavigateToProfile(profile);
                }
                else
                {
                    App.HideLoginView();
                }
            };

            activity.StartActivity(authTwitter.GetUI(activity));
        }

        private async Task<FacebookResponse> GetTwitterProfileAsync(string accessToken)
        {
            var requestUrl = "https://api.twitter.com/oauth/request_token," +
                "age_range,devices,email,gender,is_verified,birthday,languages,work,website,religion," +
                "location,locale,link,first_name,last_name,hometown&access_token=" + accessToken;
            var apiService = new ApiService();
            return await apiService.GetFacebook(requestUrl);
        }
    }
}