
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

namespace FakeEzMobileTrading.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
    {
        private string _searchContent;
        private ObservableCollection<StockItem> _allStockItems;
        public ObservableCollection<StockItem> AllStockItems 
        { 
            get 
            {
                return _allStockItems; 
            } 
            set 
            { 
                SetProperty(ref _allStockItems, value); 
            } 
        }
        public SearchPageViewModel(Page page, int type)
        {
            AllStockItems = new ObservableCollection<StockItem>(App.Items);
            AddToList = new Command((x) =>
            {
                var item = x as StockItem;
                ObservableCollection<StockItem> stockItems = App.CollectionsList.FirstOrDefault(list => list.Name == Preferences.Get("CurrentFollowList", "")).StockItemList;
               
                if (type == 0 || type == 3)
                {
                    
                    if (stockItems.FirstOrDefault(l => l.StockId == item.StockId) == null)
                    {
                        stockItems.Add(item);
                    }
                    page.Navigation.PopAsync();
                }
                else
                {
                    page.Navigation.PushAsync(new StockDetailPage(item));
                }
               
                
                
            });
            HidePopup = new Command((x) =>
            {
                page.Navigation.PopAsync();
            });
        }
        public string SearchContent
        {
            get
            {
                return _searchContent;
            }
            set
            {
                AllStockItems = new ObservableCollection<StockItem>(App.Items.Where(x => x.StockId.ToLower().Contains(value.Trim().ToLower())).ToList());
                SetProperty(ref _searchContent, value);
            }
        }

        public Command Search { get; }
        public Command AddToList { get; }

        public Command HidePopup { get; }
    }
}
