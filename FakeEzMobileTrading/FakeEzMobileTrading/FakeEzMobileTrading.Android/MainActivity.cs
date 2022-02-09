using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using CarouselView.FormsPlugin.Droid;
using Plugin.FirebasePushNotification;
using Xamarin.Forms;
using FakeEzMobileTrading.Views;

namespace FakeEzMobileTrading.Droid
{
    [Activity(Label = "FakeEzMobileTrading", Icon = "@mipmap/icon", Theme = "@style/MyCustomTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
   
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            MessagingCenter.Subscribe<PriceBoard>(this, "SetLandscapeModeOn", sender =>
            {
                RequestedOrientation = ScreenOrientation.Landscape;
            });
            MessagingCenter.Subscribe<PriceBoard>(this, "SetLandscapeModeOff", sender =>
            {
                RequestedOrientation = ScreenOrientation.Portrait;
            });

            FirebasePushNotificationManager.ProcessIntent(this, Intent);
            CarouselViewRenderer.Init();
           
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}