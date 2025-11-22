namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class BridgePatternPage : ContentPage
{
    public BridgePatternPage()
    {
        InitializeComponent();
    }

    private void OnDrawClicked(object sender, EventArgs e)
    {
        var results = new System.Text.StringBuilder();
        
        // Create renderers
        var vectorRenderer = new VectorRenderer();
        var rasterRenderer = new RasterRenderer();
        
        // Create shapes with different renderers
        var vectorCircle = new Circle(vectorRenderer, 5);
        var rasterCircle = new Circle(rasterRenderer, 5);
        
        results.AppendLine("Rendu Vectoriel :");
        results.AppendLine(vectorCircle.Draw());
        results.AppendLine();
        results.AppendLine("Rendu Matriciel :");
        results.AppendLine(rasterCircle.Draw());
        
        ResultLabel.Text = results.ToString();
    }

    // Implementation Interface
    private interface IRenderer
    {
        string RenderCircle(int radius);
    }

    // Concrete Implementations
    private class VectorRenderer : IRenderer
    {
        public string RenderCircle(int radius)
            => $"Dessin d'un cercle (vectoriel) avec rayon {radius}";
    }

    private class RasterRenderer : IRenderer
    {
        public string RenderCircle(int radius)
            => $"Dessin des pixels pour cercle avec rayon {radius}";
    }

    // Abstraction
    private abstract class Shape
    {
        protected IRenderer renderer;

        protected Shape(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public abstract string Draw();
    }

    // Refined Abstraction
    private class Circle : Shape
    {
        private int radius;

        public Circle(IRenderer renderer, int radius)
            : base(renderer)
        {
            this.radius = radius;
        }

        public override string Draw()
            => renderer.RenderCircle(radius);
    }
}
