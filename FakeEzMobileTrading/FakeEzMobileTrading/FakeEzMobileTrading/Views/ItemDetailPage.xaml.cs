using FakeEzMobileTrading.Models;
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
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(StockItem s)
        {
            InitializeComponent();
            BindingContext = new ItemDetailPageViewModel(this,s);
        }
    }
}