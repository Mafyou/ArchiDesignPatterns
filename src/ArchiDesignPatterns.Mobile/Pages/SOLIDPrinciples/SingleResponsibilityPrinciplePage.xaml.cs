namespace ArchiDesignPatterns.Mobile.Pages.SOLIDPrinciples;

public partial class SingleResponsibilityPrinciplePage : ContentPage
{
    public SingleResponsibilityPrinciplePage()
    {
        InitializeComponent();
        BindingContext = new SingleResponsibilityPrincipleViewModel();
    }

    private void OnShowViolationClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "❌ Violation du SRP:\n\n" +
            "La classe User a trop de responsabilités:\n" +
            "• Gestion du profil utilisateur\n" +
            "• Persistance en base de données\n" +
            "• Envoi d'emails\n" +
            "• Journalisation des activités\n\n" +
            "Problème: Si vous devez changer la façon d'envoyer des emails, vous devez modifier la classe User, ce qui viole le SRP.";
        ResultLabel.TextColor = Colors.Red;
    }

    private void OnShowCorrectClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "✅ Respect du SRP:\n\n" +
            "Chaque classe a une seule responsabilité:\n" +
            "• User: Gestion du profil\n" +
            "• UserRepository: Persistance\n" +
            "• EmailService: Envoi d'emails\n" +
            "• ActivityLogger: Journalisation\n\n" +
            "Avantage: Les modifications sont isolées et n'affectent qu'une seule classe.";
        ResultLabel.TextColor = Colors.Green;
    }
}
