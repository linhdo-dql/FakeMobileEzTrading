using FakeEzMobileTrading.Interfaces;
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
    public partial class SearchPage : ContentPage
    {
        private int _type;
        public SearchPage(int type)
        {
            InitializeComponent();
            BindingContext = new SearchPageViewModel(this, type);
            _type = type;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new SearchPageViewModel(this, _type);
            
            if(_type == 1 || _type == 3)
            {
                DependencyService.Get<IOrientationService>().Portrait();
            }
            else
            {
                DependencyService.Get<IOrientationService>().Landscape();
            }
        }
    }
}