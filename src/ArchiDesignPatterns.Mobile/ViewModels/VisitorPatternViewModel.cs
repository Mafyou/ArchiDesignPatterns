namespace ArchiDesignPatterns.Mobile.ViewModels;

public class VisitorPatternViewModel : ObservableObject
{
    private string _result = string.Empty;
    public string Result
    {
        get => _result;
        set => SetProperty(ref _result, value);
    }

    public RelayCommand AcceptVisitorCommand { get; }

    public VisitorPatternViewModel()
    {
        AcceptVisitorCommand = new RelayCommand(OnAcceptVisitor);
    }

    private void OnAcceptVisitor()
    {
        Result = "Visité!";
    }
}
