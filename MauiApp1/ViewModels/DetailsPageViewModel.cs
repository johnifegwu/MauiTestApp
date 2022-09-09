using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public class DetailsPageViewModel : BaseViewModel
    {

        IConnectivity connectivity;

        public Command CheckConnCommand { get; private set; }

        public DetailsPageViewModel()
        {
            connectivity = Connectivity.Current;
            CheckConnCommand = new Command(async () => await CheckConnectivity());
        }

        private async Task CheckConnectivity()
        {
            var hasInternet = connectivity?.NetworkAccess == NetworkAccess.Internet;
            var ans = hasInternet ? "YES!" : "NO";
            await App.Current.MainPage.DisplayAlert("Has Internet", ans, "Cancel");
        }
    }
}
