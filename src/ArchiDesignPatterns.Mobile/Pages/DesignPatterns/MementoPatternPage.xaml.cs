namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class MementoPatternPage : ContentPage
{
    private Originator _originator = new() { State = "Initial" };
    private Memento? _memento;
    public MementoPatternPage()
    {
        InitializeComponent();
    }

    private void OnSaveStateClicked(object sender, EventArgs e)
    {
        _memento = _originator.Save();
        _originator.State = "Modifié";
        ResultLabel.Text = $"État sauvegardé. État actuel : {_originator.State}";
    }

    private void OnRestoreStateClicked(object sender, EventArgs e)
    {
        if (_memento is not null)
        {
            _originator.Restore(_memento);
            ResultLabel.Text = $"État restauré : {_originator.State}";
        }
        else
        {
            ResultLabel.Text = "Aucun état sauvegardé.";
        }
    }

    public class Memento { public string State = string.Empty; }
    public class Originator
    {
        public string State = string.Empty;
        public Memento Save() => new() { State = State };
        public void Restore(Memento m) => State = m.State;
    }
}
