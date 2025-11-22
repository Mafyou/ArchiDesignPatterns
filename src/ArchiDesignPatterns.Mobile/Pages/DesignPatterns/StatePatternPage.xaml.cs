namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class StatePatternPage : ContentPage
{
    private Context _context = new() { State = new StateA() };
    public StatePatternPage()
    {
        InitializeComponent();
    }

    private void OnChangeStateClicked(object sender, EventArgs e)
    {
        _context.State = _context.State is StateA ? new StateB() : new StateA();
        ResultLabel.Text = $"État actuel : {_context.Request()}";
    }

    public interface IState { string Handle(); }
    public class StateA : IState { public string Handle() => "A"; }
    public class StateB : IState { public string Handle() => "B"; }
    public class Context
    {
        public IState State = new StateA();
        public string Request() => State.Handle();
    }
}
