namespace ArchiDesignPatterns.Mobile.Pages.Architectures;

public partial class MVVMArchitecturePage : ContentPage
{
    private Model _model = new() { Data = "Hello" };
    private ViewModel _viewModel = new();
    public MVVMArchitecturePage()
    {
        InitializeComponent();
        _viewModel.Model = _model;
    }

    private void OnUpdateClicked(object sender, EventArgs e)
    {
        _viewModel.Update();
        ResultLabel.Text = $"Modèle : {_model.Data}";
    }

    public class Model { public string Data = "Hello"; }
    public class ViewModel { public Model Model = new(); public void Update() => Model.Data = "Updated"; }
}
