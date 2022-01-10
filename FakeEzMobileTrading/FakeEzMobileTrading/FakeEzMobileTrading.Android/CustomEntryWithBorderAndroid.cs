using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FakeEzMobileTrading.Droid;
using FakeEzMobileTrading.Views.CustomViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly:ExportRenderer(typeof(CustomEntryWithBorder), typeof(CustomEntryWithBorderAndroid))]
namespace FakeEzMobileTrading.Droid
{
    [Obsolete]
    internal class CustomEntryWithBorderAndroid : EntryRenderer
    {
        protected override void OnElementChanged( ElementChangedEventArgs<Entry> e )
        {
            base.OnElementChanged(e);
            if ( Control != null )
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetCornerRadius(15);
                gd.SetStroke(1, Android.Graphics.Color.LightGray);
                gd.SetColor(Android.Graphics.Color.White);
                this.Control.SetBackground(gd);
                this.Control.SetPadding(20, 0, 20, 0);

            }
        }
    }
}