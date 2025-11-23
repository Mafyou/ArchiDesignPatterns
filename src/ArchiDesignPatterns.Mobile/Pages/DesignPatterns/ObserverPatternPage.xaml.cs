namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class ObserverPatternPage : ContentPage
{
    public ObserverPatternPage(ObserverPatternViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnPublishNewsClicked(object sender, EventArgs e)
    {
        // Example logic for Observer pattern demonstration
        // You can replace this with actual ViewModel logic if needed
        var message = "News published! All subscribers notified.";
        ResultLabel.Text = message;
    }
}
