namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class CommandPatternPage : ContentPage
{
    public CommandPatternPage()
    {
        InitializeComponent();
    }

    private void OnExecuteCommandClicked(object sender, EventArgs e)
    {
        var light = new Light();
        var turnOnCommand = new TurnOnCommand(light);
        var turnOffCommand = new TurnOffCommand(light);
        var remote = new RemoteControl();

        var result = new System.Text.StringBuilder();

        remote.SetCommand(turnOnCommand);
        result.AppendLine(remote.PressButton());

        remote.SetCommand(turnOffCommand);
        result.AppendLine(remote.PressButton());

        ResultLabel.Text = result.ToString();
    }

    // Receiver
    private class Light
    {
        public string TurnOn() => "Light is ON";
        public string TurnOff() => "Light is OFF";
    }

    // Command interface
    private interface ICommand
    {
        string Execute();
    }

    // Concrete commands
    private class TurnOnCommand : ICommand
    {
        private readonly Light _light;

        public TurnOnCommand(Light light)
        {
            _light = light;
        }

        public string Execute() => _light.TurnOn();
    }

    private class TurnOffCommand : ICommand
    {
        private readonly Light _light;

        public TurnOffCommand(Light light)
        {
            _light = light;
        }

        public string Execute() => _light.TurnOff();
    }

    // Invoker
    private class RemoteControl
    {
        private ICommand? _command;

        public void SetCommand(ICommand command)
        {
            _command = command;
        }

        public string PressButton()
        {
            return _command?.Execute() ?? "No command set";
        }
    }
}
