namespace ArchiDesignPatterns.Mobile.ViewModels;

public partial class DesignPatternsViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Design Patterns";

    [ObservableProperty]
    private ObservableCollection<DesignPatternInfo> _patterns = new(
        new[]
        {
            new DesignPatternInfo("Singleton","Ensures a class has only one instance.","Creational"),
            new DesignPatternInfo("Factory","Creates objects without exposing creation logic.","Creational"),
            new DesignPatternInfo("Abstract Factory","Creates families of related objects.","Creational"),
            new DesignPatternInfo("Builder","Builds complex objects step by step.","Creational"),
            new DesignPatternInfo("Prototype","Creates objects by cloning.","Creational"),
            new DesignPatternInfo("Adapter","Converts the interface of a class.","Structural"),
            new DesignPatternInfo("Bridge","Separates abstraction and implementation.","Structural"),
            new DesignPatternInfo("Composite","Tree structure of objects.","Structural"),
            new DesignPatternInfo("Decorator","Adds functionality dynamically.","Structural"),
            new DesignPatternInfo("Facade","Simplified interface.","Structural"),
            new DesignPatternInfo("Flyweight","Shares objects for efficiency.","Structural"),
            new DesignPatternInfo("Proxy","Provides a substitute or placeholder.","Structural"),
            new DesignPatternInfo("Chain of Responsibility","Chain of processing handlers.","Behavioral"),
            new DesignPatternInfo("Command","Encapsulates a request as an object.","Behavioral"),
            new DesignPatternInfo("Interpreter","Interprets a grammar or language.","Behavioral"),
            new DesignPatternInfo("Iterator","Iterates through a collection.","Behavioral"),
            new DesignPatternInfo("Mediator","Centralized communication.","Behavioral"),
            new DesignPatternInfo("Memento","Saves and restores object state.","Behavioral"),
            new DesignPatternInfo("Observer","Notifies observers of changes.","Behavioral"),
            new DesignPatternInfo("State","Behavior changes with state.","Behavioral"),
            new DesignPatternInfo("Strategy","Interchangeable algorithms.","Behavioral"),
            new DesignPatternInfo("Template Method","Defines algorithm skeleton.","Behavioral"),
            new DesignPatternInfo("Visitor","Separates algorithm from structure.","Behavioral"),
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