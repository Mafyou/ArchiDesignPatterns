namespace ArchiDesignPatterns.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.Configuration.AddConfiguration(AppSettingsConfigurationHelper.AddConfiguration());

        // Configuration de l'application MAUI
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddServices(builder.Configuration);
#if DEBUG
        builder.Logging.AddDebug();
#endif
        var app = builder.Build();
        return app;
    }
}