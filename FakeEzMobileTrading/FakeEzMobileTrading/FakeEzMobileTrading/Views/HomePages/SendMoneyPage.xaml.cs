using DevExpress.XamarinForms.Navigation;
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
    public partial class SendMoneyPage : ContentPage
    {
        public SendMoneyPage()
        {
            InitializeComponent();
            BindingContext = new TransferMoneyPageViewModel(this);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing(); 
            BindingContext = new TransferMoneyPageViewModel(this);
        }

        private async void TabView_ItemHeaderTapped(object sender, DevExpress.XamarinForms.Navigation.ItemHeaderTappedEventArgs e)
        {
            var tabview = sender as TabView;
            if (e.Index == 1)
            {
                await this.DisplayAlert("Thông báo", "Quý khách chưa đăng ký dịch vụ EzFutures, vui lòng đăng ký để tiếp tục sử dụng.", "OK");
                tabview.SelectedItemIndex = 0;
            }
        }
    }
}