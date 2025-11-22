namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class MediatorPatternPage : ContentPage
{
    public MediatorPatternPage()
    {
        InitializeComponent();
    }

    private void OnSendMessageClicked(object sender, EventArgs e)
    {
        IMediator mediator = new ConcreteMediator();
        mediator.Notify("Message envoyé via le médiateur");
        ResultLabel.Text = "Message envoyé via le médiateur";
    }

    public interface IMediator { void Notify(string msg); }
    public class ConcreteMediator : IMediator { public void Notify(string msg) { /* Action */ } }
}
