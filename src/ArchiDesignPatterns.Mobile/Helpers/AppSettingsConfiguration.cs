namespace ArchiDesignPatterns.Mobile.Helpers;

internal static class AppSettingsConfigurationHelper
{
    public static IConfigurationRoot AddConfiguration()
    {
        var assembly = Assembly.GetExecutingAssembly();
        var appSettings = $"{assembly.GetName().Name}.appsettings.json";
        using var stream = assembly.GetManifestResourceStream(appSettings);
        return new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();

    }
}