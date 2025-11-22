namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class VisitorPatternPage : ContentPage
{
    public VisitorPatternPage()
    {
        InitializeComponent();
    }

    private void OnAcceptVisitorClicked(object sender, EventArgs e)
    {
        var element = new Element();
        var visitor = new ConcreteVisitor();
        ResultLabel.Text = $"Résultat : {element.Accept(visitor)}";
    }

    public interface IVisitor { string Visit(Element e); }
    public class Element { public string Accept(IVisitor v) => v.Visit(this); }
    public class ConcreteVisitor : IVisitor { public string Visit(Element e) => "Visité"; }
}
