using DevExpress.XamarinForms.Navigation;
using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.Models.ItemStatistic;
using Java.Util;
using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FakeEzMobileTrading.ViewModels
{
    public class ItemDetailPageViewModel  : BaseViewModel
    {
        public StockItem StockItem { get; set; }
        private ObservableCollection<PriceStatistic> _priceStatistics;
        public ObservableCollection<PriceStatistic> PriceStatistics { get => _priceStatistics; set { SetProperty(ref _priceStatistics, value); } }
        public ObservableCollection<CompanyNew> CompanyNews { get; set; }
        public int _nextOrPrev = 0;
        public ItemDetailPageViewModel(Page page,StockItem sI)
        {
            Preferences.Set("TypeTable", 0);
            IsBusy = true;
            page.FindByName<TabView>("gridPage").IsVisible = false;
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    page.FindByName<TabView>("gridPage").IsVisible = true;
                    IsBusy = false;
                });
                return false;
            });
           

            StockItem = sI;
           
           
           PriceStatistics = new ObservableCollection<PriceStatistic>(App.ItemStatistics.FirstOrDefault(i => i.StockIdStatistic == sI.StockId).PriceStatistic.Take(6));
           CompanyNews = App.CompanyNews;
           Next = new Command(() =>
           {
               NextOrPrev = NextOrPrev + 1 > 4 ? 4 : NextOrPrev + 1;
               //page.DisplayAlert("test", NextOrPrev.ToString(), "ok");
               PriceStatistics = SetSourcePrice(NextOrPrev, sI.StockId);

           });
            Prev = new Command(() =>
            {
                NextOrPrev = NextOrPrev - 1 < 0 ? 0 : NextOrPrev - 1;
                //page.DisplayAlert("test", NextOrPrev.ToString(), "ok");
                PriceStatistics = SetSourcePrice(NextOrPrev, sI.StockId);

            });

            
        }
        public int NextOrPrev
        {
            get => _nextOrPrev;
            set {
                
                SetProperty(ref _nextOrPrev, value); 
            }
        }
        public Command Next { get; }
        public Command Prev { get; }
        
        public ObservableCollection<PriceStatistic> SetSourcePrice(int x, string sI)
        {
            PriceStatistics = App.ItemStatistics.FirstOrDefault(i => i.StockIdStatistic == sI).PriceStatistic;
            ObservableCollection<PriceStatistic> s = new ObservableCollection<PriceStatistic>();
            switch (x)
            {
                case 0: s = new ObservableCollection<PriceStatistic>(PriceStatistics.Skip(0).Take(6)); break;
                case 1: s = new ObservableCollection<PriceStatistic>(PriceStatistics.Skip(6).Take(6)); break;
                case 2: s = new ObservableCollection<PriceStatistic>(PriceStatistics.Skip(12).Take(6)); break;
                case 3: s = new ObservableCollection<PriceStatistic>(PriceStatistics.Skip(18).Take(6)); break;
                case 4: s = new ObservableCollection<PriceStatistic>(PriceStatistics.Skip(24).Take(6)); break;
                case 5: s = new ObservableCollection<PriceStatistic>(PriceStatistics.Skip(30)); break;
            }
            return s;
        }

        
        private bool _isBusy = false;
        public bool IsBusy { get => _isBusy; set { SetProperty(ref _isBusy, value); } }
    }
}
