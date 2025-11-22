namespace ArchiDesignPatterns.Mobile;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Add navigation event handlers
        this.Navigating += OnShellNavigating;
        this.Navigated += OnShellNavigated;
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
        bool shouldExit = await Application.Current!.MainPage!.DisplayAlertAsync(
            "Exit App",
            "Do you want to exit the application?",
            "Yes",
            "No");

        if (shouldExit)
        {
            Application.Current?.Quit();
        }
    }
}