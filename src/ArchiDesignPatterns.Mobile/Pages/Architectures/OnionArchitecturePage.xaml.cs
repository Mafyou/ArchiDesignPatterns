namespace ArchiDesignPatterns.Mobile.Pages.Architectures;

public partial class OnionArchitecturePage : ContentPage
{
    private Service _service = new();
    public OnionArchitecturePage()
    {
        InitializeComponent();
    }

    private void OnCallDomainClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = $"Résultat : {_service.Serve()}";
    }

    public class Domain { public string Logic() => "Domaine"; }
    public class Service { private Domain _d = new(); public string Serve() => _d.Logic(); }
}
