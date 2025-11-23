namespace ArchiDesignPatterns.Mobile.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public void AddServices(IConfiguration configuration)
        {
            var apiKey = configuration["OpenAI:ApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new InvalidOperationException("La clé API OpenAI n'est pas configurée.");
            }

            // Configuration de HttpClient avec IHttpClientFactory
            services.AddHttpClient("OpenAI", client =>
            {
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");
            }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            });

            // Configuration de Semantic Kernel
            services.AddSingleton(sp =>
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
            services.AddSingleton(sp =>
            {
                var kernel = sp.GetRequiredService<Kernel>();
                return kernel.GetRequiredService<IChatCompletionService>();
            });

            // Enregistrement des services métiers
            services.AddSingleton<IQuizService, QuizService>();

            // Enregistrement des pages et ViewModels
            services.AddPageAndViewModelServices();
        }

        public void AddPageAndViewModelServices()
        {
            // Main pages - Singleton to prevent disposal during navigation
            services.AddSingleton<MainPage>();
            services.AddSingleton<ArchitecturesPage>();
            services.AddSingleton<QuizPage>();

            // Design Patterns Page - Singleton with ViewModel
            services.AddSingletonWithShellRoute<DesignPatternsPage, DesignPatternsViewModel>(nameof(DesignPatternsPage));

            // Pattern Pages - Registered as Singleton to prevent disposal on back navigation
            services.AddSingleton<SingletonPatternPage>();
            services.AddSingletonWithShellRoute<FactoryPatternPage, FactoryPatternViewModel>(nameof(FactoryPatternPage));
            services.AddSingletonWithShellRoute<AbstractFactoryPatternPage, AbstractFactoryPatternViewModel>(nameof(AbstractFactoryPatternPage));

            // Uncomment these as you implement their ViewModels
            services.AddSingletonWithShellRoute<BuilderPatternPage, BuilderPatternViewModel>(nameof(BuilderPatternPage));
            services.AddSingletonWithShellRoute<PrototypePatternPage, PrototypePatternViewModel>(nameof(PrototypePatternPage));
            services.AddSingletonWithShellRoute<AdapterPatternPage, AdapterPatternViewModel>(nameof(AdapterPatternPage));
            services.AddSingletonWithShellRoute<BridgePatternPage, BridgePatternViewModel>(nameof(BridgePatternPage));
            services.AddSingletonWithShellRoute<CompositePatternPage, CompositePatternViewModel>(nameof(CompositePatternPage));
            services.AddSingletonWithShellRoute<DecoratorPatternPage, DecoratorPatternViewModel>(nameof(DecoratorPatternPage));
            services.AddSingletonWithShellRoute<FacadePatternPage, FacadePatternViewModel>(nameof(FacadePatternPage));
            services.AddSingletonWithShellRoute<FlyweightPatternPage, FlyweightPatternViewModel>(nameof(FlyweightPatternPage));
            services.AddSingletonWithShellRoute<ProxyPatternPage, ProxyPatternViewModel>(nameof(ProxyPatternPage));
            services.AddSingletonWithShellRoute<ChainOfResponsibilityPatternPage, ChainOfResponsibilityPatternViewModel>(nameof(ChainOfResponsibilityPatternPage));
            services.AddSingletonWithShellRoute<CommandPatternPage, CommandPatternViewModel>(nameof(CommandPatternPage));
            services.AddSingletonWithShellRoute<InterpreterPatternPage, InterpreterPatternViewModel>(nameof(InterpreterPatternPage));
            services.AddSingletonWithShellRoute<IteratorPatternPage, IteratorPatternViewModel>(nameof(IteratorPatternPage));
            services.AddSingletonWithShellRoute<MediatorPatternPage, MediatorPatternViewModel>(nameof(MediatorPatternPage));
            services.AddSingletonWithShellRoute<MementoPatternPage, MementoPatternViewModel>(nameof(MementoPatternPage));
            services.AddSingletonWithShellRoute<ObserverPatternPage, ObserverPatternViewModel>(nameof(ObserverPatternPage));
            services.AddSingletonWithShellRoute<StatePatternPage, StatePatternViewModel>(nameof(StatePatternPage));
            services.AddSingletonWithShellRoute<StrategyPatternPage, StrategyPatternViewModel>(nameof(StrategyPatternPage));
            services.AddSingletonWithShellRoute<TemplateMethodPatternPage, TemplateMethodPatternViewModel>(nameof(TemplateMethodPatternPage));
            services.AddSingletonWithShellRoute<VisitorPatternPage, VisitorPatternViewModel>(nameof(VisitorPatternPage));

            // Architecture Pages
            services.AddSingletonWithShellRoute<MVCArchitecturePage, MVCArchitectureViewModel>(nameof(MVCArchitecturePage));
            services.AddSingletonWithShellRoute<MVVMArchitecturePage, MVVMArchitectureViewModel>(nameof(MVVMArchitecturePage));
            services.AddSingletonWithShellRoute<CleanArchitecturePage, CleanArchitectureViewModel>(nameof(CleanArchitecturePage));
            services.AddSingletonWithShellRoute<LayeredArchitecturePage, LayeredArchitectureViewModel>(nameof(LayeredArchitecturePage));
            services.AddSingletonWithShellRoute<HexagonalArchitecturePage, HexagonalArchitectureViewModel>(nameof(HexagonalArchitecturePage));
            services.AddSingletonWithShellRoute<MicroservicesArchitecturePage, MicroservicesArchitectureViewModel>(nameof(MicroservicesArchitecturePage));
            services.AddSingletonWithShellRoute<EventDrivenArchitecturePage, EventDrivenArchitectureViewModel>(nameof(EventDrivenArchitecturePage));
            services.AddSingletonWithShellRoute<CQRSArchitecturePage, CQRSArchitectureViewModel>(nameof(CQRSArchitecturePage));
            services.AddSingletonWithShellRoute<OnionArchitecturePage, OnionArchitectureViewModel>(nameof(OnionArchitecturePage));
            services.AddSingletonWithShellRoute<DDDArchitecturePage, DDDArchitectureViewModel>(nameof(DDDArchitecturePage));
        }
    }
}