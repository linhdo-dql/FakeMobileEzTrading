using FakeEzMobileTrading.Models;
using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FakeEzMobileTrading
{
    public class EventCalendarPageViewModel : BaseViewModel
    {
   

        private ObservableCollection<New> _iPONews;
        public ObservableCollection<New> IPONews { get => _iPONews; set { SetProperty(ref _iPONews, value);  } }
        private ObservableCollection<New> _iPONews1;
        public ObservableCollection<New> IPONews1 { get => _iPONews1; set { SetProperty(ref _iPONews1, value); } }
        private ObservableCollection<New> _iPONews2;                
        public ObservableCollection<New> IPONews2 { get => _iPONews2; set { SetProperty(ref _iPONews2, value); } }
        private ObservableCollection<New> _iPONews3;
        public ObservableCollection<New> IPONews3 { get => _iPONews3; set { SetProperty(ref _iPONews3, value); } }
        private ObservableCollection<New> _iPONews4;
        public ObservableCollection<New> IPONews4 { get => _iPONews4; set { SetProperty(ref _iPONews4, value); } }
        private ObservableCollection<New> _iPONews5;
        public ObservableCollection<New> IPONews5 { get => _iPONews5; set { SetProperty(ref _iPONews5, value); } }



        private string _strSearch, _strSearch1, _strSearch2, _strSearch3, _strSearch4;
        public EventCalendarPageViewModel()
        {
            
            IPONews = new ObservableCollection<New>(App.ActionEvents.Where(n => n.Id ==1));
            IPONews1 = new ObservableCollection<New>(App.ActionEvents.Where(n => n.Id ==2));
            IPONews2 = new ObservableCollection<New>(App.ActionEvents.Where(n => n.Id ==3));
            IPONews3 = new ObservableCollection<New>(App.ActionEvents.Where(n => n.Id ==4));
            IPONews4 = new ObservableCollection<New>(App.ActionEvents.Where(n => n.Id ==5));
            IPONews5 = new ObservableCollection<New>(App.ActionEvents.Where(n => n.Id ==6));
           
            


        }
        public string StrSearch
        {
            get
            {
                return _strSearch;
            }
            set
            {
                IPONews = new ObservableCollection<New>(App.ActionEvents.Where(n => n.Id == 1 && n.StockId.ToLower().Contains(value.Trim().ToLower())).ToList());
                SetProperty(ref _strSearch, value);
            }
        }
        public string StrSearch1
        {
            get
            {
                return _strSearch1;
            }
            set
            {
                IPONews1 = new ObservableCollection<New>(App.ActionEvents.Where(n => n.Id == 2 && n.StockId.ToLower().Contains(value.Trim().ToLower())).ToList());
                SetProperty(ref _strSearch1, value);
            }
        }
        public string StrSearch2
        {
            get
            {
                return _strSearch2;
            }
            set
            {
                IPONews3 = new ObservableCollection<New>(App.ActionEvents.Where(n => n.Id == 4 && n.StockId.ToLower().Contains(value.Trim().ToLower())).ToList());
                SetProperty(ref _strSearch2, value);
            }
        }
        public string StrSearch3
        {
            get
            {
                return _strSearch3;
            }
            set
            {
                IPONews4 = new ObservableCollection<New>(App.ActionEvents.Where(n => n.Id == 5 && n.StockId.ToLower().Contains(value.Trim().ToLower())).ToList());
                SetProperty(ref _strSearch3, value);
            }
        }
        public string StrSearch4
        {
            get
            {
                return _strSearch4;
            }
            set
            {
                IPONews5 = new ObservableCollection<New>(App.ActionEvents.Where(n => n.Id == 6 && n.StockId.ToLower().Contains(value.Trim().ToLower())).ToList());
                SetProperty(ref _strSearch4, value);
            }
        }

    }
}
