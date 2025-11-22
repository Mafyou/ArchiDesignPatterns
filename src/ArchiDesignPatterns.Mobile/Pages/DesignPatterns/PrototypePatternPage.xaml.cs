namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class PrototypePatternPage : ContentPage
{
    private Prototype _prototype = new Prototype { Data = "Original" };
    public PrototypePatternPage()
    {
        InitializeComponent();
    }

    private void OnCloneObjectClicked(object sender, EventArgs e)
    {
        var clone = _prototype.Clone();
        ResultLabel.Text = $"Cloné : {clone.Data}";
    }

    public class Prototype { public string Data; public Prototype Clone() => new Prototype { Data = this.Data }; }
}
