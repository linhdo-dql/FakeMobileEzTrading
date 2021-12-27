using FakeEzMobileTrading.ViewModels.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading.Views.HomePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverViewPage : ContentPage
    {
        public OverViewPage()
        {
            InitializeComponent();
            BindingContext = new OverViewPageViewModel(this, Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new OverViewPageViewModel(this, Navigation);
        }
    }

}