using MauiApp1.Helpers;
using MauiApp1.Pages;
using MauiApp1.Services;
using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;
	MainPageViewModel model;
	INavigationService _navigationService;

    public MainPage(INavigationService navigationService)
	{
		InitializeComponent();
		BindingContext = model = new MainPageViewModel();
		Title = "Test MAUI";
		_navigationService = navigationService;

    }

	protected override void OnAppearing()
	{
		base.OnAppearing();

        if (string.IsNullOrEmpty(SettingsHelper.Current().SettingsService.AuthAccessToken))
        {
            _navigationService.NavigateToAsync($"/{nameof(LoginPage)}");
        }
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

