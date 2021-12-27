using FakeEzMobileTrading.Models;
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
    public partial class ExchangeDetailPage : ContentPage
    {   
        public string TitlePage1 { get; set; }
        public ExchangeDetailPage(string exchange)
        {
            InitializeComponent();
            
            BindingContext = App.Exchanges.Where(item => item.ExchangeId == exchange).FirstOrDefault();
        }
    }
}