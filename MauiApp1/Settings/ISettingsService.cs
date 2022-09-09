using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Settings
{
    public interface ISettingsService
    {
        string AuthAccessToken { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string CoreURL { get; set; }
        string ApiURL { get; set; }
        string Tenant { get; set; }
    }
}
