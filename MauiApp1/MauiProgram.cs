
using CommunityToolkit.Maui;
using MauiApp1.Pages;
using MauiApp1.Services;
using MauiApp1.Settings;
using MauiApp1.ViewModels;

namespace MauiApp1;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureEffects(
               effects =>
               {
               })
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Font_Awesome_5_Free-Regular-400.otf", "FontAwesome-Regular");
                fonts.AddFont("Font_Awesome_5_Free-Solid-900.otf", "FontAwesome-Solid");
                fonts.AddFont("Montserrat-Bold.ttf", "Montserrat-Bold");
                fonts.AddFont("Montserrat-Regular.ttf", "Montserrat-Regular");
                fonts.AddFont("SourceSansPro-Regular.ttf", "SourceSansPro-Regular");
                fonts.AddFont("SourceSansPro-Solid.ttf", "SourceSansPro-Solid");
            })
            .RegisterAppServices()
            .RegisterViewModels()
            .RegisterViews();

		return builder.Build();
	}

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<ISettingsService, SettingsService>();
        mauiAppBuilder.Services.AddSingleton<INavigationService, MauiNavigationService>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainPageViewModel>();
        mauiAppBuilder.Services.AddSingleton<DetailsPageViewModel>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<MainPage>();
        mauiAppBuilder.Services.AddTransient<DetailsPage>();

        return mauiAppBuilder;
    }
}
