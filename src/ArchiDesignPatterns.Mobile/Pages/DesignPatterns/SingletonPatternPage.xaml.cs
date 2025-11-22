namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class SingletonPatternPage : ContentPage
{
    private static Singleton _instance;

    public SingletonPatternPage()
    {
        InitializeComponent();
        //         BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Réinitialiser les ressources si nécessaire
        _instance = null;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }

    private void OnCreateSingletonClicked(object sender, EventArgs e)
    {
        if (_instance is null)
        {
            _instance = new Singleton();
            ResultLabel.Text = "Instance Singleton créée.";
        }
        else
        {
            ResultLabel.Text = "L'instance Singleton existe déjà.";
        }
    }

    public class Singleton
    {
        public Singleton() { }
    }
}
