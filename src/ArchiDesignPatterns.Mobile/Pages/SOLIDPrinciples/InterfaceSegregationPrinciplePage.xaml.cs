namespace ArchiDesignPatterns.Mobile.Pages.SOLIDPrinciples;

public partial class InterfaceSegregationPrinciplePage : ContentPage
{
    public InterfaceSegregationPrinciplePage()
    {
        InitializeComponent();
        BindingContext = new InterfaceSegregationPrincipleViewModel();
    }

    private void OnShowViolationClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "❌ Violation de l'ISP:\n\n" +
            "Interface monolithique IWorker:\n" +
            "• Force tous les workers à implémenter toutes les méthodes\n" +
            "• Un Robot doit implémenter Eat() et Sleep()\n" +
            "• Conduit à des NotImplementedException\n" +
            "• Dépendances inutiles\n\n" +
            "Problème: Les clients dépendent de méthodes qu'ils n'utilisent pas.";
        ResultLabel.TextColor = Colors.Red;
    }

    private void OnShowCorrectClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "✅ Respect de l'ISP:\n\n" +
            "Interfaces ségrégées:\n" +
            "• IWorkable, IFeedable, ISleepable, IPayable\n" +
            "• Chaque classe implémente ce dont elle a besoin\n" +
            "• Human: toutes les interfaces\n" +
            "• Robot: seulement IWorkable et IPayable\n\n" +
            "Avantage: Pas de dépendances inutiles, code plus propre.";
        ResultLabel.TextColor = Colors.Green;
    }
}
