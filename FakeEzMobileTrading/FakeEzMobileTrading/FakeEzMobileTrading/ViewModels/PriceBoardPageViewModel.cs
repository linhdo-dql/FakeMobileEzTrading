using DevExpress.XamarinForms.Popup;
using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.Views;
using FakeEzMobileTrading.Views.HomePages;
using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FakeEzMobileTrading.ViewModels
{
    public class PriceBoardPageViewModel : BaseViewModel
    {
        private ObservableCollection<StockExchange> _stockExchanges;
        private ObservableCollection<StockItem> _stockItems;
        private ObservableCollection<StockFollowList> _stockFollowList;
        public ObservableCollection<StockExchange> StockExchanges { get => _stockExchanges; set { SetProperty(ref _stockExchanges,value); } }
        public ObservableCollection<StockItem> StockItems { get => _stockItems; set { SetProperty(ref _stockItems, value); } }
        public ObservableCollection<StockFollowList> StockFollowListsk { get => _stockFollowList; set { SetProperty(ref _stockFollowList, value); } }
        private bool _isBusy = false, _newListLayoutVisible, _fullOrShort, _isDisplayChecked = false, _isScrollChecked = false, _isVisible = false;
        private string _selectedStockId;
        private bool _tap = false;
        public PriceBoardPageViewModel(Page page, INavigation navigation)
        {

            Preferences.Set("TypeTable", 1);
            Task.Run(async () =>
            {
                await Task.Delay(2000);
               
                
                IsVisible = true;
            });
            StockFollowListsk = App.CollectionsList;
            FullOrShort = IsDisplayChecked = Preferences.Get("FullOrSort", false);
            StockExchanges = new ObservableCollection<StockExchange>(App.Exchanges.Where(ex => ex.IsFavourite == true));
            ObservableCollection<StockItem> kx = App.CollectionsList.FirstOrDefault(l => l.Name == Preferences.Get("CurrentFollowList", String.Empty)).StockItemList;
            StockItems = new ObservableCollection<StockItem>(kx);
            RefreshClick = new Command(() =>
            {
                IsBusy = true;
                Device.StartTimer(new TimeSpan(0,0,1), () =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        StockExchanges = new ObservableCollection<StockExchange>(App.Exchanges.Where(ex => ex.IsFavourite == true));
                        StockItems = new ObservableCollection<StockItem>(App.CollectionsList.FirstOrDefault(l => l.Name == Preferences.Get("CurrentFollowList", String.Empty)).StockItemList);
                        IsBusy = false;
                    });
                    return false;
                });
                
            });
            ShowPopup = new Command((x) =>
            {
                var popup = x as DXPopup;
                popup.IsOpen = true;
            });
            HidePopup = new Command((x) =>
            {
                var popup = x as DXPopup;
                popup.IsOpen = false;
            });
            ShowHideLayoutAddList = new Command(() =>
            {

                NewListLayoutVisible = true;

            });
            SelectList = new Command((x) =>
            {
                var item = x as StockFollowList;
                Preferences.Set("CurrentFollowList", item.Name);
                foreach (StockFollowList s in StockFollowListsk)
                {
                    if (s.IsShowing == true)
                    {
                        s.IsShowing = false;
                    }
                }
                foreach (StockFollowList s in App.CollectionsList)
                {
                    if (s.IsShowing == true)
                    {
                        s.IsShowing = false;
                    }
                }
                item.IsShowing = true;
                page.FindByName<DXPopup>("popup").IsOpen = false;

            });
            AddList = new Command((x) =>
            {
                var entry = x as Entry;
                if (!String.IsNullOrEmpty(entry.Text))
                {
                    if (App.CollectionsList.Where(item => item.Name == entry.Text).FirstOrDefault() == null)
                    {
                        StockFollowList z = new StockFollowList() { Name = entry.Text, IsShowing = false, StockItemList = new ObservableCollection<StockItem>() };
                        App.CollectionsList.Add(z);
                        entry.Text = "";
                        NewListLayoutVisible = false;
                        
                    }
                    else
                    {
                        page.DisplayAlert("Lỗi", "Tên này đã tồn tại. Vui lòng nhập tên khác!", "Đồng ý");
                        entry.Text = "";
                        NewListLayoutVisible = false;
                    }
                }
                else
                {
                    page.DisplayAlert("Lỗi", "Tên danh mục không được bỏ trống!", "Đồng ý");
                    entry.Text = "";
                    NewListLayoutVisible = false;
                }


            });
            ResetCollectionView = new Command(() =>
            {
                if (App.CollectionsList.FirstOrDefault(list => list.Name == Preferences.Get("CurrentFollowList", String.Empty)) != null)
                {
                    StockItems = App.CollectionsList.FirstOrDefault(list => list.Name == Preferences.Get("CurrentFollowList", String.Empty)).StockItemList;
                }
            });

            SwipeListItem = new Command((x) =>
            {
                var item = x as StockFollowList;
                foreach (StockFollowList s in App.CollectionsList)
                {
                    if (s == item)
                    {
                        continue;
                    }
                    s.ShowHideSwipeView = false;
                }
            });
            DeleteListItem = new Command(async (x) =>
            {
                var item = x as StockFollowList;
                if (item.IsShowing != true)
                {
                    bool b = await page.DisplayAlert("Xác nhận", "Xóa danh sách theo dõi " + item.Name + "?", "Đồng ý", "Hủy");
                    if (b)
                    {
                        App.CollectionsList.Remove(item);
                    }
                }
                else
                {
                    await page.DisplayAlert("Thông báo", "Không thể xóa danh mục đang theo dõi. Hãy thử tạo mới một danh mục khác nếu bạn muốn xóa danh mục này!", "Đồng ý");
                }

            });
            InitListItem = new Command(async (x) =>
            {
                if (_tap == true) return;
                _tap = true;
                    await navigation.PushAsync(new SearchPage(0));
                _tap = false;
                
            });
            SettingBoard = new Command((x) =>
            {
                var pop = x as DXPopup;
                pop.IsOpen = true;
            });

            OnFull = new Command(() =>
            {
                Preferences.Set("FullOrSort", true);
                IsDisplayChecked = true;
            });

            OnShort = new Command(() =>
            {
                Preferences.Set("FullOrSort", false);
                IsDisplayChecked = false;
            });

            OnScrollEffect = new Command(() =>
            {
                IsScrollChecked = false;
            });
            OffScrollEffect = new Command(() =>
            {
                IsScrollChecked = true;
            });
            SaveOrExitSetting = new Command((x) =>
            {
                var pop = x as DXPopup;

                pop.IsOpen = false;
            });
            ResetCollectionView2 = new Command((x) =>
            {
                FullOrShort = Preferences.Get("FullOrSort", false);
            });
            ShowPopupDetail = new Command((x) =>
            {
                SelectedStockId = (string)x;
                if(String.IsNullOrEmpty(SelectedStockId))
                {
                    return;
                }
                page.FindByName<DXPopup>("popup3").IsOpen = true;
            });
            DeleteStockItem = new Command(async () =>
            {
              
                bool b = await page.DisplayAlert("Xác nhận", "Xóa mã " + SelectedStockId + " khỏi danh mục theo dõi?", "Đồng ý", "Hủy");
                if(b == true)
                {
                    IsBusy = true;
                    await Task.Delay(1000);
                    StockItems.Remove(StockItems.FirstOrDefault(x => x.StockId == SelectedStockId));
                    App.CollectionsList.FirstOrDefault(list => list.Name == Preferences.Get("CurrentFollowList", String.Empty)).StockItemList.Remove(StockItems.FirstOrDefault(x => x.StockId == SelectedStockId));
                    page.FindByName<DXPopup>("popup3").IsOpen = false;
                    IsBusy = false;
                }
                
            });
            RowSelected = new Command(async (x) =>
            {
                if (_tap == true) return;
                _tap = true;
               var item = x as StockItem;
               await page.Navigation.PushAsync(new StockDetailPage(item));
                _tap = false;
            });
            RowSelected2 = new Command(async (x) =>
            {
                if (_tap == true) return;
                _tap = true;
                var item = x as StockItem;
                await page.Navigation.PushAsync(new StockDetailPage(item));
                _tap = false;
            });
            ShowItemDetailPage = new Command(async () =>
            {
                if (_tap == true) return;
                _tap = true;
                await page.Navigation.PushAsync(new StockDetailPage(App.Items.FirstOrDefault(i=> i.StockId==SelectedStockId)));
                page.FindByName<DXPopup>("popup3").IsOpen = false;
                _tap = false;
            });
            SelectExchangeStock = new Command(async (x) =>
           {
               if (_tap == true) return;
               _tap = true;
               var item = x as StockExchange;
               await page.Navigation.PushAsync(new ExchangeDetailPage(item.ExchangeId));
               _tap = false;

           });
            ShowExchangeList = new Command(async () =>
            {
                if (_tap == true) return;
                _tap = true;
               
                await page.Navigation.PushAsync(new OverViewMarketPage());
                _tap = false;

            });
            SellOrBuyStockItem = new Command(async (x) =>
            {
                page.FindByName<DXPopup>("popup3").IsOpen = false;
                var type = (x as StackLayout).ClassId;
                await page.Navigation.PushAsync(new ActionCommandPage(SelectedStockId, bool.Parse(type)));
            });
            

        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }
        
        public bool NewListLayoutVisible
        {
            get { return _newListLayoutVisible; }
            set { SetProperty(ref _newListLayoutVisible, value); }
        }
        public bool FullOrShort
        {
            get { return _fullOrShort; }
            set { SetProperty(ref _fullOrShort, value); }
        }
        public bool IsDisplayChecked
        {
            get { return _isDisplayChecked; }
            set { SetProperty(ref _isDisplayChecked, value); }
        }
        public bool IsScrollChecked
        {
            get { return _isScrollChecked; }
            set { SetProperty(ref _isScrollChecked, value); }
        }
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }
        public string SelectedStockId
        {
            get { return _selectedStockId; }
            set { SetProperty(ref _selectedStockId, value); }
        }
        public Command RefreshClick { get; }

        public Command ShowPopup { get; }
        public Command ShowHideLayoutAddList { get; }
        public Command HidePopup { get; }
        public Command SelectList { get; }
        public Command InitListItem { get; }
        public Command AddList { get; }
        public Command ResetCollectionView { get; }
        public Command ResetStockFollowList { get; }
        public Command SettingBoard { get; }
        public Command OnFull { get; }
        public Command OnShort { get; }
        public Command OnScrollEffect { get; }
        public Command OffScrollEffect { get; }
        public Command SaveOrExitSetting { get; }
        public Command ResetCollectionView2 { get; }
        public Command SwipeListItem { get; }
        public Command DeleteListItem { get; }
        public Command ShowPopupDetail { get; }
        public Command DeleteStockItem { get; }
        public Command RowSelected { get; }
        public Command RowSelected2 { get; }
        public Command ShowItemDetailPage { get; }
        public Command SelectExchangeStock { get; }
        public Command ShowExchangeList { get; }
        public Command SellOrBuyStockItem { get; }
    }
}
