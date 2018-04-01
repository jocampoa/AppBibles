namespace AppBibles.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Views;
    using Xamarin.Forms;
    using Helpers;

    public class MenuItemViewModel
    {
        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(Navigate);
            }
        }

        private void Navigate()
        {
            App.Master.IsPresented = false;

            if (this.PageName == "LoginPage")
            {
                Settings.IsRemembered = "false";
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = null;
                mainViewModel.User = null;
                Application.Current.MainPage = new NavigationPage(
                    new LoginPage());
            }
            else if (this.PageName == "MyProfilePage")
            {
                MainViewModel.GetInstance().MyProfile = new MyProfileViewModel();
                App.Navigator.PushAsync(new MyProfilePage());
            }
            else if (this.PageName == "SearchByDatingPage")
            {
                MainViewModel.GetInstance().SearchByDating = new SearchByDatingViewModel();
                App.Navigator.PushAsync(new SearchByDatingPage());
            }
            else if (this.PageName == "SearchByKeywordPage")
            {
                MainViewModel.GetInstance().SearchByKeyword = new SearchByKeywordViewModel();
                App.Navigator.PushAsync(new SearchByKeywordPage());
            }
        }
        #endregion
    }
}
