namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class BuilderPatternPage : ContentPage
{
    public BuilderPatternPage()
    {
        InitializeComponent();
    }

    private void OnBuildProductClicked(object sender, EventArgs e)
    {
        var builder = new ProductBuilder();
        var director = new Director(builder);

        director.BuildBasicProduct();
        var basicProduct = builder.GetProduct();

        director.BuildFullProduct();
        var fullProduct = builder.GetProduct();

        var result = new System.Text.StringBuilder();
        result.AppendLine("Produit de base :");
        result.AppendLine(basicProduct.ListParts());
        result.AppendLine("\nProduit complet :");
        result.AppendLine(fullProduct.ListParts());

        ResultLabel.Text = result.ToString();
    }

    // Product class
    private class Product
    {
        private readonly List<string> _parts = new();

        public void Add(string part)
        {
            _parts.Add(part);
        }

        public string ListParts()
        {
            return "Pièces : " + string.Join(", ", _parts);
        }
    }

    // Builder interface
    private interface IBuilder
    {
        void Reset();
        void BuildPartA();
        void BuildPartB();
        void BuildPartC();
        Product GetProduct();
    }

    // Concrete builder
    private class ProductBuilder : IBuilder
    {
        private Product _product = new();

        public void Reset()
        {
            _product = new Product();
        }

        public void BuildPartA()
        {
            _product.Add("Pièce A");
        }

        public void BuildPartB()
        {
            _product.Add("Pièce B");
        }

        public void BuildPartC()
        {
            _product.Add("Pièce C");
        }

        public Product GetProduct()
        {
            var result = _product;
            Reset();
            return result;
        }
    }

    // Director
    private class Director
    {
        private readonly IBuilder _builder;

        public Director(IBuilder builder)
        {
            _builder = builder;
        }

        public void BuildBasicProduct()
        {
            _builder.Reset();
            _builder.BuildPartA();
        }

        public void BuildFullProduct()
        {
            _builder.Reset();
            _builder.BuildPartA();
            _builder.BuildPartB();
            _builder.BuildPartC();
        }
    }
}
