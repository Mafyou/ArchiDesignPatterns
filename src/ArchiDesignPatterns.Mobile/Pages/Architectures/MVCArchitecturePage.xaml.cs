namespace ArchiDesignPatterns.Mobile.Pages.Architectures;

public partial class MVCArchitecturePage : ContentPage
{
    private Model _model = new() { Data = "Hello" };
    private View _view = new();
    private Controller _controller = new();
    public MVCArchitecturePage()
    {
        InitializeComponent();
    }

    private void OnSimulateActionClicked(object sender, EventArgs e)
    {
        _controller.Update(_model, _view);
        ResultLabel.Text = $"Modèle : {_model.Data}";
    }

    public class Model { public string Data = "Hello"; }
    public class View { public void Display(string d) { /* Affichage */ } }
    public class Controller { public void Update(Model m, View v) { m.Data = "Updated"; v.Display(m.Data); } }
}
