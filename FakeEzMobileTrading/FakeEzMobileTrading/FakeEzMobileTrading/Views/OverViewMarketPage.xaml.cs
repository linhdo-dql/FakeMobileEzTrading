using FakeEzMobileTrading.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverViewMarketPage : ContentPage
    {
        public OverViewMarketPage()
        {
            InitializeComponent();
            Preferences.Set("TypeTable", 0);
            BindingContext = new OverViewMarketPageViewModel(this,Navigation);
        }
    }
}