using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
namespace FakeEzMobileTrading.Models
{
    public class StockItem : BaseViewModel
    {
        /// <summary>
        /// Stock
        /// </summary>
        private string _stockId;
        private string _stockName;
        private double _priceMedium;
        private double _priceCeiling;
        private double _priceFloor;
        private double _priceB1;
        private double _priceB2;
        private double _priceB3;
        private double _priceB1X;
        private double _priceB2X;
        private double _priceB3X;
        private double _priceS1;
        private double _priceS2;
        private double _priceS3;
        private double _priceS1X;
        private double _priceS2X;
        private double _priceS3X;
        private double _priceGood;
        private double _priceGoodX;
        private double _priceMax;
        private double _priceMin;
        private double _totalMass;
        private double _priceOpen;
        private double _priceClose;
        private double _foreignB;
        private double _foreignS;
        //
        private string _exchangeId;
        private string _floorId;
        //Document
        private double _priceMax52T;
        private double _priceMin52T;
        private double _mass30d;
        private double _pb;
        private double _persentForeign;
        private double _money;
        private double _massDNY;
        private double _massDLH;
        private double _moneyValue;
        //
        private double _persentB;
        private double _persentS;
        private bool _showHidePersent = false;
        //
        private int _index;
        //
        public Color Green = Color.LimeGreen;
        public Color Red = Color.Red;
        public Color Pink = Color.DeepPink;
        public Color Blue = Color.DeepSkyBlue;
        public Color Yellow = Color.Yellow;
        public Color White = Color.White;
        public Color Black = Color.Black;
        //
        public Color _textColorInBoard;
        //
        private double _massAllowOwn;
        private double _massOwning;
        private double _massStillAllowB;
        private double _persentForeignOwn;
        private double _foreignBYTD;
        private double _foreignBMTD;
        private string _dateUpdate;
        //
        private bool _refreshPrice;
        public string StockId
        {
            get { return _stockId; }
            set { SetProperty(ref _stockId, value); }
        }
        public string StockName
        {
            get { return _stockName; }
            set { SetProperty(ref _stockName, value); }
        }
        public double PriceMedium
        {
            get { return _priceMedium; }
            set { SetProperty(ref _priceMedium, value); }
        }
        public double PriceCeiling
        {
            get { return _priceCeiling; }
            set { SetProperty(ref _priceCeiling, value); }
        }
        public double PriceFloor
        {
            get { return _priceFloor; }
            set { SetProperty(ref _priceFloor, value); }
        }
        public double PriceB1
        {
            get { return _priceB1; }
            set
            {
                PriceB1Color = SetColor2(value, PriceMedium, PriceCeiling, PriceFloor);
                SetProperty(ref _priceB1, value);
            }
        }
        public double PriceB1X
        {
            get { return _priceB1X; }
            set { SetProperty(ref _priceB1X, value); }
        }
        public double PriceB2
        {
            get { return _priceB2; }
            set
            {
                PriceB2Color = SetColor2(value, PriceMedium, PriceCeiling, PriceFloor);
                SetProperty(ref _priceB2, value);
            }
        }
        public double PriceB2X
        {
            get { return _priceB2X; }
            set
            {
                SetProperty(ref _priceB2X, value);
            }
        }
        public double PriceB3
        {
            get { return _priceB3; }
            set
            {
                PriceB3Color = SetColor2(value, PriceMedium, PriceCeiling, PriceFloor);
                SetProperty(ref _priceB3, value);
            }
        }
        public double PriceB3X
        {
            get { return _priceB3X; }
            set { SetProperty(ref _priceB3X, value); }
        }
        public double PriceS1
        {
            get { return _priceS1; }
            set
            {
                PriceS1Color = SetColor2(value, PriceMedium, PriceCeiling, PriceFloor);
                SetProperty(ref _priceS1, value);
            }
        }
        public double PriceS1X
        {
            get { return _priceS1X; }
            set
            {
                SetProperty(ref _priceS1X, value);
            }
        }
        public double PriceS2
        {
            get { return _priceS2; }
            set
            {
                PriceS2Color = SetColor2(value, PriceMedium, PriceCeiling, PriceFloor);
                SetProperty(ref _priceS2, value);
            }
        }
        public double PriceS2X
        {
            get { return _priceS2X; }
            set { SetProperty(ref _priceS2X, value); }
        }
        public double PriceS3
        {
            get { return _priceS3; }
            set
            {
                PriceS3Color = SetColor2(value, PriceMedium, PriceCeiling, PriceFloor);
                SetProperty(ref _priceS3, value);
            }
        }
        public double PriceS3X
        {
            get { return _priceS3X; }
            set { SetProperty(ref _priceS3X, value); }
        }
        public double PriceGood
        {
            get { return _priceGood; }
            set
            {
                if (value >= PriceMax)
                {
                    PriceMax = value;
                }
                if (value <= PriceMin)
                {
                    PriceMin = value;
                }
                UpDown = value - PriceMedium;
                PriceGoodColor = SetColor2(value, PriceMedium, PriceCeiling, PriceFloor);
                BgIdColor = SetColor2(value, PriceMedium, PriceCeiling, PriceFloor);
                SetProperty(ref _priceGood, value);
            }
        }
        public double PriceGoodX
        {
            get { return _priceGoodX; }
            set
            {
                SetProperty(ref _priceGoodX, value);
            }
        }
        public double PriceMax
        {
            get { return _priceMax; }
            set { SetProperty(ref _priceMax, value); }
        }
        public double PriceMin
        {
            get { return _priceMin; }
            set { SetProperty(ref _priceMin, value); }
        }
        public double PriceOpen
        {
            get { return _priceOpen; }
            set { SetProperty(ref _priceOpen, value); }
        }
        public double PriceClose
        {
            get { return _priceClose; }
            set { SetProperty(ref _priceClose, value); }
        }
        public double TotalMass
        {
            get { return _totalMass; }
            set { SetProperty(ref _totalMass, value); }
        }
        public double ForeignB
        {
            get { return _foreignB; }
            set { SetProperty(ref _foreignB, value); }
        }
        public double ForeignS
        {
            get { return _foreignS; }
            set { SetProperty(ref _foreignS, value); }
        }
        public double Value
        {
            get { return (PriceGood * TotalMass) / 10000000; }
        }
        private double _upDown;
        public double UpDown
        {
            get
            {
                return _upDown;
            }
            set
            {
                Persent = (value / PriceMedium) * 100000;
                UpDownSource = value > 0 ? "ic_arrow_up.png" : (value < 0 ? "ic_arrow_down.png" : "ic_arrow_equal.png");
                SetProperty(ref _upDown, value);
            }
        }
        private Color _upDownColor;
        public Color UpDownColor
        {
            get
            {
                return _upDownColor;
            }
            set
            {
                PersentColor = value;
                SetProperty(ref _upDownColor, value);
            }
        }
        private double _persent;
        public double Persent
        {
            get
            {
                return _persent;
            }
            set
            {
                SetProperty(ref _persent, value);
            }
        }
        private Color _persentColor;
        public Color PersentColor
        {
            get { return _persentColor; }
            set { SetProperty(ref _persentColor, value); }
        }
        private Color _priceB1Color = Color.White;
        public Color PriceB1Color
        {
            get { return _priceB1Color; }
            set
            {
                SetProperty(ref _priceB1Color, value);
            }
        }
        private Color _priceB2Color;
        public Color PriceB2Color
        {
            get { return _priceB2Color; }
            set
            {
                SetProperty(ref _priceB2Color, value);
            }
        }
        private Color _priceB3Color;
        public Color PriceB3Color
        {
            get { return _priceB3Color; }
            set
            {
                SetProperty(ref _priceB3Color, value);
            }
        }
        private Color _priceS1Color = Color.White;
        public Color PriceS1Color
        {
            get { return _priceS1Color; }
            set
            {
                SetProperty(ref _priceS1Color, value);
            }
        }
        private Color _priceS2Color;
        public Color PriceS2Color
        {
            get { return _priceS2Color; }
            set
            {
                SetProperty(ref _priceS2Color, value);
            }
        }
        private Color _priceS3Color;
        public Color PriceS3Color
        {
            get { return _priceS3Color; }
            set
            {
                SetProperty(ref _priceS3Color, value);
            }
        }
        private Color _priceGoodColor = Color.White;
        public Color PriceGoodColor
        {
            get { return _priceGoodColor; }
            set
            {
                UpDownColor = value;
                SetProperty(ref _priceGoodColor, value);
            }
        }
        private Color _bgColor = Color.FromHex("#444444");
        public Color BgColor
        {
            get { return _bgColor; }
            set { SetProperty(ref _bgColor, value); }
        }
        private Color _bgB1Color = Color.FromHex("#222222");
        public Color BgB1Color
        {
            get { return _bgB1Color; }
            set { SetProperty(ref _bgB1Color, value); }
        }
        private Color _bgB2Color = Color.FromHex("#222222");
        public Color BgB2Color
        {
            get { return _bgB2Color; }
            set { SetProperty(ref _bgB2Color, value); }
        }
        private Color _bgB3Color = Color.FromHex("#222222");
        public Color BgB3Color
        {
            get { return _bgB3Color; }
            set { SetProperty(ref _bgB3Color, value); }
        }
        private Color _bgS1Color = Color.FromHex("#222222");
        public Color BgS1Color
        {
            get { return _bgS1Color; }
            set { SetProperty(ref _bgS1Color, value); }
        }
        private Color _bgS2Color = Color.FromHex("#222222");
        public Color BgS2Color
        {
            get { return _bgS2Color; }
            set { SetProperty(ref _bgS2Color, value); }
        }
        private Color _bgS3Color = Color.FromHex("#222222");
        public Color BgS3Color
        {
            get { return _bgS3Color; }
            set { SetProperty(ref _bgS3Color, value); }
        }
        private Color _bgIdColor = Color.FromHex("#444444");
        public Color BgIdColor
        {
            get { return _bgIdColor; }
            set { SetProperty(ref _bgIdColor, value); }
        }
        private int _timeRefresh;
        public int TimeRefresh { get { return _timeRefresh; } set { if (value != 0) RefreshPrices(value); SetProperty(ref _timeRefresh, value); } }
        private int _timeRefreshB1;
        public int TimeRefreshB1 { get { return _timeRefreshB1; } set { if (value != 0) RefreshPriceB1s(value); SetProperty(ref _timeRefreshB1, value); } }
        private int _timeRefreshB2;
        public int TimeRefreshB2 { get { return _timeRefreshB2; } set { if (value != 0) RefreshPriceB2s(value); SetProperty(ref _timeRefreshB2, value); } }
        private int _timeRefreshB3;
        public int TimeRefreshB3 { get { return _timeRefreshB3; } set { if (value != 0) RefreshPriceB3s(value); SetProperty(ref _timeRefreshB3, value); } }
        private int _timeRefreshS1;
        public int TimeRefreshS1 { get { return _timeRefreshS1; } set { if (value != 0) RefreshPriceS1s(value); SetProperty(ref _timeRefreshS1, value); } }
        private int _timeRefreshS2;
        public int TimeRefreshS2 { get { return _timeRefreshS2; } set { if (value != 0) RefreshPriceS2s(value); SetProperty(ref _timeRefreshS2, value); } }
        private int _timeRefreshS3;
        public int TimeRefreshS3 { get { return _timeRefreshS3; } set { if (value != 0) RefreshPriceS3s(value); SetProperty(ref _timeRefreshS3, value); } }
        public Color PriceMaxColor
        {
            get { return SetColor2(PriceMax, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color PriceMinColor
        {
            get { return SetColor2(PriceMin, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color PriceOpenColor
        {
            get { return SetColor2(PriceOpen, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color ColorDefault1
        {
            get { return White; }
        }
        public Color ColorDefault2
        {
            get { return Black; }
        }
        public bool ShowHideSwipeView
        {
            get { return _showHidePersent; }
            set { SetProperty(ref _showHidePersent, value); }
        }
        public string ExchangeId { get => _exchangeId; set { SetProperty(ref _exchangeId, value); } }
        public double PriceMax52T { get => _priceMax52T; set { SetProperty(ref _priceMax52T, value); } }
        public double PriceMin52T { get => _priceMin52T; set { SetProperty(ref _priceMin52T, value); } }
        public double Mass30d { get => _mass30d; set { SetProperty(ref _mass30d, value); } }
        public double Esp { get => _mass30d; set { SetProperty(ref _mass30d, value); } }
        public double Pb { get => _pb; set { SetProperty(ref _pb, value); } }
        public double PersentForeign { get => _persentForeign; set { SetProperty(ref _persentForeign, value); } }
        public double Money { get => _money; set { SetProperty(ref _money, value); } }
        public double MassDNY { get => _massDNY; set { SetProperty(ref _massDNY, value); } }
        public double MassDLH { get => _massDLH; set { SetProperty(ref _massDLH, value); } }
        public double MoneyValue { get => _moneyValue; set { SetProperty(ref _moneyValue, value); } }
        public double PersentB { get => _persentB; set { SetProperty(ref _persentB, value); } }
        public double PersentS { get => _persentS; set { SetProperty(ref _persentS, value); } }
        public Color TextColorInBoard { get => UpDown < 0 || PriceGood == PriceCeiling ? Color.White : Color.Black; }
        public int Index { get => _index; set { SetProperty(ref _index, value); } }
        public string FloorId { get => _floorId; set { SetProperty(ref _floorId, value); } }
        public Color SetColor2(double value, double priceMedium, double priceCeiling, double priceFloor)
        {
            if (value == 0)
            {
                return White;
            }
            if (value == priceMedium)
            {
                return Yellow;
            }
            if (value == priceCeiling)
            {
                return Pink;
            }
            if (value == priceFloor)
            {
                return Blue;
            }
            if (value > priceMedium)
            {
                return Green;
            }
            if (value < priceMedium)
            {
                return Red;
            }
            else
            {
                return White;
            }
        }
        private string _upDownResource;
        public string UpDownSource { get => _upDownResource; set { SetProperty(ref _upDownResource, value); } }
        public string StockItemChart
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
                       "\"symbol\": \"" + StockId + "\",\n" +
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
        public double MassAllowOwn { get => _massAllowOwn; set { SetProperty(ref _massAllowOwn, value); } }
        public double MassOwning { get => _massOwning; set { SetProperty(ref _massOwning, value); } }
        public double MassStillAllowB { get => _massStillAllowB; set { SetProperty(ref _massStillAllowB, value); } }
        public double PersentForeignOwn { get => _persentForeignOwn; set { SetProperty(ref _persentForeignOwn, value); } }
        public double ForeignBYTD { get => _foreignBYTD; set { SetProperty(ref _foreignBYTD, value); } }
        public double ForeignBMTD { get => _foreignBMTD; set { SetProperty(ref _foreignBMTD, value); } }
        public string DateUpdate { get => _dateUpdate; set { SetProperty(ref _dateUpdate, value); } }
        public bool RefeshPrice { get => _refreshPrice; set { SetProperty(ref _refreshPrice, value); } }
        public void RefreshPrices(int refreshTime)
        {
            Device.StartTimer(new TimeSpan(0, 0, refreshTime), () =>
            {
                double[] arr = new double[] { 10, -10, 20, -20, 30, -30, 40, -40, 50, -50, 60, -60, 70, -70, 80, -80, 90, -90, 100, 200, 300, 400, 500, 600, 700, 800, 900, -100, -200, -300, -400, -500, -600, -700, -800, -900, 1000, -1000 };
                double random = arr[new Random().Next(arr.Length)];
                Device.BeginInvokeOnMainThread(() =>
                {
                    int typeTable = Preferences.Get("TypeTable", 0);
                    if (typeTable == 1)
                    {
                        if (PriceGood == PriceCeiling)
                        {
                            PriceS3X = 0;
                            PriceS3 = 0;
                            PriceS2X = 0;
                            PriceS2 = 0;
                            PriceS1X = 0;
                            PriceS1 = 0;
                            BgColor = Color.FromHex("#444444");
                            return;
                        }
                        if (PriceGood == PriceFloor)
                        {
                            PriceB3X = 0;
                            PriceB3 = 0;
                            PriceB2X = 0;
                            PriceB2 = 0;
                            PriceB1X = 0;
                            PriceB1 = 0;
                            BgColor = Color.FromHex("#444444");
                            return;
                        }
                        PriceGoodColor = SetColor2(PriceGood, PriceMedium, PriceCeiling, PriceFloor);
                        BgColor = Color.FromHex("#444444");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            int rdT = new Random().Next(0, 1);
                            double tmp = PriceGood + random;
                            if (tmp >= PriceCeiling)
                            {
                                PriceGood = PriceCeiling;
                            }
                            else if (tmp <= PriceFloor)
                            {
                                PriceGood = PriceFloor;
                            }
                            else
                            {
                                PriceGood = tmp;
                                BgColor = PriceGoodColor;
                                PriceGoodColor = Color.White;
                            }
                            return false;
                        });
                    }
                    else
                    {
                        if (PriceGood == PriceCeiling)
                        {
                            PriceS3X = 0;
                            PriceS3 = 0;
                            PriceS2X = 0;
                            PriceS2 = 0;
                            PriceS1X = 0;
                            PriceS1 = 0;
                            BgColor = Color.FromHex("#FFFFFF");
                            return;
                        }
                        if (PriceGood == PriceFloor)
                        {
                            PriceB3X = 0;
                            PriceB3 = 0;
                            PriceB2X = 0;
                            PriceB2 = 0;
                            PriceB1X = 0;
                            PriceB1 = 0;
                            BgColor = Color.FromHex("#FFFFFF");
                            return;
                        }
                        PriceGoodColor = SetColor2(PriceGood, PriceMedium, PriceCeiling, PriceFloor);
                        BgColor = Color.FromHex("#FFFFFF");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            double tmp = PriceGood + random;
                            if (tmp >= PriceCeiling)
                            {
                                PriceGood = PriceCeiling;
                            }
                            else if (tmp <= PriceFloor)
                            {
                                PriceGood = PriceFloor;
                            }
                            else
                            {
                                PriceGood = tmp;
                                BgColor = PriceGoodColor;
                                PriceGoodColor = Color.White;
                            }
                            return false;
                        });
                    }
                });
                return true;
            });
        }
        public void RefreshPrice3s(int refreshTime, double price, Color textColor, Color bgColor, double priceX)
        {
            Device.StartTimer(new TimeSpan(0, 0, refreshTime), () =>
            {
                double[] arr = new double[] { 10, -10 };
                double random = arr[new Random().Next(arr.Length)];
                Device.BeginInvokeOnMainThread(() =>
                {
                    textColor = SetColor2(price, PriceMedium, PriceCeiling, PriceFloor);
                    bgColor = Color.FromHex("#444444");
                    int typeTable = Preferences.Get("TypeTable", 0);
                    if (typeTable == 1)
                    {
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            priceX = priceX + random;
                            bgColor = textColor;
                            textColor = Color.White;
                            return false;
                        });
                    }
                });
                return true;
            });
        }
        public void RefreshPriceB1s(int refreshTime)
        {
            Device.StartTimer(new TimeSpan(0, 0, refreshTime), () =>
            {
                double[] arr = new double[] { 10, -10, 20, -20, 30, -30, 40, -40, 50, -50, 60, -60, 70, -70, 80, -80, 90, -90, 100, -100 };
                double random = arr[new Random().Next(arr.Length)];
                Device.BeginInvokeOnMainThread(() =>
                {

                    if (PriceB1 <= 0)
                    {
                        BgB1Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceB1 == PriceCeiling || PriceB1 == 0)
                    {
                        BgB1Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceB1 == PriceFloor)
                    {
                        return;
                    }
                    int typeTable = Preferences.Get("TypeTable", 0);
                    if (typeTable == 1)
                    {
                        PriceB1Color = SetColor2(PriceB1, PriceMedium, PriceCeiling, PriceFloor);
                        BgB1Color = Color.FromHex("#222222");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            double tmp = PriceB1 + random;
                            if (tmp >= PriceCeiling)
                            {
                                PriceB1 = PriceCeiling;
                            }
                            else if (tmp <= PriceFloor)
                            {
                                PriceB1 = PriceFloor;
                            }
                            else
                            {
                                PriceB1 = tmp;
                                BgB1Color = PriceB1Color;
                                PriceB1Color = Color.White;
                            }
                            return false;
                        });
                    }
                    else
                    {
                        PriceB1Color = SetColor2(PriceB1, PriceMedium, PriceCeiling, PriceFloor);
                        BgB1Color = Color.FromHex("#FFFFFF");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            double tmp = PriceB1 + random;
                            if (tmp >= PriceCeiling)
                            {
                                PriceB1 = PriceCeiling;
                            }
                            else if (tmp <= PriceFloor)
                            {
                                PriceB1 = PriceFloor;
                            }
                            else
                            {
                                PriceB1 = tmp;
                                BgB1Color = PriceB1Color;
                                PriceB1Color = Color.White;
                            }
                            return false;
                        });
                    }
                });
                return true;
            });
        }
        public void RefreshPriceB2s(int refreshTime)
        {
            Device.StartTimer(new TimeSpan(0, 0, refreshTime), () =>
            {
                double[] arr = new double[] { 10, -10, 20, -20, 30, -30, 40, -40, 50, -50, 60, -60, 70, -70, 80, -80, 90, -90, 100, -100 };
                double random = arr[new Random().Next(arr.Length)];
                Device.BeginInvokeOnMainThread(() =>
                {

                    if (PriceB2 <= 0)
                    {
                        BgB2Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceB1 == PriceCeiling || PriceB1 == 0)
                    {
                        BgB2Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceB1 == PriceFloor)
                    {
                        return;
                    }
                    int typeTable = Preferences.Get("TypeTable", 0);
                    if (typeTable == 1)
                    {
                        PriceB2Color = SetColor2(PriceB2, PriceMedium, PriceCeiling, PriceFloor);
                        BgB2Color = Color.FromHex("#222222");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            double tmp = PriceB2 + random;
                            if (tmp + 100 <= PriceB1)
                            {
                                PriceB2 = tmp;
                                BgB2Color = PriceB2Color;
                                PriceB2Color = Color.White;
                            }
                            else
                            {
                                PriceB2 = PriceB1 - 100;
                            }
                            return false;
                        });
                    }
                    else
                    {
                        PriceB2Color = SetColor2(PriceB2, PriceMedium, PriceCeiling, PriceFloor);
                        BgB2Color = Color.FromHex("#FFFFFF");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            double tmp = PriceB2 + random;
                            if (tmp + 100 <= PriceB1)
                            {
                                PriceB2 = tmp;
                                BgB2Color = PriceB2Color;
                                PriceB2Color = Color.White;
                            }
                            else
                            {
                                PriceB2 = PriceB1 - 100;
                            }
                            return false;
                        });
                    }
                });
                return true;
            });
        }
        public void RefreshPriceB3s(int refreshTime)
        {
            Device.StartTimer(new TimeSpan(0, 0, refreshTime), () =>
            {
                double[] arr = new double[] { 10, -10, 20, -20, 30, -30, 40, -40, 50, -50, 60, -60, 70, -70, 80, -80, 90, -90, 100, -100 };
                double random = arr[new Random().Next(arr.Length)];
                Device.BeginInvokeOnMainThread(() =>
                {
                    PriceB3Color = SetColor2(PriceB3, PriceMedium, PriceCeiling, PriceFloor);
                    BgB3Color = Color.FromHex("#222222");
                    if (PriceB3 <= 0)
                    {
                        BgB3Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceB1 == PriceCeiling || PriceB1 == 0)
                    {
                        BgB3Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceB1 == PriceFloor)
                    {
                        return;
                    }
                    int typeTable = Preferences.Get("TypeTable", 0);
                    if (typeTable == 1)
                    {
                        PriceB3Color = SetColor2(PriceB3, PriceMedium, PriceCeiling, PriceFloor);
                        BgB3Color = Color.FromHex("#222222");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            double tmp = PriceB3 + random;
                            if (tmp + 100 <= PriceB2)
                            {
                                PriceB3 = tmp;
                                BgB3Color = PriceB3Color;
                                PriceB3Color = Color.White;
                            }
                            else
                            {
                                PriceB3 = PriceB2 - 100;
                            }
                            return false;
                        });
                    }
                    else
                    {
                        PriceB3Color = SetColor2(PriceB3, PriceMedium, PriceCeiling, PriceFloor);
                        BgB3Color = Color.FromHex("#FFFFFF");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            double tmp = PriceB3 + random;
                            if (tmp + 100 <= PriceB2)
                            {
                                PriceB3 = tmp;
                                BgB3Color = PriceB3Color;
                                PriceB3Color = Color.White;
                            }
                            else
                            {
                                PriceB3 = PriceB2 - 100;
                            }
                            return false;
                        });
                    }
                });
                return true;
            });
        }
        public void RefreshPriceS1s(int refreshTime)
        {
            Device.StartTimer(new TimeSpan(0, 0, refreshTime), () =>
            {
                double[] arr = new double[] { 10, -10, 20, -20, 30, -30, 40, -40, 50, -50, 60, -60, 70, -70, 80, -80, 90, -90, 100, -100 };
                double random = arr[new Random().Next(arr.Length)];
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (PriceS1 <= 0)
                    {
                        BgS1Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceS1 == PriceCeiling || PriceS1 == 0)
                    {
                        BgS1Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceS1 == PriceFloor)
                    {
                        return;
                    }
                    int typeTable = Preferences.Get("TypeTable", 0);
                    if (typeTable == 1)
                    {
                        PriceS1Color = SetColor2(PriceS1, PriceMedium, PriceCeiling, PriceFloor);
                        BgS1Color = Color.FromHex("#222222");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            double tmp = PriceS1 + random;
                            if (tmp >= PriceCeiling)
                            {
                                PriceS1 = PriceCeiling;
                            }
                            else if (tmp <= PriceFloor)
                            {
                                PriceS1 = PriceFloor;
                            }
                            else
                            {
                                PriceS1 = tmp;
                                BgS1Color = PriceS1Color;
                                PriceS1Color = Color.White;
                            }
                            return false;
                        });
                    }
                    else
                    {
                        PriceS1Color = SetColor2(PriceS1, PriceMedium, PriceCeiling, PriceFloor);
                        BgS1Color = Color.FromHex("#FFFFFF");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            double tmp = PriceS1 + random;
                            if (tmp >= PriceCeiling)
                            {
                                PriceS1 = PriceCeiling;
                            }
                            else if (tmp <= PriceFloor)
                            {
                                PriceS1 = PriceFloor;
                            }
                            else
                            {
                                PriceS1 = tmp;
                                BgS1Color = PriceS1Color;
                                PriceS1Color = Color.White;
                            }
                            return false;
                        });
                    }
                });
                return true;
            });
        }
        public void RefreshPriceS2s(int refreshTime)
        {
            Device.StartTimer(new TimeSpan(0, 0, refreshTime), () =>
            {
                double[] arr = new double[] { 10, -10, 20, -20, 30, -30, 40, -40, 50, -50, 60, -60, 70, -70, 80, -80, 90, -90, 100, -100 };
                double random = arr[new Random().Next(arr.Length)];
                Device.BeginInvokeOnMainThread(() =>
                {

                    if (PriceS2 <= 0)
                    {
                        BgS1Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceS1 == PriceCeiling || PriceS1 == 0)
                    {
                        BgS2Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceS1 == PriceFloor)
                    {
                        return;
                    }
                    int typeTable = Preferences.Get("TypeTable", 0);
                    if (typeTable == 1)
                    {
                        PriceS2Color = SetColor2(PriceS2, PriceMedium, PriceCeiling, PriceFloor);
                        BgS2Color = Color.FromHex("#222222");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            double tmp = PriceS2 + random;
                            if (tmp - 100 >= PriceS1)
                            {
                                PriceS2 = tmp;
                                BgS2Color = PriceS2Color;
                                PriceS2Color = Color.White;
                            }
                            else
                            {
                                PriceS2 = PriceS1 + 100;
                            }
                            return false;
                        });
                    }
                    else
                    {
                        PriceS2Color = SetColor2(PriceS2, PriceMedium, PriceCeiling, PriceFloor);
                        BgS2Color = Color.FromHex("#FFFFFF");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {
                            double tmp = PriceS2 + random;
                            if (tmp - 100 >= PriceS1)
                            {
                                PriceS2 = tmp;
                                BgS2Color = PriceS2Color;
                                PriceS2Color = Color.White;
                            }
                            else
                            {
                                PriceS2 = PriceS1 + 100;
                            }
                            return false;
                        });
                    }
                });
                return true;
            });
        }
        public void RefreshPriceS3s(int refreshTime)
        {
            Device.StartTimer(new TimeSpan(0, 0, refreshTime), () =>
            {
                double[] arr = new double[] { 10, -10, 20, -20, 30, -30, 40, -40, 50, -50, 60, -60, 70, -70, 80, -80, 90, -90, 100, -100 };
                double random = arr[new Random().Next(arr.Length)];
                Device.BeginInvokeOnMainThread(() =>
                {

                    if (PriceS3 <= 0)
                    {
                        BgS1Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceS1 == PriceCeiling || PriceS1 == 0)
                    {
                        BgS3Color = Color.FromHex("#222222");
                        return;
                    }
                    if (PriceS1 == PriceFloor)
                    {
                        return;
                    }
                    int typeTable = Preferences.Get("TypeTable", 0);
                    if (typeTable == 1)
                    {
                        PriceS3Color = SetColor2(PriceS3, PriceMedium, PriceCeiling, PriceFloor);
                        BgS3Color = Color.FromHex("#222222");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {

                            double tmp = PriceS3 + random;
                            if (tmp - 100 >= PriceS2)
                            {
                                PriceS3 = tmp;
                                BgS3Color = PriceS3Color;
                                PriceS3Color = Color.White;
                            }
                            else
                            {
                                PriceS3 = PriceS2 + 100;
                            }

                            return false;
                        });
                    }
                    else
                    {
                        PriceS3Color = SetColor2(PriceS3, PriceMedium, PriceCeiling, PriceFloor);
                        BgS3Color = Color.FromHex("#FFFFFF");
                        Device.StartTimer(new TimeSpan(0, 0, refreshTime - 1), () =>
                        {

                            double tmp = PriceS3 + random;
                            if (tmp - 100 >= PriceS2)
                            {
                                PriceS3 = tmp;
                                BgS3Color = PriceS3Color;
                                PriceS3Color = Color.White;
                            }
                            else
                            {
                                PriceS3 = PriceS2 + 100;
                            }
                            return false;
                        });
                    }
                });
                return true;
            });
        }
    }

}