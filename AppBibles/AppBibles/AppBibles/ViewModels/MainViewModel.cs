﻿namespace AppBibles.ViewModels
{
    using System.Collections.ObjectModel;
    using Helpers;
    using Models;
    using Domain;

    public class MainViewModel : BaseViewModel
    {
        #region Attibrutes
        private UserLocal user;
        #endregion

        #region ViewModels
        public LoginViewModel Login
        {
            get;
            set;
        }

        public BiblesViewModel Bibles
        {
            get;
            set;
        }
        public BibleViewModel Bible
        {
            get;
            set;
        }

        public BookViewModel Book
        {
            get;
            set;
        }

        public RegisterViewModel Register
        {
            get;
            set;
        }

        public MyProfileViewModel MyProfile
        {
            get;
            set;
        }

        public SearchByDatingViewModel SearchByDating
        {
            get;
            set;
        }

        public SearchByKeywordViewModel SearchByKeyword
        {
            get;
            set;
        }

        public ChangePasswordViewModel ChangePassword
        {
            get;
            set;
        }
        #endregion

        #region Properties
        public string SelectedModule
        {
            get;
            set;
        }

        public ObservableCollection<MenuItemViewModel> Menus
        {
            get;
            set;
        }

        public TokenResponse Token
        {
            get;
            set;
        }

        public UserLocal User
        {
            get
            {
                return this.user;
            }
            set
            {
                SetValue(ref this.user, value);
            }
        }
        #endregion

        #region Constructors
        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
            this.LoadMenu();
        }
        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
        #endregion

        #region Methods
        private void LoadMenu()
        {
            this.Menus = new ObservableCollection<MenuItemViewModel>();

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_settings",
                PageName = "MyProfilePage",
                Title = Languages.MyProfile,
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart",
                PageName = "SearchByDatingPage",
                Title = Languages.SearchByDating,
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_insert_chart",
                PageName = "SearchByKeywordPage",
                Title = Languages.SearchByKeyword,
            });

            this.Menus.Add(new MenuItemViewModel
            {
                Icon = "ic_exit_to_app",
                PageName = "LoginPage",
                Title = Languages.LogOut,
            });
        }
        #endregion
    }
}
