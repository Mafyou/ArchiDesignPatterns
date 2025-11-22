namespace ArchiDesignPatterns.Mobile.Pages.DesignPatterns;

public partial class IteratorPatternPage : ContentPage
{
    public IteratorPatternPage()
    {
        InitializeComponent();
        BindingContext = new IteratorPatternViewModel();
    }

    private void OnIterateClicked(object sender, EventArgs e)
    {
        var collection = new MyCollection();
        var result = string.Join(", ", collection);
        ResultLabel.Text = $"Parcours : {result}";
    }

    public class MyCollection : IEnumerable<int>
    {
        public int[] Data = { 1, 2, 3 };
        public IEnumerator<int> GetEnumerator() => ((IEnumerable<int>)Data).GetEnumerator();
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();
    }
}