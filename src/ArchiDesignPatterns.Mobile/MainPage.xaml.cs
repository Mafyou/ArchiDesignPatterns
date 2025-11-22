namespace ArchiDesignPatterns.Mobile;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnDesignPatternsClicked(object? sender, EventArgs e)
    {
        var pageType = Type.GetType("ArchiDesignPatterns.Mobile.Pages.DesignPatternsPage");
        if (pageType is null)
        {
            await DisplayAlertAsync("Navigation Error", "Could not find DesignPatternsPage type.", "OK");
            return;
        }
        Page? page = null;
        if (App.Current.Handler?.MauiContext?.Services is IServiceProvider services)
        {
            page = services.GetService(pageType) as Page;
        }
        page ??= Activator.CreateInstance(pageType) as Page;
        if (page is not null && Shell.Current.Navigation is not null)
            await Shell.Current.Navigation.PushAsync(page);
        else
            await Shell.Current.GoToAsync("//DesignPatternsPage");
    }

    private async void OnArchitecturesClicked(object? sender, EventArgs e)
    {
        var pageType = Type.GetType("ArchiDesignPatterns.Mobile.Pages.ArchitecturesPage");
        if (pageType is null)
        {
            await DisplayAlert("Navigation Error", "Could not find ArchitecturesPage type.", "OK");
            return;
        }
        Page? page = null;
        if (App.Current.Handler?.MauiContext?.Services is IServiceProvider services)
        {
            page = services.GetService(pageType) as Page;
        }
        page ??= Activator.CreateInstance(pageType) as Page;
        if (page is not null && Shell.Current.Navigation is not null)
            await Shell.Current.Navigation.PushAsync(page);
        else
            await Shell.Current.GoToAsync("//ArchitecturesPage");
    }

    private async void OnQuizClicked(object? sender, EventArgs e)
    {
        var pageType = Type.GetType("ArchiDesignPatterns.Mobile.Pages.QuizPage");
        if (pageType is null)
        {
            await DisplayAlertAsync("Navigation Error", "Could not find QuizPage type.", "OK");
            return;
        }
        Page? page = null;
        if (App.Current.Handler?.MauiContext?.Services is IServiceProvider services)
        {
            page = services.GetService(pageType) as Page;
        }
        page ??= Activator.CreateInstance(pageType) as Page;
        if (page is not null && Shell.Current.Navigation is not null)
            await Shell.Current.Navigation.PushAsync(page);
        else
            await Shell.Current.GoToAsync("//QuizPage");
    }
}