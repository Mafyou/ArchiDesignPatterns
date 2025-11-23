namespace ArchiDesignPatterns.Mobile.Pages.SOLIDPrinciples;

public partial class DependencyInversionPrinciplePage : ContentPage
{
    public DependencyInversionPrinciplePage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.DependencyInversionPrincipleViewModel();
    }

    private void OnShowViolationClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "? Violation du DIP:\n\n" +
            "Couplage fort avec EmailNotification:\n" +
            "• UserService dépend directement d'EmailNotification\n" +
            "• Impossible de changer pour SMS sans modifier UserService\n" +
            "• Difficile à tester (pas de mock possible)\n" +
            "• Module haut niveau dépend du module bas niveau\n\n" +
            "Problème: Couplage fort, aucune flexibilité.";
        ResultLabel.TextColor = Colors.Red;
    }

    private void OnShowCorrectClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "? Respect du DIP:\n\n" +
            "Dépendance sur l'abstraction INotification:\n" +
            "• UserService dépend de l'interface INotification\n" +
            "• Injection de dépendance via le constructeur\n" +
            "• Facile de changer Email ? SMS sans modifier UserService\n" +
            "• Facilite les tests avec des mocks\n\n" +
            "Avantage: Flexibilité maximale, couplage minimal.";
        ResultLabel.TextColor = Colors.Green;
    }
}
