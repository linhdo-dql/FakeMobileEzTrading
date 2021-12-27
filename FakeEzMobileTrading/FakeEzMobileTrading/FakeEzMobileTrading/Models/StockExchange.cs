using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace FakeEzMobileTrading.Models
{
    public class StockExchange : BaseViewModel
    {
        private string _typeExchange;
        private string _exchangeId;
        private string _exchangeName;
        private double _exchangePrice;
        private double _exchangeMass;
        private double _exchangeValue;
        private double _exchangeUpDown;
        private double _exchangePersent;
        

        //Thỏa thận
        private double _massTT;
        private double _valueTT;
        //Phiên giao dịch
        private double _priceP1;
        private double _massP1;
        private double _valueP1;
        private double _persentP1;
        private double _updownP1;

        private double _priceP2;
        private double _massP2;
        private double _valueP2;
        private double _persentP2;
        private double _updownP2;

        private double _priceP3;
        private double _massP3;
        private double _valueP3;
        private double _persentP3;
        private double _updownP3;

        private bool _isFavourite;

        public ObservableCollection<StockItem> StockInExchanges
        {
            get { return new ObservableCollection<StockItem>(App.Items.Where(i=> i.ExchangeId == ExchangeId)); }
            
        }
        public ObservableCollection<StockItem> StockItemUps
        {
            get { return new ObservableCollection<StockItem>(StockInExchanges.Where(item => item.UpDown > 0)); }
        }
        public int AmountStockItemUp
        {
            get => StockItemUps.Count;
        }
        public ObservableCollection<StockItem> StockItemDowns
        {
            get { return new ObservableCollection<StockItem>(StockInExchanges.Where(item => item.UpDown < 0)); }
        }
        public int AmountStockItemDown
        {
            get => StockItemDowns.Count;
        }

        public int AmountStockItemEqual
        {
            get => StockInExchanges.Count - StockItemUps.Count - StockItemDowns.Count;
        }

        public string ImageUpDown { get { return ExchangeUpDown > 0 ? "ic_arrow_up.png" : "ic_arrow_down.png"; } }
        public Color UpDownColor { get { return ExchangeUpDown > 0 ? Color.FromArgb(55, 166, 71) : Color.OrangeRed; } }
        public string ImageUpDownP1 { get { return UpdownP1 > 0 ? "ic_arrow_up.png" : "ic_arrow_down.png"; } }
        public Color UpDownColorP1 { get { return UpdownP1 > 0 ? Color.FromArgb(55, 166, 71) : Color.OrangeRed; } }
        public string ImageUpDownP2 { get { return UpdownP2 > 0 ? "ic_arrow_up.png" : "ic_arrow_down.png"; } }
        public Color UpDownColorP2 { get { return UpdownP2 > 0 ? Color.FromArgb(55, 166, 71) : Color.OrangeRed; } }
        public string ImageUpDownP3 { get { return UpdownP3 > 0 ? "ic_arrow_up.png" : "ic_arrow_down.png"; } }
        public Color UpDownColorP3 { get { return UpdownP3 > 0 ? Color.FromArgb(55, 166, 71) : Color.OrangeRed; } }
        public string TypeExchange { get => _typeExchange; set { SetProperty(ref _typeExchange, value); } }
        public string ExchangeId { get => _exchangeId; set { SetProperty(ref _exchangeId, value); } }
        public string ExchangeName { get => _exchangeName; set { SetProperty(ref _exchangeName, value); } }
        public double ExchangePrice { get => _exchangePrice; set { SetProperty(ref _exchangePrice, value); } }
        public double ExchangeMass { get => _exchangeMass; set { SetProperty(ref _exchangeMass, value); } }
        public double ExchangeValue { get => _exchangeValue; set { SetProperty(ref _exchangeValue, value); } }
        public double ExchangeUpDown { get => _exchangeUpDown; set { SetProperty(ref _exchangeUpDown, value); } }
        public double ExchangePersent { get => _exchangePersent; set { SetProperty(ref _exchangePersent, value); } }
        public double MassTT { get => _massTT; set { SetProperty(ref _massTT, value); } }
        public double ValueTT { get => _valueTT; set { SetProperty(ref _valueTT, value); } }
        public double PriceP1 { get => _priceP1; set { SetProperty(ref _priceP1, value); } }
        public double MassP1 { get => _massP1; set { SetProperty(ref _massP1, value); } }
        public double ValueP1 { get => _valueP1; set { SetProperty(ref _valueP1, value); } }
        public double PersentP1 { get => _persentP1; set { SetProperty(ref _persentP1, value); } }
        public double UpdownP1 { get => _updownP1; set { SetProperty(ref _updownP1, value); } }
        public double PriceP2 { get => _priceP2; set { SetProperty(ref _priceP2, value); } }
        public double MassP2 { get => _massP2; set { SetProperty(ref _massP2, value); } }
        public double ValueP2 { get => _valueP2; set { SetProperty(ref _valueP2, value); } }
        public double PersentP2 { get => _persentP2; set { SetProperty(ref _persentP2, value); } }
        public double UpdownP2 { get => _updownP2; set { SetProperty(ref _updownP2, value); } }
        public double PriceP3 { get => _priceP3; set { SetProperty(ref _priceP3, value); } }
        public double MassP3 { get => _massP3; set { SetProperty(ref _massP3, value); } }
        public double ValueP3 { get => _valueP3; set { SetProperty(ref _valueP3, value); } }
        public double PersentP3 { get => _persentP3; set { SetProperty(ref _persentP3, value); } }
        public double UpdownP3 { get => _updownP3; set { SetProperty(ref _updownP3, value); } }
        public bool IsFavourite { 
            get => _isFavourite; 
            set 
            {
                IconFavourite = value ? "ic_fillstar.png" : "ic_emptystar.png";
                SetProperty(ref _isFavourite, value);
            }
        }
        private string _iconFavourite = "ic_emptystar.png";
        public string IconFavourite
        {
            get { return _iconFavourite; }
            set { SetProperty(ref _iconFavourite, value); }
        }
        public bool _iconFavouriteVisible = false;
        public string ExchangeChart
        {
            get
            {
                return "<html><body>\n" +
                       "<div class=\"tradingview-widget-container\">\n" +
                       "<div id = \"tradingview_0cdfa\" ></div>\n" +
                       "<script type = \"text/javascript\" src= \"https://s3.tradingview.com/tv.js\" ></script>\n" +
                       "<script type= \"text/javascript\">\n" +
                       "new TradingView.widget(" +
                       "{\n" +
                       "\"autosize\": true,\n" +
                       "\"symbol\": \""+ExchangeName+"\",\n" +
                       "\"interval\": \"D\",\n" +
                       "\"timezone\": \"Etc/UTC\",\n" +
                       "\"theme\": \"light\",\n" +
                       "\"style\": \"1\",\n" +
                       "\"locale\": \"vi_VN\",\n" +
                       "\"toolbar_bg\": \"#f1f3f6\",\n" +
                       "\"enable_publishing\": false,\n" +
                       "\"allow_symbol_change\": false,\n" +
                       "\"container_id\": \"tradingview_0cdfa\"\n" +
                       "}\n" +
                       ");\n" +
                       "</script>\n" +
                       "</div>\n" +
                       "</html></body>";
            }
        }
    }
}
