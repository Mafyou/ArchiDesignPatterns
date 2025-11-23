namespace ArchiDesignPatterns.Mobile.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddPageAndViewModelServices(this IServiceCollection services)
    {
        // Main TabBar pages - Singleton to prevent disposal during navigation
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

    /// <summary>
    /// Registers a page and its viewmodel as singleton services and registers a Shell route.
    /// Singleton is used to prevent ObjectDisposedException during Shell navigation lifecycle.
    /// </summary>
    public static IServiceCollection AddSingletonWithShellRoute<TPage, TViewModel>(
        this IServiceCollection services,
        string route)
        where TPage : ContentPage
        where TViewModel : class
    {
        services.AddSingleton<TViewModel>();
        services.AddSingleton<TPage>();

        // Register the route with Shell
        Routing.RegisterRoute(route, typeof(TPage));

        return services;
    }
}
