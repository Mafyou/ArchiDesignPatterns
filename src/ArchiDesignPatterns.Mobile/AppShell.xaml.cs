namespace ArchiDesignPatterns.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Add navigation event handlers
        this.Navigating += OnShellNavigating;
        this.Navigated += OnShellNavigated;

        UpdateLanguageIcon();
    }

    private void OnShellNavigating(object? sender, ShellNavigatingEventArgs e)
    {
        // Log navigation attempts for debugging
        System.Diagnostics.Debug.WriteLine($"[Navigation] Navigating from: {e.Current?.Location} to: {e.Target.Location}");

        // Handle back button behavior
        if (e.Source == ShellNavigationSource.Pop)
        {
            var currentRoute = $"{e.Current?.Location}";
            var targetRoute = $"{e.Target.Location}";

            // If target is empty (going to exit app), and we're not on main pages, show confirmation
            if (string.IsNullOrEmpty(targetRoute) || targetRoute == "/")
            {
                // Check if we're on a main navigation page (Home, All Patterns, All Architectures, Quiz)
                if (currentRoute != null &&
                    (currentRoute.Contains("MainPage") ||
                     currentRoute.EndsWith("DesignPatternsPage") ||
                     currentRoute.EndsWith("ArchitecturesPage") ||
                     currentRoute.Contains("QuizPage")))
                {
                    e.Cancel();
                    _ = ConfirmExitAsync();
                    return;
                }
            }
            // Allow all other back navigation (between pattern pages, from pattern to list, etc.)
            // Do not cancel - let it proceed normally
        }
    }

    private void OnShellNavigated(object? sender, ShellNavigatedEventArgs e)
    {
        // Log successful navigation
        System.Diagnostics.Debug.WriteLine($"[Navigation] Successfully navigated to: {e.Current.Location}");
        System.Diagnostics.Debug.WriteLine($"[Navigation] Previous location was: {e.Previous?.Location}");
    }

    private async Task ConfirmExitAsync()
    {
        bool shouldExit = await Application.Current!.Windows[0]!.Page.DisplayAlertAsync(
            "Exit App",
            "Do you want to exit the application?",
            "Yes",
            "No");

        if (shouldExit)
        {
            Application.Current?.Quit();
        }
    }

    private async void OnLanguageToolbarItemClicked(object sender, EventArgs e)
    {
        // Toggle between French and English
        var currentCulture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
        var newCulture = currentCulture == "fr" ? "en" : "fr";
        SetCulture(newCulture);
        UpdateLanguageIcon();
        await ReloadCurrentPageAsync();
    }

    private static void SetCulture(string cultureCode)
    {
        var culture = new CultureInfo(cultureCode);
        Thread.CurrentThread.CurrentUICulture = culture;
        Thread.CurrentThread.CurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }

    private void UpdateLanguageIcon()
    {
        if (LanguageToolbarItem is not null)
        {
            var currentCulture = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            LanguageToolbarItem.Text = currentCulture != "fr" ? "🇫🇷" : "🇬🇧";
        }
    }

    private async Task ReloadCurrentPageAsync()
    {
        var nav = App.Current.Windows[0].Page.Navigation;
        var currentPage = nav.NavigationStack.LastOrDefault();
        if (currentPage is null)
            return;

        var pageType = currentPage.GetType();
        object? newPage = null;

        // Try to handle ViewModel if present
        var viewModel = currentPage?.BindingContext;
        if (viewModel is not null)
        {
            // Look for a constructor that takes the ViewModel type
            var ctor = pageType.GetConstructor([viewModel.GetType()]);
            if (ctor != null)
            {
                newPage = ctor.Invoke([viewModel]);
            }
        }

        // Fallback to default constructor
        newPage ??= Activator.CreateInstance(pageType);

        if (newPage is not Page pageInstance)
            return;

        await nav.PopAsync();
        await nav.PushAsync(pageInstance);
    }
}