namespace ArchiDesignPatterns.Mobile.ViewModels;

public partial class SOLIDPrinciplesViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Principes SOLID";

    [ObservableProperty]
    private ObservableCollection<SOLIDPrincipleInfo> _principles = new(
        new[]
        {
            new SOLIDPrincipleInfo("Single Responsibility", Strings.SRP_Description, "SOLID"),
            new SOLIDPrincipleInfo("Open/Closed", Strings.OCP_Description, "SOLID"),
            new SOLIDPrincipleInfo("Liskov Substitution", Strings.LSP_Description, "SOLID"),
            new SOLIDPrincipleInfo("Interface Segregation", Strings.ISP_Description, "SOLID"),
            new SOLIDPrincipleInfo("Dependency Inversion", Strings.DIP_Description, "SOLID"),
        });

    [ObservableProperty]
    private ObservableCollection<SOLIDPrincipleInfo> _filteredPrinciples = [];

    [ObservableProperty]
    private string? _searchTerm;

    [ObservableProperty]
    private SOLIDPrincipleInfo? _selectedPrinciple;

    public SOLIDPrinciplesViewModel()
    {
        foreach (var p in Principles)
            FilteredPrinciples.Add(p);
    }

    partial void OnSearchTermChanged(string? value)
    {
        var term = value?.Trim().ToLowerInvariant();
        FilteredPrinciples.Clear();
        foreach (var p in Principles.Where(p => string.IsNullOrEmpty(term) || p.Name.ToLowerInvariant().Contains(term!)))
            FilteredPrinciples.Add(p);
    }

    [RelayCommand]
    private async Task OnSelectedPrincipleChangedAsync(SOLIDPrincipleInfo? value)
    {
        if (value is null) return;

        var route = value.Name
            .Replace(" ", string.Empty)
            .Replace("/", string.Empty)
            .Replace("-", string.Empty)
            .Replace(".", string.Empty)
            .Replace("'", string.Empty)
            + "PrinciplePage";

        var pageType = Type.GetType($"ArchiDesignPatterns.Mobile.Pages.SOLIDPrinciples.{route}");
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

        SelectedPrinciple = null;
    }
}
