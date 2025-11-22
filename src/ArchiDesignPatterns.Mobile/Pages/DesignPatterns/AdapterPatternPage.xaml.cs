namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class AdapterPatternPage : ContentPage
{
    public AdapterPatternPage()
    {
        InitializeComponent();
    }

    private void OnUseAdapterClicked(object sender, EventArgs e)
    {
        ITarget adapter = new Adapter();
        ResultLabel.Text = $"Résultat : {adapter.Request()}";
    }

    public interface ITarget { string Request(); }
    public class Adaptee { public string SpecificRequest() => "Spécifique"; }
    public class Adapter : ITarget
    {
        private readonly Adaptee _adaptee = new();
        public string Request() => _adaptee.SpecificRequest();
    }
}
