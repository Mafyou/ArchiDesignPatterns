namespace ArchiDesignPatterns.Mobile.ViewModels;

public partial class DesignPatternsViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Design Patterns";

    [ObservableProperty]
    private ObservableCollection<DesignPatternInfo> _patterns = new(
        new[]
        {
            new DesignPatternInfo("Singleton","Assure qu'une classe n'ait qu'une seule instance.","Creational"),
            new DesignPatternInfo("Factory","Crée des objets sans exposer la logique de création.","Creational"),
            new DesignPatternInfo("Abstract Factory","Crée des familles d'objets liés.","Creational"),
            new DesignPatternInfo("Builder","Construit des objets complexes étape par étape.","Creational"),
            new DesignPatternInfo("Prototype","Crée des objets par clonage.","Creational"),
            new DesignPatternInfo("Adapter","Convertit l'interface d'une classe.","Structural"),
            new DesignPatternInfo("Bridge","Sépare l'abstraction de l'implémentation.","Structural"),
            new DesignPatternInfo("Composite","Structure arborescente d'objets.","Structural"),
            new DesignPatternInfo("Decorator","Ajoute des fonctionnalités dynamiquement.","Structural"),
            new DesignPatternInfo("Facade","Interface simplifiée.","Structural"),
            new DesignPatternInfo("Flyweight","Partage des objets pour l'efficacité.","Structural"),
            new DesignPatternInfo("Proxy","Fournit un substitut ou un espace réservé.","Structural"),
            new DesignPatternInfo("Chain of Responsibility","Chaîne de gestionnaires de traitement.","Behavioral"),
            new DesignPatternInfo("Command","Encapsule une requête en tant qu'objet.","Behavioral"),
            new DesignPatternInfo("Interpreter","Interprète une grammaire ou un langage.","Behavioral"),
            new DesignPatternInfo("Iterator","Itère à travers une collection.","Behavioral"),
            new DesignPatternInfo("Mediator","Communication centralisée.","Behavioral"),
            new DesignPatternInfo("Memento","Sauvegarde et restaure l'état d'un objet.","Behavioral"),
            new DesignPatternInfo("Observer","Notifie les observateurs des changements.","Behavioral"),
            new DesignPatternInfo("State","Le comportement change avec l'état.","Behavioral"),
            new DesignPatternInfo("Strategy","Algorithmes interchangeables.","Behavioral"),
            new DesignPatternInfo("Template Method","Définit le squelette d'algorithme.","Behavioral"),
            new DesignPatternInfo("Visitor","Sépare l'algorithme de la structure.","Behavioral"),
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