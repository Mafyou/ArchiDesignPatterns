namespace ArchiDesignPatterns.Mobile.ViewModels;

public partial class DesignPatternsViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Design Patterns";

    [ObservableProperty]
    private ObservableCollection<DesignPatternInfo> _patterns = new(
            new[]
            {
                new DesignPatternInfo("Singleton",Strings.Singleton_Description, "Creational"),
                new DesignPatternInfo("Factory", Strings.Factory_Description, "Creational"),
                new DesignPatternInfo("Abstract Factory", Strings.AbstractFactory_Description, "Creational"),
                new DesignPatternInfo("Builder", Strings.Builder_Description, "Creational"),
                new DesignPatternInfo("Prototype", Strings.Prototype_Description, "Creational"),
                new DesignPatternInfo("Adapter", Strings.Adapter_Description, "Structural"),
                new DesignPatternInfo("Bridge", Strings.Bridge_Description, "Structural"),
                new DesignPatternInfo("Composite", Strings.Composite_Description, "Structural"),
                new DesignPatternInfo("Decorator", Strings.Decorator_Description, "Structural"),
                new DesignPatternInfo("Facade", Strings.Facade_Description, "Structural"),
                new DesignPatternInfo("Flyweight", Strings.Flyweight_Description, "Structural"),
                new DesignPatternInfo("Proxy", Strings.Proxy_Description, "Structural"),
                new DesignPatternInfo("Chain Of Responsibility", Strings.ChainOfResponsibility_Description, "Behavioral"),
                new DesignPatternInfo("Command", Strings.Command_Description, "Behavioral"),
                new DesignPatternInfo("Interpreter", Strings.Interpreter_Description, "Behavioral"),
                new DesignPatternInfo("Iterator", Strings.Iterator_Description, "Behavioral"),
                new DesignPatternInfo("Mediator", Strings.Mediator_Description, "Behavioral"),
                new DesignPatternInfo("Memento", Strings.Memento_Description, "Behavioral"),
                new DesignPatternInfo("Observer", Strings.Observer_Description, "Behavioral"),
                new DesignPatternInfo("State", Strings.State_Description, "Behavioral"),
                new DesignPatternInfo("Strategy", Strings.Strategy_Description, "Behavioral"),
                new DesignPatternInfo("Template Method", Strings.TemplateMethod_Description, "Behavioral"),
                new DesignPatternInfo("Visitor", Strings.Visitor_Description, "Behavioral"),
            });

    [ObservableProperty]
    private ObservableCollection<DesignPatternInfo> _filteredPatterns = [];

    [ObservableProperty]
    private string? _searchTerm = string.Empty;

    [ObservableProperty]
    private DesignPatternInfo? _selectedPattern;

    public DesignPatternsViewModel()
    {
        FilteredPatterns.Clear();
        foreach (var p in Patterns)
            FilteredPatterns.Add(p);
    }

    partial void OnSearchTermChanged(string? value)
    {
        if (value is null) return;
        var term = value?.Trim().ToLowerInvariant();
        FilteredPatterns.Clear();
        foreach (var p in Patterns.Where(p => string.IsNullOrEmpty(term) || p.Name.ToLowerInvariant().Contains(term!)))
            FilteredPatterns.Add(p);
    }

    [RelayCommand]
    private async Task OnSelectedPatternChangedAsync(DesignPatternInfo? value)
    {
        if (value is null) return;

        var route = value.Name
            .Replace(" ", string.Empty)
            .Replace("-", string.Empty)
            .Replace(".", string.Empty)
            .Replace("'", string.Empty)
            + "PatternPage";

        var pageType = Type.GetType($"ArchiDesignPatterns.Mobile.Pages.DesignPatterns.{route}");
        if (pageType is null) return;

        Page? page = null;

        // Try to resolve from DI
        if (App.Current.Handler?.MauiContext?.Services is IServiceProvider services)
        {
            page = services.GetService(pageType) as Page;
        }

        // Fallback to Activator if not registered in DI
        page ??= Activator.CreateInstance(pageType) as Page;

        if (page is null) return;

        // Push the details page onto the navigation stack for deep navigation
        if (Shell.Current.Navigation is not null)
        {
            await Shell.Current.Navigation.PushAsync(page);
        }
        else
        {
            // fallback to Shell GoToAsync if Navigation is not available
            await Shell.Current.GoToAsync($"///{route}");
        }

        SelectedPattern = null;
    }
}