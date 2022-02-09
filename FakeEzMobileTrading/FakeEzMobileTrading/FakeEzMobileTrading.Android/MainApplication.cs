using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FakeEzMobileTrading.Droid
{
    [Application]
    public class MainApplication  : Application
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
            
        }
        public override void OnCreate()
        {
            base.OnCreate();
            if(Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                FirebasePushNotificationManager.DefaultNotificationChannelId = "FakeEzMobileTrading";
                FirebasePushNotificationManager.DefaultNotificationChannelName = "EzMobileTrading";

            }
            FirebasePushNotificationManager.Initialize(this, true);
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {

            };
        }
    }
}