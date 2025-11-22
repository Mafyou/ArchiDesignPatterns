namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class ObserverPatternPage : ContentPage
{
    public ObserverPatternPage(ObserverPatternViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
