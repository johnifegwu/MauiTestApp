using MauiApp1.ViewModels;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
	int count = 0;
	MainPageViewModel model;

    public MainPage()
	{
		InitializeComponent();
		BindingContext = model = new MainPageViewModel();
		Title = "Test MAUI";
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

