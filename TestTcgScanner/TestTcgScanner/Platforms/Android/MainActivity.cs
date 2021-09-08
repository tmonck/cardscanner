using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using Microsoft.Maui;

namespace TestTcgScanner.Platforms.Android
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : MauiAppCompatActivity
    {
        // All Code in this file came from https://github.com/dotnet/maui/blob/main/src/Essentials/samples/Samples/Platforms/Android/MainActivity.cs need to determine what is needed and what isn't.
        protected override void OnCreate(Bundle? bundle)
        {
            base.OnCreate(bundle);

            Microsoft.Maui.Essentials.Platform.Init(this, bundle);
            Microsoft.Maui.Essentials.Platform.ActivityStateChanged += Platform_ActivityStateChanged;
        }

        protected override void OnResume()
        {
            base.OnResume();

            Microsoft.Maui.Essentials.Platform.OnResume(this);
        }

        protected override void OnNewIntent(Intent? intent)
        {
            base.OnNewIntent(intent);

            Microsoft.Maui.Essentials.Platform.OnNewIntent(intent);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            Microsoft.Maui.Essentials.Platform.ActivityStateChanged -= Platform_ActivityStateChanged;
        }

        void Platform_ActivityStateChanged(object? sender, Microsoft.Maui.Essentials.ActivityStateChangedEventArgs e) =>
            Toast.MakeText(this, e.State.ToString(), ToastLength.Short)!.Show();

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Microsoft.Maui.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}