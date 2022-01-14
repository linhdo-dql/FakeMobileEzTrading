
using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.Views;
using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FakeEzMobileTrading.ViewModels
{   
    public class OverViewMarketPageViewModel : BaseViewModel
    {
        public ObservableCollection<StockExchange> HSXStockExChanges { get; set; }
        public ObservableCollection<StockExchange> HNXStockExChanges { get; set; }
        private string _typeFilter = "+/-", _typeFilter2 = "Khối lượng";
        private bool _showHidePersent = false, _showHideValue = false;
        private bool _tap = false;
        public OverViewMarketPageViewModel(Page page, INavigation navigation)
        {
            
            HSXStockExChanges = new ObservableCollection<StockExchange>(App.Exchanges.Where(ex => ex.TypeExchange == "HSX"));
            HNXStockExChanges = new ObservableCollection<StockExchange>(App.Exchanges.Where(ex => ex.TypeExchange == "HNX"));
            ChangeFilter = new Command(() =>
            {
                TypeFilter = TypeFilter == "+/-" ? "%" : "+/-";
            });
            ChangeFilter2 = new Command(() =>
            {
                TypeFilter2 = TypeFilter2 == "Khối lượng" ? "Giá trị" : "Khối lượng";
            });
            ChangeFilter3 = new Command(() =>
            {
                TypeFilter3 = TypeFilter3 == "+/-" ? "%" : "+/-";
            });
            ChangeFilter4 = new Command(() =>
            {
                TypeFilter4 = TypeFilter4 == "Khối lượng" ? "Giá trị" : "Khối lượng";
            });
            ControlFavourite = new Command((x) =>
            {
                var item = x as StockExchange;
                item.IsFavourite = item.IsFavourite ? false : true;
                foreach(StockExchange xz in App.Exchanges)
                {
                    if(xz.ExchangeId == item.ExchangeId)
                    {
                        xz.IsFavourite = item.IsFavourite;  
                    }
                }
            });
            SwicthExchangDetail = new Command(async (x) =>
            {
                if (_tap == true) return;
                _tap = true;
                var item = x as StockExchange;
                await navigation.PushAsync(new ExchangeDetailPage(item.ExchangeId));
                _tap = false;
            });
        }
        
        public Command ChangeFilter { get; set; }
        public Command ChangeFilter2 { get; set; }
        public Command ChangeFilter3 { get; set; }
        public Command ChangeFilter4 { get; set; }
        public Command ControlFavourite { get; }

        public Command SwicthExchangDetail { get; set; }
        public string TypeFilter
        {
            get { return _typeFilter; }
            set 
            {
                ShowHidePersent = value == "%" ? true : false;
                SetProperty(ref _typeFilter, value);
            }
        }
        public string TypeFilter2
        {
            get { return _typeFilter2; }
            set 
            { 
                ShowHideValue = value == "Giá trị" ? true : false;  
                SetProperty(ref _typeFilter2, value); 
            }
        }
        public string TypeFilter3
        {
            get { return _typeFilter; }
            set
            {
                ShowHidePersent = value == "%" ? true : false;
                SetProperty(ref _typeFilter, value);
            }
        }
        public string TypeFilter4
        {
            get { return _typeFilter2; }
            set
            {
                ShowHideValue = value == "Giá trị" ? true : false;
                SetProperty(ref _typeFilter2, value);
            }
        }
        public bool ShowHidePersent
        {
            get { return _showHidePersent; }
            set { SetProperty(ref _showHidePersent, value); }
        }
        public bool ShowHideValue
        {
            get { return _showHideValue; }
            set { SetProperty(ref _showHideValue, value); }
        }
    }
}
