namespace ArchiDesignPatterns.Mobile.Pages.Architectures;

public partial class EventDrivenArchitecturePage : ContentPage
{
    public EventDrivenArchitecturePage()
    {
        InitializeComponent();
    }

    private void OnTriggerEventClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "Événement déclenché (Event triggered)!";
    }
}
