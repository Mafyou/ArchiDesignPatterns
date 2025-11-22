namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class ProxyPatternPage : ContentPage
{
    public ProxyPatternPage()
    {
        InitializeComponent();
    }

    private void OnAccessProxyClicked(object sender, EventArgs e)
    {
        IService proxy = new Proxy();
        ResultLabel.Text = $"Accès via proxy : {proxy.Request()}";
    }

    public interface IService { string Request(); }
    public class RealService : IService { public string Request() => "Réel"; }
    public class Proxy : IService
    {
        private readonly RealService _service = new();
        public string Request() => _service.Request();
    }
}
