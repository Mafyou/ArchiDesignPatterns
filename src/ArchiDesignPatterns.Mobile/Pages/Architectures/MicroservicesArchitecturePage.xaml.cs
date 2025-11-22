namespace ArchiDesignPatterns.Mobile.Pages.Architectures;

public partial class MicroservicesArchitecturePage : ContentPage
{
    public MicroservicesArchitecturePage()
    {
        InitializeComponent();
    }

    private void OnCallMicroserviceClicked(object sender, EventArgs e)
    {
        IService service = new OrderService();
        ResultLabel.Text = $"Microservice : {service.Execute()}";
    }

    public interface IService { string Execute(); }
    public class OrderService : IService { public string Execute() => "Commande traitée"; }
    public class UserService : IService { public string Execute() => "Utilisateur créé"; }
}
