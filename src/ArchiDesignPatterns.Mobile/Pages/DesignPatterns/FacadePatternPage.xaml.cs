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
        public string On() => "Lecteur DVD : Allumé";
        public string Play() => "Lecteur DVD : Lecture du film";
    }

    private class Projector
    {
        public string On() => "Projecteur : Allumé";
        public string SetInput(string input) => $"Projecteur : Entrée définie sur {input}";
    }

    private class SoundSystem
    {
        public string On() => "Système audio : Allumé";
        public string SetVolume(int level) => $"Système audio : Volume réglé sur {level}";
    }

    private class Lights
    {
        public string Dim(int level) => $"Éclairage : Atténué à {level}%";
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
            result.AppendLine("\nProfitez de votre film !");
            return result.ToString();
        }
    }
}
