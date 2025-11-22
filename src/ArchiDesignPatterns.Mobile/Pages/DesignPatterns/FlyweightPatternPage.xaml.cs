namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class FlyweightPatternPage : ContentPage
{
    public FlyweightPatternPage()
    {
        InitializeComponent();
        BindingContext = new FlyweightPatternViewModel();
    }

    private void OnUseFlyweightClicked(object sender, EventArgs e)
    {
        var factory = new CharacterFactory();
        var result = new System.Text.StringBuilder();

        // Create characters using flyweight
        var char1 = factory.GetCharacter('A');
        var char2 = factory.GetCharacter('B');
        var char3 = factory.GetCharacter('A'); // Reuses existing 'A'

        result.AppendLine(char1.Display(12, "Red"));
        result.AppendLine(char2.Display(14, "Blue"));
        result.AppendLine(char3.Display(16, "Green"));
        result.AppendLine($"\nTotal unique characters created: {factory.GetTotalCharacters()}");

        ResultLabel.Text = result.ToString();
    }

    // Flyweight - intrinsic state (shared)
    private class Character
    {
        private readonly char _symbol;

        public Character(char symbol)
        {
            _symbol = symbol;
        }

        public string Display(int size, string color)
        {
            return $"Character '{_symbol}' with size {size} and color {color}";
        }
    }

    // Flyweight Factory
    private class CharacterFactory
    {
        private readonly Dictionary<char, Character> _characters = new();

        public Character GetCharacter(char symbol)
        {
            if (!_characters.ContainsKey(symbol))
            {
                _characters[symbol] = new Character(symbol);
            }
            return _characters[symbol];
        }

        public int GetTotalCharacters()
        {
            return _characters.Count;
        }
    }
}
