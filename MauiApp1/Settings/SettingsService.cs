using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Settings
{
    public class SettingsService : ISettingsService
    {
        #region Setting Constants

        private const string KeyAccessToken = "access_token";

        private const string KeyUsername = "user_name";

        private const string KeyPassword = "password";

        private const string KeyCoreURL = "core_url";

        private const string KeyApiURL = "api_url";

        private const string KeyTenant = "tenant";

        #endregion

        #region Settings Properties

        public string AuthAccessToken 
        { 
            get => Preferences.Get(KeyAccessToken, $"{String.Empty}"); 
            set => Preferences.Set(KeyAccessToken, value); 
        }
        public string Username 
        {
            get => Preferences.Get(KeyUsername, String.Empty);
            set => Preferences.Set(KeyUsername, value);
        }
        public string Password 
        {
            get => Preferences.Get(KeyPassword, String.Empty);
            set => Preferences.Set(KeyPassword, value);
        }
        public string CoreURL 
        {
            get => Preferences.Get(KeyCoreURL, String.Empty);
            set => Preferences.Set(KeyCoreURL, value);
        }
        public string ApiURL 
        {
            get => Preferences.Get(KeyApiURL, String.Empty);
            set => Preferences.Set(KeyApiURL, value);
        }
        public string Tenant 
        {
            get => Preferences.Get(KeyTenant, String.Empty);
            set => Preferences.Set(KeyTenant, value);
        }

        #endregion

    }
}
