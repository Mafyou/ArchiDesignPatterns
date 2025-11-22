namespace ArchiDesignPatterns.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Gestion des exceptions non gérées
        TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
    }

    private void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine($"[Error] UnobservedTaskException: {e.Exception}");
        Console.WriteLine($"UnobservedTaskException: {e.Exception}");
        e.SetObserved();
    }

    private void OnUnhandledException(object? sender, UnhandledExceptionEventArgs e)
    {
        System.Diagnostics.Debug.WriteLine($"[Error] UnhandledException: {e.ExceptionObject}");
        Console.WriteLine($"UnhandledException: {e.ExceptionObject}");
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var window = new Window(new AppShell())
        {
            Title = "Design Patterns"
        };

        // Add window lifecycle handlers to prevent premature disposal
        window.Created += (s, e) => System.Diagnostics.Debug.WriteLine("[App] Window Created");
        window.Activated += (s, e) => System.Diagnostics.Debug.WriteLine("[App] Window Activated");
        window.Deactivated += (s, e) => System.Diagnostics.Debug.WriteLine("[App] Window Deactivated");
        window.Stopped += (s, e) => System.Diagnostics.Debug.WriteLine("[App] Window Stopped");
        window.Resumed += (s, e) => System.Diagnostics.Debug.WriteLine("[App] Window Resumed");
        window.Destroying += (s, e) => System.Diagnostics.Debug.WriteLine("[App] Window Destroying");

        return window;
    }
}