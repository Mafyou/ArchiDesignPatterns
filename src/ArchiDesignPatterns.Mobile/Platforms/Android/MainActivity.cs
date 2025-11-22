using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Maui;

namespace ArchiDesignPatterns.Mobile
{
    [Activity(
        Theme = "@style/Maui.SplashTheme", 
        MainLauncher = true, 
        LaunchMode = LaunchMode.SingleTask,  // Changed from SingleTop to SingleTask
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density,
        AlwaysRetainTaskState = true)]  // Prevent Activity from being destroyed
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            
            System.Diagnostics.Debug.WriteLine("[MainActivity] OnCreate");
            
            // Add exception handling
            Android.Runtime.AndroidEnvironment.UnhandledExceptionRaiser += OnAndroidUnhandledException;
        }

        private void OnAndroidUnhandledException(object? sender, Android.Runtime.RaiseThrowableEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"[MainActivity] Android UnhandledException: {e.Exception}");
            Console.WriteLine($"Android UnhandledException: {e.Exception}");
            e.Handled = true;
        }

        protected override void OnDestroy()
        {
            System.Diagnostics.Debug.WriteLine("[MainActivity] OnDestroy");
            
            // Unsubscribe from events to prevent memory leaks
            Android.Runtime.AndroidEnvironment.UnhandledExceptionRaiser -= OnAndroidUnhandledException;
            
            base.OnDestroy();
        }

        protected override void OnPause()
        {
            System.Diagnostics.Debug.WriteLine("[MainActivity] OnPause");
            base.OnPause();
        }

        protected override void OnResume()
        {
            System.Diagnostics.Debug.WriteLine("[MainActivity] OnResume");
            base.OnResume();
        }

        protected override void OnStop()
        {
            System.Diagnostics.Debug.WriteLine("[MainActivity] OnStop");
            base.OnStop();
        }

        protected override void OnRestart()
        {
            System.Diagnostics.Debug.WriteLine("[MainActivity] OnRestart");
            base.OnRestart();
        }
    }
}
