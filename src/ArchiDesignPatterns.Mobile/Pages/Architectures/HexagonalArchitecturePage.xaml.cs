namespace ArchiDesignPatterns.Mobile.Pages.Architectures;

public partial class HexagonalArchitecturePage : ContentPage
{
    public HexagonalArchitecturePage()
    {
        InitializeComponent();
        BindingContext = new HexagonalArchitectureViewModel();
    }

    private void OnSimulatePortClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "Port simulé (Port simulated)!";
    }
}
