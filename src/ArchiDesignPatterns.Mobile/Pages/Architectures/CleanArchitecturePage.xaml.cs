namespace ArchiDesignPatterns.Mobile.Pages.Architectures;

public partial class CleanArchitecturePage : ContentPage
{
    public CleanArchitecturePage()
    {
        InitializeComponent();
        BindingContext = new CleanArchitectureViewModel();
    }

    private void OnSimulateServiceClicked(object sender, EventArgs e)
    {
        // Example: Simulate a service call and update the result label
        ResultLabel.Text = "Service call executed through all layers!";
    }
}
