namespace ArchiDesignPatterns.Mobile.ViewModels;

public partial class StrategyPatternViewModel : ObservableObject
{
    public ObservableCollection<string> Strategies { get; } = new()
    {
        "Stratégie A",
        "Stratégie B",
        "Stratégie C"
    };

    [ObservableProperty]
    private string? selectedStrategy;

    [ObservableProperty]
    private string? result;

    public StrategyPatternViewModel()
    {
        SelectedStrategy = Strategies.FirstOrDefault();
    }

    [RelayCommand]
    private void ExecuteStrategy()
    {
        Result = SelectedStrategy switch
        {
            "Stratégie A" => "Stratégie A exécutée !",
            "Stratégie B" => "Stratégie B exécutée !",
            "Stratégie C" => "Stratégie C exécutée !",
            _ => "Veuillez sélectionner une stratégie."
        };
    }
}
