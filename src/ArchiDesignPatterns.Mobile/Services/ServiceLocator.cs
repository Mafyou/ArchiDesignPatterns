namespace ArchiDesignPatterns.Mobile.Services;

public static class ServiceLocator
{
    private static WeakReference<IServiceProvider>? _serviceProviderRef;

    public static IServiceProvider Instance
    {
        get
        {
            if (_serviceProviderRef?.TryGetTarget(out var provider) != true)
            {
                throw new ObjectDisposedException(nameof(ServiceLocator));
            }
            return provider;
        }
    }

    public static void Initialize(IServiceProvider provider)
    {
        _serviceProviderRef = new WeakReference<IServiceProvider>(provider);
    }
}