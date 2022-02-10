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
    public partial class EventCalendarPage : ContentPage
    {
        public EventCalendarPage()
        {
            InitializeComponent();
            BindingContext = new EventCalendarPageViewModel();
        }
    }
}