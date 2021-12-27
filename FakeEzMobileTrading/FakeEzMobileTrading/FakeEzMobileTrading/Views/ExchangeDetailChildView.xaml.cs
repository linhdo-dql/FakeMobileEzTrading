using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExchangeDetailChildView : ContentPage
    {
        public string ExchangeId { get; set; }
        public ExchangeDetailChildView()
        {
            InitializeComponent();
            BindingContext = this;
            ExchangeId = 
                "<html><body>\n"+
                "<!-- TradingView Widget BEGIN -->\n" +
                "<div class=\"tradingview-widget-container\">\n" +
                "  <div id=\"tradingview_357eb\"></div>\n" +
                "  <script type=\"text/javascript\" src=\"https://s3.tradingview.com/tv.js\"></script>\n" +
                "  <script type=\"text/javascript\">\n" +
                "  new TradingView.widget(\n" +
                "  {\n" +
                "  \"autosize\": true,\n" +
                "  \"symbol\": \"HOSE:VCB\",\n" +
                "  \"timezone\": \"Etc/UTC\",\n" +
                "  \"theme\": \"light\",\n" +
                "  \"style\": \"1\",\n" +
                "  \"locale\": \"vn\",\n" +
                "  \"toolbar_bg\": \"#f1f3f6\",\n" +
                "  \"enable_publishing\": false,\n" +
                "  \"hide_side_toolbar\": false,\n" +
                "  \"save_image\": false,\n" +
                "  \"studies\": [\n" +
                "    \"BB@tv-basicstudies\",\n" +
                "    \"RSI@tv-basicstudies\",\n" +
                "    \"StochasticRSI@tv-basicstudies\"\n" +
                "  ],\n" +
                "  \"container_id\": \"tradingview_357eb\"\n" +
                "}\n" +
                "  );\n" +
                "  </script>\n" +
                "</div>\n" +
                "</body></html>";


            var html = new HtmlWebViewSource();
            html.Html = ExchangeId;
            weba.Source = html;

        }
    }
}