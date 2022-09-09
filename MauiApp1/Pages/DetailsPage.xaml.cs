using MauiApp1.ViewModels;

namespace MauiApp1.Pages;

public partial class DetailsPage : ContentPage
{
	DetailsPageViewModel model;

	public DetailsPage()
	{
		InitializeComponent();
		BindingContext = model = new DetailsPageViewModel();

	}
}