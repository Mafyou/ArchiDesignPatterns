namespace ArchiDesignPatterns.Mobile.Pages.SOLIDPrinciples;

public partial class OpenClosedPrinciplePage : ContentPage
{
    public OpenClosedPrinciplePage()
    {
        InitializeComponent();
        BindingContext = new OpenClosedPrincipleViewModel();
    }

    private void OnShowViolationClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "❌ Violation de l'OCP:\n\n" +
            "Pour ajouter une nouvelle forme (Triangle):\n" +
            "• Vous devez MODIFIER la classe AreaCalculator\n" +
            "• Ajouter un nouveau 'if' pour gérer Triangle\n" +
            "• Risque de casser le code existant\n" +
            "• Tous les tests doivent être refaits\n\n" +
            "Problème: Le code n'est pas fermé à la modification.";
        ResultLabel.TextColor = Colors.Red;
    }

    private void OnShowCorrectClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "✅ Respect de l'OCP:\n\n" +
            "Pour ajouter une nouvelle forme (Triangle):\n" +
            "• Créez simplement une nouvelle classe Triangle\n" +
            "• Implémentez l'interface IShape\n" +
            "• Aucune modification du code existant\n" +
            "• Aucun risque de régression\n\n" +
            "Avantage: Extension par héritage, pas par modification.";
        ResultLabel.TextColor = Colors.Green;
    }
}
