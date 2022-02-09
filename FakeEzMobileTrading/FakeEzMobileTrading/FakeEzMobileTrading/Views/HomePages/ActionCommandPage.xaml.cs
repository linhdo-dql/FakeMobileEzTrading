
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

namespace FakeEzMobileTrading.Views.HomePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ActionCommandPage : ContentPage
    {
        private string _currentId;
        private bool _type;
        public ActionCommandPage(string currentId, bool type)
        {
            InitializeComponent();
            _currentId = currentId;
            _type = type;
            BindingContext = new ActionCommandPageViewModel(this, _currentId, _type);


        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new ActionCommandPageViewModel(this, _currentId, _type);
            Device.StartTimer(new TimeSpan(0, 0, 5), ()=>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await scrollView.ScrollToAsync(lblStockName, ScrollToPosition.End, true);// Move to down Element  
                    await Task.Delay(1000);                          //1 Sec interval time  
                    await scrollView.ScrollToAsync(lblStockName, ScrollToPosition.Start, true);// Move to down Element  
                });
                return true;
            });
           
                                                         
        }

       
    }
}