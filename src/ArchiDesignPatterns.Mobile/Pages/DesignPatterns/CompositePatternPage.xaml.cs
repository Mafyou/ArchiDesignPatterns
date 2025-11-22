namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class CompositePatternPage : ContentPage
{
    public CompositePatternPage()
    {
        InitializeComponent();
    }

    private void OnShowStructureClicked(object sender, EventArgs e)
    {
        // Create leaf components
        var leaf1 = new Leaf("Leaf 1");
        var leaf2 = new Leaf("Leaf 2");
        var leaf3 = new Leaf("Leaf 3");

        // Create composite components
        var composite1 = new Composite("Composite 1");
        composite1.Add(leaf1);
        composite1.Add(leaf2);

        var composite2 = new Composite("Root");
        composite2.Add(composite1);
        composite2.Add(leaf3);

        ResultLabel.Text = composite2.Display();
    }

    // Component interface
    private interface IComponent
    {
        string Display();
    }

    // Leaf (individual object)
    private class Leaf : IComponent
    {
        private readonly string _name;

        public Leaf(string name)
        {
            _name = name;
        }

        public string Display() => $"- {_name}";
    }

    // Composite (container of components)
    private class Composite : IComponent
    {
        private readonly string _name;
        private readonly List<IComponent> _children = new();

        public Composite(string name)
        {
            _name = name;
        }

        public void Add(IComponent component)
        {
            _children.Add(component);
        }

        public string Display()
        {
            var result = $"+ {_name}\n";
            foreach (var child in _children)
            {
                result += $"  {child.Display()}\n";
            }
            return result;
        }
    }
}
