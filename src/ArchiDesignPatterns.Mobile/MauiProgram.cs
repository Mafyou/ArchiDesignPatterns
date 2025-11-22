using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ArchiDesignPatterns.Mobile;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        var assembly = Assembly.GetExecutingAssembly();
        var appSettings = $"{assembly.GetName().Name}.appsettings.json";
        using var stream = assembly.GetManifestResourceStream(appSettings);
        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .Build();
        builder.Configuration.AddConfiguration(config);

        // Configuration de l'application MAUI
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        var apiKey = builder.Configuration["OpenAI:ApiKey"];
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("La clé API OpenAI n'est pas configurée.");
        }

        // Configuration de HttpClient avec IHttpClientFactory
        builder.Services.AddHttpClient("OpenAI", client =>
        {
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
        }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        });

        // Configuration de Semantic Kernel
        builder.Services.AddSingleton(sp =>
        {
            var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
            var httpClient = httpClientFactory.CreateClient("OpenAI");

            var kernelBuilder = Kernel.CreateBuilder();
            kernelBuilder.AddOpenAIChatCompletion(
                modelId: "gpt-4o-mini",
                apiKey: apiKey,
                httpClient: httpClient);

            return kernelBuilder.Build();
        });

        // Enregistrement de IChatCompletionService
        builder.Services.AddSingleton(sp =>
        {
            var kernel = sp.GetRequiredService<Kernel>();
            return kernel.GetRequiredService<IChatCompletionService>();
        });

        // Enregistrement des services métiers
        builder.Services.AddSingleton<IQuizService, QuizService>();

        // Enregistrement des pages et ViewModels
        builder.Services.AddPageAndViewModelServices();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        var app = builder.Build();
        // ServiceLocator.Initialize(app.Services); // Initialiser le ServiceLocator
        return app;
    }
}