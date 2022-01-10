using DevExpress.XamarinForms.Popup;
using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.Views;
using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FakeEzMobileTrading.ViewModels.HomePageViewModels
{
    public class ActionCommandPageViewModel : BaseViewModel
    {
        private StockItem _stockItem = new StockItem();
        private ObservableCollection<SurplusStock> _surplusStocks;
        private string _idStock, _idStock2, _pass="", _showHidePassSource = "ic_hide_pass.png", _stockPrice2;
        private double _stockPrice, _stockAmount;
        private double _myMoney;
        private bool _stockNameVisible = false;
        private bool _showHidePass = true;
        private bool _sellBuyVisible = false;
        private bool _upDownVisible = true;
        private bool _labelPriceVisible = true;
        private bool _isDisplayChecked = true;

        public string IdStock { 
            get { return _idStock; } 
            set 
            {
                if (value == "") { StockNameVisible = false; StockItem = new StockItem(); StockPrice = 0; StockAmount = 0; Pass = ""; LabelPriceVisible = false; };
                SetProperty(ref _idStock, value); 
            }
        }
        public string IdStock2
        {
            get { return _idStock2; }
            set
            {
                SurplusStocks = new ObservableCollection<SurplusStock>(App.SuplusStocks.Where(s => s.StockId.ToLower().Trim().Contains(value.ToLower().Trim())));
                SetProperty(ref _idStock2, value);
            }
        }
        public string ShowHidePassSource
        {
            get { return _showHidePassSource; }
            set
            {
                SetProperty(ref _showHidePassSource, value);
            }
        }
        public string Pass
        {
            get { return _pass; }
            set
            {
                SetProperty(ref _pass, value);
            }
        }
        public string StockPrice2
        {
            get { return _stockPrice2; }
            set
            {
                SetProperty(ref _stockPrice2, value);
            }
        }
        public double StockPrice
        {
            get { return _stockPrice; }
            set { SetProperty(ref _stockPrice, value); }
        }
        public double MyMoney
        {
            get { return _myMoney; }
            set { SetProperty(ref _myMoney, value); }
        }
        public double StockAmount
        {
            get { return _stockAmount; }
            set { SetProperty(ref _stockAmount, value); }
        }
        public StockItem StockItem { 
            get { return _stockItem; } 
            set { SetProperty(ref _stockItem, value); }
        }
        public bool StockNameVisible { get => _stockNameVisible; set { SetProperty(ref _stockNameVisible, value); } }
        public bool SellBuyVisible { get => _sellBuyVisible; set { SetProperty(ref _sellBuyVisible, value); } }
        public bool ShowHidePass { get => _showHidePass; set { ShowHidePassSource = value == true ? "ic_hide_pass.png" : "ic_show_pass.png"; SetProperty(ref _showHidePass, value); } }
        public bool UpDownVisible { get => _upDownVisible; set { SetProperty(ref _upDownVisible, value); } }
        public bool LabelPriceVisible { get => _labelPriceVisible; set { SetProperty(ref _labelPriceVisible, value); } }
        public bool IsDisplayChecked { get => _isDisplayChecked; 
            set 
            { 
                SetProperty(ref _isDisplayChecked, value); 
            } 
        }
        public ObservableCollection<SurplusStock> SurplusStocks { get => _surplusStocks; set { SetProperty(ref _surplusStocks, value); } }


        public ActionCommandPageViewModel(Page page)
        {
            MyMoney = 900000000;
            Pass = "";
            SurplusStocks = App.SuplusStocks;
            StockPrice = StockItem.PriceFloor;
            StockAmount = 0;
            LabelPriceVisible = false;
            SelectedStock = new Command(() =>
            {
                if (!String.IsNullOrEmpty(IdStock))
                {
                    if (App.Items.FirstOrDefault(x => x.StockId == IdStock) != null)
                    {
                        StockItem = App.Items.FirstOrDefault(z => z.StockId == IdStock);
                        StockNameVisible = true;
                        UpDownVisible = true;
                        LabelPriceVisible = true;
                        StockPrice = StockItem.PriceFloor;
                        page.FindByName<RadioButton>("rdLO").IsChecked = true;
                    }
                    else
                    {
                        page.FindByName<Entry>("IdStockEntry").Text = "";
                        page.DisplayAlert("Lỗi", "Mã này không tồn tại vui lòng nhập lại!", "Đóng");
                        page.FindByName<Entry>("IdStockEntry").Focus();
                    }
                }
                
            });
            UpPrice = new Command(() =>
            {
              
                 StockPrice = StockPrice + 100 <= StockItem.PriceCeiling ? StockPrice + 100 : StockPrice;
               
            });
            DownPrice = new Command(() =>
            {
                
                    StockPrice = StockPrice - 100 >= StockItem.PriceFloor ? StockPrice - 100 : StockPrice;
               
            });
            UpAmount = new Command(() =>
            {
                
                    StockAmount = StockAmount * StockPrice < MyMoney ? StockAmount + 100 : StockAmount;
                
            });
            DownAmount = new Command(() =>
            {
                    StockAmount = StockAmount - 100 >= 0 ? StockAmount - 100 : StockAmount;
                
            });
            ChangeSellBuy = new Command(() =>
            {
                SellBuyVisible = SellBuyVisible == true ? false : true;
            });
            ShowOrHidePass = new Command((x) =>
            {
                var entry = x as Entry;
                ShowHidePass = ShowHidePass == true ? false : true;
            });
            ClearEntry = new Command(() =>
            {
                IdStock = "";
            });
            RadioChecked = new Command((x) =>
            {
                var button = x as RadioButton;
                switch(button.ClassId)
                {
                    case "LO": UpDownVisible = true; StockPrice = StockItem.PriceFloor; LabelPriceVisible = true; break;
                    case "ATO": UpDownVisible = false; StockPrice2 = "ATO"; StockPrice = StockItem.PriceOpen; LabelPriceVisible = false; break;
                    case "MP": UpDownVisible = false; StockPrice2 = "MP"; StockPrice = (SellBuyVisible == true ? StockItem.PriceB1 : StockItem.PriceS1); LabelPriceVisible = false; break;
                    case "ATC": UpDownVisible = false; StockPrice2 = "ATC"; StockPrice = StockItem.PriceClose; LabelPriceVisible = false; break;
                    

                }
            });
            SwitchCommandConditionPage = new Command(() =>
            {
                App.Current.MainPage = new NavigationPage( new MainPage("cc"));
            });
            ShowDialogSetting = new Command(() =>
            {
                page.FindByName<DXPopup>("popup2").IsOpen = true;
            });
            MassToPrice = new Command(() =>
            {
                IsDisplayChecked = IsDisplayChecked == true ? false : true;
                Preferences.Set("TypePriceMass", IsDisplayChecked);
            });
            ClosePopup = new Command(() =>
            {
                var layoutPriceMass = page.FindByName<StackLayout>("layoutPriceMass");
                var layoutPrice = page.FindByName<StackLayout>("layoutPrice");
                var layoutMass = page.FindByName<Grid>("layoutMass");
                bool b = Preferences.Get("TypePriceMass", true);
                if (b == true)
                {
                    layoutPriceMass.Children.Clear();
                    layoutPriceMass.Children.Add(layoutPrice);
                    layoutPriceMass.Children.Add(layoutMass);
                }
                else
                {
                    layoutPriceMass.Children.Clear();
                    layoutPriceMass.Children.Add(layoutMass);
                    layoutPriceMass.Children.Add(layoutPrice);
                }
            });
            SaveOrExitSetting = new Command(() =>
            {
                page.FindByName<DXPopup>("popup2").IsOpen = false;
            });
            PriceFrameTap = new Command((x) =>
            {
                var grid = x as Grid;
                page.FindByName<RadioButton>("rdLO").IsChecked = true;
                switch(grid.ClassId)
                {
                    case "grT": StockPrice = StockItem.PriceCeiling; break;
                    case "grTC": StockPrice = StockItem.PriceMedium; break;
                    case "grS": StockPrice = StockItem.PriceFloor; break;
                    case "grM1": StockPrice = StockItem.PriceB1; break;
                    case "grK": StockPrice = StockItem.PriceGood; break;
                    case "grB1": StockPrice = StockItem.PriceS1; break;
                }
                UpDownVisible = true;
                LabelPriceVisible = true;
            });
            ShowPopup3 = new Command(() =>
            {
                page.FindByName<DXPopup>("popup3").IsOpen = true;
            });
            HidePopup3 = new Command(() =>
            {
                page.FindByName<DXPopup>("popup3").IsOpen =false;
            });
            ShowPopup4 = new Command(() =>
            {
                page.FindByName<DXPopup>("popup4").IsOpen = true;
            });

        }
        public Command SelectedStock { get; }
        public Command UpPrice { get; }
        public Command DownPrice { get; }
        public Command UpAmount { get; }
        public Command DownAmount { get; }
        public Command ChangeSellBuy { get; }
        public Command ShowOrHidePass { get; }
        public Command ClearEntry { get; }
        public Command RadioChecked { get; }
        public Command SwitchCommandConditionPage { get; }
        public Command ShowDialogSetting { get; }
        public Command MassToPrice { get; }
        public Command ClosePopup { get; }
        public Command SaveOrExitSetting { get; }
        public Command PriceFrameTap { get; }
        public Command ShowPopup3 { get; }
        public Command HidePopup3 { get; }
        public Command ShowPopup4 { get; }
    }
}
