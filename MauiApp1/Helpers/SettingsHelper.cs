using MauiApp1.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Helpers
{
    public class SettingsHelper
    {

        private static SettingsHelper instance;

        public static SettingsHelper Current()
        {
            if (instance == null)
            {
                instance = new SettingsHelper();
            }

            return new SettingsHelper();
        }

        private static SettingsService settingsService;

        public SettingsService SettingsService
        {
            get 
            { 
                if(settingsService == null)
                {
                    settingsService = new SettingsService();
                }
                return settingsService; 
            }
        }
    }
}
