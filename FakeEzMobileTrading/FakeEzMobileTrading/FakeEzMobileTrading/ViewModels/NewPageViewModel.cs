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
    public class NewPageViewModel: BaseViewModel
    {
        public ObservableCollection<New> FPTSNews { get; set; }
        public ObservableCollection<New> CKNews { get; set; }

        private ObservableCollection<New> _companyNews;
        public ObservableCollection<New> CompanyNews { get => _companyNews; set { SetProperty(ref _companyNews, value);  } }
        public ObservableCollection<New> IPONews { get; set; }
        public ObservableCollection<New> ComNews { get; set; }
        public ObservableCollection<New> CommunityNews { get; set; }

        private string _strSearch;
        public NewPageViewModel()
        {
            FPTSNews = new ObservableCollection<New>(App.News.Where(n => n.Id == 1));
            CKNews = new ObservableCollection<New>(App.News.Where(n => n.Id == 2));
            CompanyNews = new ObservableCollection<New>(App.News.Where(n => n.Id ==3));
            IPONews = new ObservableCollection<New>(App.News.Where(n => n.Id ==4));
            ComNews = new ObservableCollection<New>(App.News.Where(n => n.Id ==5));
            CommunityNews = new ObservableCollection<New>(App.News.Where(n => n.Id ==6));
            


        }
        public string StrSearch
        {
            get
            {
                return _strSearch;
            }
            set
            {                                                                                                           
                CompanyNews = new ObservableCollection<New>(App.News.Where(n => n.Id == 3 && n.StockId.ToLower().Contains(value.Trim().ToLower())).ToList());
                SetProperty(ref _strSearch, value);
            }
        }
    }
}
