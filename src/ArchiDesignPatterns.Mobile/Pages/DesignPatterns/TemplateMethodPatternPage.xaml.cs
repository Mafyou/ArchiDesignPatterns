namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class TemplateMethodPatternPage : ContentPage
{
    public TemplateMethodPatternPage()
    {
        InitializeComponent();
    }

    private void OnExecuteTemplateClicked(object sender, EventArgs e)
    {
        Base algo = new Concrete();
        ResultLabel.Text = $"Résultat : {algo.Template()}";
    }

    public abstract class Base { public string Template() => Step1() + Step2(); protected abstract string Step1(); protected abstract string Step2(); }
    public class Concrete : Base { protected override string Step1() => "A"; protected override string Step2() => "B"; }
}
