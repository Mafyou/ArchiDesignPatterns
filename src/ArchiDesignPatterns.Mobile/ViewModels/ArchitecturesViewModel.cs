namespace ArchiDesignPatterns.Mobile.ViewModels;

public partial class ArchitecturesViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Architectures";

    [ObservableProperty]
    private ObservableCollection<ArchitectureInfo> _architectures = new(
        new[]
        {
            new ArchitectureInfo("MVC", Strings.MVC_Description, "Architectural Pattern"),
            new ArchitectureInfo("MVVM", Strings.MVVM_Description, "Architectural Pattern"),
            new ArchitectureInfo("Clean", Strings.Clean_Description, "Architecture"),
            new ArchitectureInfo("Layered", Strings.Layered_Description, "Architecture"),
            new ArchitectureInfo("Hexagonal", Strings.Hexagonal_Description, "Architecture"),
            new ArchitectureInfo("Microservices", Strings.Microservices_Description, "Architecture"),
            new ArchitectureInfo("Event-Driven", Strings.EventDriven_Description, "Architecture"),
            new ArchitectureInfo("CQRS", Strings.CQRS_Description, "Architecture"),
            new ArchitectureInfo("Onion", Strings.Onion_Description, "Architecture"),
            new ArchitectureInfo("DDD", Strings.DDD_Description, "Architecture"),
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