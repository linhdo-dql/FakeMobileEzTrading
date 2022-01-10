using FakeEzMobileTrading.Interfaces;
using FakeEzMobileTrading.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FakeEzMobileTrading
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage(string pageId)
        {
            InitializeComponent();
            if (!Preferences.ContainsKey("CurrentFollowList"))
            {
                Preferences.Set("CurrentFollowList", "Newbie");
            }
            if(pageId == "")
            {
                Detail = new NavigationPage(new HomePage(0));
            }
            else
            {
                switch(pageId)
                {
                    case "cc": Detail = new NavigationPage(new ActionCommandConditionPage()); break;
                }
            }
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IOrientationService>().Portrait();
        }

    }
}
