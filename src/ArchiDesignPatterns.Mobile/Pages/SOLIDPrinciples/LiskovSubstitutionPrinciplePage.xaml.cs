namespace ArchiDesignPatterns.Mobile.Pages.SOLIDPrinciples;

public partial class LiskovSubstitutionPrinciplePage : ContentPage
{
    public LiskovSubstitutionPrinciplePage()
    {
        InitializeComponent();
        BindingContext = new LiskovSubstitutionPrincipleViewModel();
    }

    private void OnShowViolationClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "❌ Violation du LSP:\n\n" +
            "Le problème du Carré/Rectangle:\n" +
            "• Square hérite de Rectangle\n" +
            "• Mais modifier Width modifie aussi Height\n" +
            "• Le comportement n'est pas substituable\n" +
            "• rect.Width = 5; rect.Height = 10; donne un résultat inattendu\n\n" +
            "Problème: La sous-classe brise le contrat de la classe parent.";
        ResultLabel.TextColor = Colors.Red;
    }

    private void OnShowCorrectClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "✅ Respect du LSP:\n\n" +
            "Solution avec interface commune:\n" +
            "• Rectangle et Square implémentent IShape\n" +
            "• Pas d'héritage trompeur\n" +
            "• Chaque classe a son propre comportement\n" +
            "• Comportement prévisible et cohérent\n\n" +
            "Avantage: Chaque forme respecte son propre contrat sans surprise.";
        ResultLabel.TextColor = Colors.Green;
    }
}
