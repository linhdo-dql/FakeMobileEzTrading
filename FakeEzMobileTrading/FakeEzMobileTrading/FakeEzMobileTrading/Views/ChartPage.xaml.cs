using FakeEzMobileTrading.Interfaces;
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
    public partial class ChartPage : ContentPage
    {
        public ChartPage()
        {
            InitializeComponent();
            HtmlWebViewSource h = new HtmlWebViewSource();
            h.Html = "<html><body>\n" +
                       "<div class=\"tradingview-widget-container\">\n" +
                       "<div id = \"tradingview_0cdfa\" ></div>\n" +
                       "<script type = \"text/javascript\" src= \"https://s3.tradingview.com/tv.js\" ></script>\n" +
                       "<script type= \"text/javascript\">\n" +
                       "new TradingView.widget(" +
                       "{\n" +
                       "\"autosize\": true,\n" +
                       "\"symbol\": \"UPCOM:VNI\",\n" +
                       "\"interval\": \"D\",\n" +
                       "\"timezone\": \"Etc/UTC\",\n" +
                       "\"theme\": \"light\",\n" +
                       "\"style\": \"1\",\n" +
                       "\"locale\": \"vi_VN\",\n" +
                       "\"toolbar_bg\": \"#f1f3f6\",\n" +
                       "\"enable_publishing\": false,\n" +
                       "\"allow_symbol_change\": true,\n" +
                       "\"container_id\": \"tradingview_0cdfa\"\n" +
                       "}\n" +
                       ");\n" +
                       "</script>\n" +
                       "</div>\n" +
                       "</html></body>";
            webView.Source = h;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IOrientationService>().Landscape();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DependencyService.Get<IOrientationService>().Portrait();
        }
        
    }
}