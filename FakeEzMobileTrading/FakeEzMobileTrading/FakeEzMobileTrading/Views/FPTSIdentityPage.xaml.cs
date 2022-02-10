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
    public partial class FPTSIdentityPage : ContentPage
    {
        public FPTSIdentityPage()
        {
            InitializeComponent();
            BindingContext = new FPTSsIdentityPageViewModel();
        }
    }
}