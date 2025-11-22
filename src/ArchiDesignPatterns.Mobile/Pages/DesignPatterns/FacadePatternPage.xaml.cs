namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class FacadePatternPage : ContentPage
{
    public FacadePatternPage()
    {
        InitializeComponent();
    }

    private void OnUseFacadeClicked(object sender, EventArgs e)
    {
        var facade = new HomeTheaterFacade();
        var result = facade.WatchMovie();
        ResultLabel.Text = result;
    }

    // Complex subsystems
    private class DVDPlayer
    {
        public string On() => "DVD Player: On";
        public string Play() => "DVD Player: Playing movie";
    }

    private class Projector
    {
        public string On() => "Projector: On";
        public string SetInput(string input) => $"Projector: Input set to {input}";
    }

    private class SoundSystem
    {
        public string On() => "Sound System: On";
        public string SetVolume(int level) => $"Sound System: Volume set to {level}";
    }

    private class Lights
    {
        public string Dim(int level) => $"Lights: Dimmed to {level}%";
    }

    // Facade
    private class HomeTheaterFacade
    {
        private readonly DVDPlayer _dvd;
        private readonly Projector _projector;
        private readonly SoundSystem _soundSystem;
        private readonly Lights _lights;

        public HomeTheaterFacade()
        {
            _dvd = new DVDPlayer();
            _projector = new Projector();
            _soundSystem = new SoundSystem();
            _lights = new Lights();
        }

        public string WatchMovie()
        {
            var result = new System.Text.StringBuilder();
            result.AppendLine(_lights.Dim(10));
            result.AppendLine(_projector.On());
            result.AppendLine(_projector.SetInput("DVD"));
            result.AppendLine(_soundSystem.On());
            result.AppendLine(_soundSystem.SetVolume(5));
            result.AppendLine(_dvd.On());
            result.AppendLine(_dvd.Play());
            result.AppendLine("\nEnjoy your movie!");
            return result.ToString();
        }
    }
}
