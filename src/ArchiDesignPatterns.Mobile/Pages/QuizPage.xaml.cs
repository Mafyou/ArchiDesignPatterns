namespace ArchiDesignPatterns.Mobile.Pages;

public partial class QuizPage : ContentPage
{
    public QuizPage()
    {
        InitializeComponent();
        BindingContext = new QuizViewModel();
    }
}