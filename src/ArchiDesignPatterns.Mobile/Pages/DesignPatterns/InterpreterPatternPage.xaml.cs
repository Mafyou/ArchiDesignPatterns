namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class InterpreterPatternPage : ContentPage
{
    public InterpreterPatternPage()
    {
        InitializeComponent();
        BindingContext = new InterpreterPatternViewModel();
    }

    private void OnInterpretClicked(object sender, EventArgs e)
    {
        IExpression expr = new Add(new Number(1), new Number(2));
        ResultLabel.Text = $"Résultat : {expr.Interpret()}";
    }

    public interface IExpression { int Interpret(); }
    public class Number : IExpression { public int Value; public Number(int v) => Value = v; public int Interpret() => Value; }
    public class Add : IExpression { public IExpression Left, Right; public Add(IExpression l, IExpression r) { Left = l; Right = r; } public int Interpret() => Left.Interpret() + Right.Interpret(); }
}
