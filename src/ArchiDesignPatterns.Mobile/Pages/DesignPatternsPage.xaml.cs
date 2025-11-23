namespace ArchiDesignPatterns.Mobile.Pages;

public partial class DesignPatternsPage : ContentPage
{
    public DesignPatternsPage(DesignPatternsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
    }
    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
    }
}