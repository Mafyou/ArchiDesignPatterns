namespace ArchiDesignPatterns.Mobile.Pages.Architectures;

public partial class CQRSArchitecturePage : ContentPage
{
    public CQRSArchitecturePage()
    {
        InitializeComponent();
    }

    private void OnReadClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "Lecture effectuée (Read executed)!";
    }

    private void OnWriteClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "Écriture effectuée (Write executed)!";
    }
}
