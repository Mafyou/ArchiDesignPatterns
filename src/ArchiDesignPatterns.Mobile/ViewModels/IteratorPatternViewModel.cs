namespace ArchiDesignPatterns.Mobile.ViewModels;

public partial class IteratorPatternViewModel : ObservableObject
{
    [ObservableProperty]
    private string _result;

    [RelayCommand]
    private void OnIterate()
    {
        // Example: Custom collection and iterator usage
        var collection = new List<int> { 1, 2, 3, 4, 5 };
        var sb = new StringBuilder();
        sb.AppendLine("Iterating collection:");
        foreach (var item in collection)
        {
            sb.AppendLine($"Item: {item}");
        }
        Result = sb.ToString().TrimEnd();
    }
}