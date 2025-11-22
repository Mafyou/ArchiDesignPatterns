namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class DecoratorPatternPage : ContentPage
{
    public DecoratorPatternPage()
    {
        InitializeComponent();
    }

    private void OnAddDecorationClicked(object sender, EventArgs e)
    {
        // Create a simple coffee
        ICoffee coffee = new SimpleCoffee();
        var result = new System.Text.StringBuilder();

        result.AppendLine($"Simple Coffee: {coffee.GetDescription()}");
        result.AppendLine($"Cost: ${coffee.GetCost()}");
        result.AppendLine();

        // Add milk
        coffee = new MilkDecorator(coffee);
        result.AppendLine($"With Milk: {coffee.GetDescription()}");
        result.AppendLine($"Cost: ${coffee.GetCost()}");
        result.AppendLine();

        // Add sugar
        coffee = new SugarDecorator(coffee);
        result.AppendLine($"With Milk & Sugar: {coffee.GetDescription()}");
        result.AppendLine($"Cost: ${coffee.GetCost()}");

        ResultLabel.Text = result.ToString();
    }

    // Component interface
    private interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    // Concrete component
    private class SimpleCoffee : ICoffee
    {
        public string GetDescription() => "Simple Coffee";
        public double GetCost() => 2.0;
    }

    // Base decorator
    private abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;

        protected CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }

        public virtual string GetDescription() => _coffee.GetDescription();
        public virtual double GetCost() => _coffee.GetCost();
    }

    // Concrete decorators
    private class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => _coffee.GetDescription() + ", Milk";
        public override double GetCost() => _coffee.GetCost() + 0.5;
    }

    private class SugarDecorator : CoffeeDecorator
    {
        public SugarDecorator(ICoffee coffee) : base(coffee) { }

        public override string GetDescription() => _coffee.GetDescription() + ", Sugar";
        public override double GetCost() => _coffee.GetCost() + 0.2;
    }
}
