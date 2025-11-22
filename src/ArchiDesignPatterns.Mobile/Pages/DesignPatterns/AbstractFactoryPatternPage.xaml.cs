namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class AbstractFactoryPatternPage : ContentPage
{
    public AbstractFactoryPatternPage(AbstractFactoryPatternViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    private void OnCreateFamilyClicked(object sender, EventArgs e)
    {
        IFactory factory = new WinFactory();
        var button = factory.CreateButton();
        ResultLabel.Text = $"Bouton créé : {button.Paint()}";
    }

    public interface IButton { string Paint(); }
    public class WinButton : IButton { public string Paint() => "WinButton"; }
    public class MacButton : IButton { public string Paint() => "MacButton"; }
    public interface IFactory { IButton CreateButton(); }
    public class WinFactory : IFactory { public IButton CreateButton() => new WinButton(); }
    public class MacFactory : IFactory { public IButton CreateButton() => new MacButton(); }
}
