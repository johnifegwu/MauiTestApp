using MauiApp1.Services;
using MauiApp1.Settings;

namespace MauiApp1;

public partial class App : Application
{
    private readonly ISettingsService _settingsService;
    private readonly INavigationService _navigationService;


    public App(ISettingsService settingsService, INavigationService navigationService)
	{
        _settingsService = settingsService;
        _navigationService = navigationService;

        InitializeComponent();

        MainPage = new AppShell(navigationService);
    }
}
