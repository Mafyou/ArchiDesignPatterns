namespace ArchiDesignPatterns.Mobile.ViewModels;

public partial class ArchitecturesViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Architectures";

    [ObservableProperty]
    private ObservableCollection<ArchitectureInfo> _architectures = new(
        new[]
        {
            new ArchitectureInfo("MVC","Modèle Modèle-Vue-Contrôleur.","Architectural Pattern"),
            new ArchitectureInfo("MVVM","Modèle Modèle-Vue-VueModèle.","Architectural Pattern"),
            new ArchitectureInfo("Clean","Séparation stricte des responsabilités.","Architecture"),
            new ArchitectureInfo("Layered","Architecture en couches.","Architecture"),
            new ArchitectureInfo("Hexagonal","Architecture Ports et Adaptateurs.","Architecture"),
            new ArchitectureInfo("Microservices","Services distribués indépendants.","Architecture"),
            new ArchitectureInfo("Event-Driven","Communication basée sur les événements.","Architecture"),
            new ArchitectureInfo("CQRS","Ségrégation des responsabilités Commande-Requête.","Architecture"),
            new ArchitectureInfo("Onion","Architecture en couches concentriques.","Architecture"),
            new ArchitectureInfo("DDD","Conception pilotée par le domaine.","Architecture"),
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