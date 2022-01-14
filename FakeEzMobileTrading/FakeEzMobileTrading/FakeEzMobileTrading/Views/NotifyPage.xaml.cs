using FakeEzMobileTrading.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotifyPage : ContentPage
    {
        public NotifyPage()
        {
            InitializeComponent();
            BindingContext = new NotifyPageViewModel(this);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
           
        }
    }
}