using FakeEzMobileTrading.Interfaces;
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
    public partial class FormSendPage : ContentPage
    {
        public FormSendPage()
        {
            InitializeComponent();
            BindingContext = new FormSendPageViewModel(this);
        }

        protected override void OnAppearing()
        {
            
        }
    }
}