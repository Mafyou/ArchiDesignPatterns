namespace ArchiDesignPatterns.Mobile.ViewModels;

public partial class ArchitecturesViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Architectures";

    [ObservableProperty]
    private ObservableCollection<ArchitectureInfo> _architectures = new(
        new[]
        {
            new ArchitectureInfo("MVC","Model-View-Controller pattern.","Architectural Pattern"),
            new ArchitectureInfo("MVVM","Model-View-ViewModel pattern.","Architectural Pattern"),
            new ArchitectureInfo("Clean","Strict separation of concerns.","Architecture"),
            new ArchitectureInfo("Layered","Layered architecture pattern.","Architecture"),
            new ArchitectureInfo("Hexagonal","Ports & Adapters architecture.","Architecture"),
            new ArchitectureInfo("Microservices","Independent distributed services.","Architecture"),
            new ArchitectureInfo("Event-Driven","Event-based communication.","Architecture"),
            new ArchitectureInfo("CQRS","Command Query Responsibility Segregation.","Architecture"),
            new ArchitectureInfo("Onion","Concentric layers architecture.","Architecture"),
            new ArchitectureInfo("DDD","Domain-Driven Design.","Architecture"),
        });

    [ObservableProperty]
    private ObservableCollection<ArchitectureInfo> _filteredArchitectures = [];

    [ObservableProperty]
    private string? _searchTerm;

    [ObservableProperty]
    private ArchitectureInfo? _selectedArchitecture;

    public ArchitecturesViewModel()
    {
        foreach (var a in Architectures)
            FilteredArchitectures.Add(a);
    }

    partial void OnSearchTermChanged(string? value)
    {
        var term = value?.Trim().ToLowerInvariant();
        FilteredArchitectures.Clear();
        foreach (var a in Architectures.Where(a => string.IsNullOrEmpty(term) || a.Name.ToLowerInvariant().Contains(term!)))
            FilteredArchitectures.Add(a);
    }

    [RelayCommand]
    private async Task OnSelectedArchitectureChangedAsync(ArchitectureInfo? value)
    {
        if (value is null) return;

        var route = value.Name
            .Replace(" ", string.Empty)
            .Replace("-", string.Empty)
            .Replace(".", string.Empty)
            .Replace("'", string.Empty)
            + "ArchitecturePage";

        var pageType = Type.GetType($"ArchiDesignPatterns.Mobile.Pages.Architectures.{route}");
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

        SelectedArchitecture = null;
    }
}