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
        
        results.AppendLine("Vector Rendering:");
        results.AppendLine(vectorCircle.Draw());
        results.AppendLine();
        results.AppendLine("Raster Rendering:");
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
            => $"Drawing circle (vector) with radius {radius}";
    }

    private class RasterRenderer : IRenderer
    {
        public string RenderCircle(int radius)
            => $"Drawing pixels for circle with radius {radius}";
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
