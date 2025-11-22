namespace ArchiDesignPatterns.Mobile.ViewModels;

public partial class FlyweightPatternViewModel : ObservableObject
{
    [ObservableProperty]
    private string _result;

    public ICommand UseFlyweightCommand { get; }

    public FlyweightPatternViewModel()
    {
        UseFlyweightCommand = new Command(UseFlyweight);
    }

    private void UseFlyweight()
    {
        // Exemple d'utilisation du Flyweight
        var factory = new FlyweightFactory();
        var fly1 = factory.Get("A");
        var fly2 = factory.Get("A");
        Result = fly1 == fly2 ? "Flyweight partagé!" : "Flyweight non partagé.";
    }
}

// Exemple simple de Flyweight et Factory
public class Flyweight { public string Data; }
public class FlyweightFactory
{
    private readonly Dictionary<string, Flyweight> _cache = [];
    public Flyweight Get(string key) => _cache.TryGetValue(key, out var f) ? f : (_cache[key] = new Flyweight { Data = key });
}
