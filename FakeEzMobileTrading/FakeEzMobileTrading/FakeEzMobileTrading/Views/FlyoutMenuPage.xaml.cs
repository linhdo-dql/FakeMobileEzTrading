using FakeEzMobileTrading.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenuPage : ContentPage
    {
        public FlyoutMenuPage()
        {
            InitializeComponent();
            BindingContext = new FlyoutMenuViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            scrollView.ScrollToAsync(0, 0, false);

        }
    }
}