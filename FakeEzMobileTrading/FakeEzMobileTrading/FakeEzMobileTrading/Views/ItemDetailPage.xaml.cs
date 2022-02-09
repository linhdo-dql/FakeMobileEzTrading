using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.ViewModels;
using FakeEzMobileTrading.Views.HomePages;
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
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(StockItem s)
        {
            InitializeComponent();
            BindingContext = new ItemDetailPageViewModel(this,s);
        }

        private async void btnSell_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActionCommandPage((sender as Button).ClassId, true));
        }

        private async void btnBuy_Clicked321(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ActionCommandPage((sender as Button).ClassId, false));
        }
    }
}