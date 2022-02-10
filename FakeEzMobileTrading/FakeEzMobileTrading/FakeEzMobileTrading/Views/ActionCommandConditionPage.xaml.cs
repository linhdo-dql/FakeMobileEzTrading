using FakeEzMobileTrading.ViewModels;
using FakeEzMobileTrading.ViewModels.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionCommandConditionPage : ContentPage
    {
        public ActionCommandConditionPage()
        {
            InitializeComponent();
            BindingContext = new ActionCommandConditionPageViewModel(this);


        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ActionCommandConditionPageViewModel(this);
            Device.StartTimer(new TimeSpan(0, 0, 5), () =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await scrollView.ScrollToAsync(lblStockName, ScrollToPosition.End, true);// Move to right Element  
                    await Task.Delay(1000);                          //1 Sec interval time  
                    await scrollView.ScrollToAsync(lblStockName, ScrollToPosition.Start, true);// Move to left Element  
                });
                return true;
            });


        }

       
    }
}