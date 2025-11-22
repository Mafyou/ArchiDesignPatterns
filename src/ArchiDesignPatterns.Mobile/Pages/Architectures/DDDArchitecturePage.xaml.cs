namespace ArchiDesignPatterns.Mobile.Pages.Architectures;

public partial class DDDArchitecturePage : ContentPage
{
    public DDDArchitecturePage()
    {
        InitializeComponent();
        BindingContext = new DDDArchitectureViewModel();
    }

    private void OnExecuteBusinessRuleClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "Business rule executed!";
    }
}
