﻿namespace AppBibles.Helpers
{
    using Xamarin.Forms;
    using Interfaces;
    using Resources;

    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale(ci);
        }

        public static string Accept
        {
            get { return Resource.Accept; }
        }

        public static string EmailValidation
        {
            get { return Resource.EmailValidation; }
        }

        public static string Error
        {
            get { return Resource.Error; }
        }

        public static string Rememberme
        {
            get { return Resource.Rememberme; }
        }

        public static string EmailPlaceHolder
        {
            get { return Resource.EmailPlaceHolder; }
        }

        public static string PasswordPlaceHolder
        {
            get { return Resource.PasswordPlaceHolder; }
        }

        public static string Forgot
        {
            get { return Resource.Forgot; }
        }

        public static string EMail
        {
            get { return Resource.EMail; }
        }

        public static string Password
        {
            get { return Resource.Password; }
        }

        public static string Login
        {
            get { return Resource.Login; }
        }

        public static string Register
        {
            get { return Resource.Register; }
        }

        public static string PasswordValidation
        {
            get { return Resource.PasswordValidation; }
        }

        public static string Incorrect
        {
            get { return Resource.Incorrect; }
        }
    }
}
