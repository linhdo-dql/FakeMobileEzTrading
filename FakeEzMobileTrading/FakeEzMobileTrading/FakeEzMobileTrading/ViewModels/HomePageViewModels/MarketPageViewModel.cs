using DevExpress.XamarinForms.Popup;
using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.Views;
using FakeEzMobileTrading.Views.CustomViews;
using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FakeEzMobileTrading.ViewModels.HomePageViewModels
{
    public class MarketPageViewModel : BaseViewModel 
    {   
        private ObservableCollection<StockItem> _stockItems = new ObservableCollection<StockItem>();
        private ObservableCollection<StockItem> NewStockItems { get; set; }
        private ObservableCollection<StockExchange> _stockExchanges;
        private bool _tap = false;
        public ObservableCollection<StockExchange> StockExchanges {
            get { return _stockExchanges; } 
            set 
            { 
                SetProperty(ref _stockExchanges, value);
            } 
        }
        private ObservableCollection<StockFollowList> _stockFollowLists;
        public ObservableCollection<StockFollowList> StockFollowLists { get { return _stockFollowLists; } set { SetProperty(ref _stockFollowLists, value); } }
        public ObservableCollection<StockItem> StockItems
        {
            get
            {
                return _stockItems;
            }
            set 
            {
                SetProperty(ref _stockItems, value);
            }
        }
        private int _amountTapSortId = 0, _amountTapSortPrice = 0, _amountTapSortPersentOrUpdown = 0, _amountTapSortMass = 0, _tmpCount;
        private bool _showHidePersent = false, _isSortEnable;
        private bool _newListLayoutVisible = false, _isVisible = false, _labelVisible=false;
        private string _sortPriceSource = "ic_updown.png", _sortMassSource= "ic_updown.png", _sortIdSource= "ic_updown.png", _sortPersentSource = "ic_updown.png";
        INavigation Navigation { get; set; }
        
        public MarketPageViewModel(Page page, INavigation navigation)
        {
            Preferences.Set("TypeTable", 0);
            IsVisible = false;
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    
                    StockExchanges = new ObservableCollection<StockExchange>(App.Exchanges.Where(ex => ex.IsFavourite == true));
                    StockFollowLists = App.CollectionsList;
                    if (Preferences.Get("CurrentFollowList", String.Empty) != "")
                    {
                        ObservableCollection<StockItem> kz = App.CollectionsList.Where(list => list.Name == Preferences.Get("CurrentFollowList", String.Empty)).FirstOrDefault().StockItemList;
                        
                        StockItems = new ObservableCollection<StockItem>(kz);
                        Preferences.Set("TypeTable", 0);
                        NewStockItems = StockItems;
                        TmpCount = StockItems.Count;
                    }
                    IsVisible = true;
                });
                return false;
            });
            
            
            
            
            Navigation = navigation;
            
            ChangeFilter = new Command((x) =>
            {
                var z = x as AbsoluteLayout;
                TypeFilter = TypeFilter == "+/-" ? "%" : "+/-";
               
            });
            SortMass = new Command((x) =>
            {
                var btn = x as Image;
                btn.ClassId = btn.ClassId == "up" ? "down" : "up";
                _amountTapSortMass++;
                ResetSort(ref _amountTapSortMass, ref _amountTapSortId, ref _amountTapSortPersentOrUpdown, ref _amountTapSortPrice);
                SortIdSource = SortPersentSource = SortPriceSource ="ic_updown.png";
                if(_amountTapSortMass==3)
                {
                    _amountTapSortMass = 0;
                    SortMassSource = "ic_updown.png";
                    StockItems = NewStockItems;
                    btn.ClassId = "down";
                    return;
                }    
                if (btn.ClassId == "down")
                {
                    SortMassSource = "ic_sort_down.png";
                    StockItems =  new ObservableCollection<StockItem>(StockItems.OrderBy(z => z.TotalMass));
                }
                else
                {
                    SortMassSource = "ic_sort_up.png";
                    btn.WidthRequest = 15;
                    btn.HeightRequest = 15;
                    StockItems = new ObservableCollection<StockItem>(StockItems.OrderByDescending(z => z.TotalMass));
                }
            });
            SortId = new Command((x) =>
            {
                var btn = x as Image;
                btn.ClassId = btn.ClassId == "up" ? "down" : "up";
                _amountTapSortId++;
                ResetSort(ref _amountTapSortId, ref _amountTapSortMass, ref _amountTapSortPersentOrUpdown, ref _amountTapSortPrice);
                SortMassSource = SortPersentSource = SortPriceSource = "ic_updown.png";
                if (_amountTapSortId == 3)
                {
                    _amountTapSortId = 0;
                    SortIdSource = "ic_updown.png";
                    StockItems = NewStockItems;
                    btn.ClassId = "down";
                    return;
                }
                if (btn.ClassId == "down")
                {
                    SortIdSource = "ic_sort_az.png";
                    StockItems = new ObservableCollection<StockItem>(StockItems.OrderBy(z => z.StockId));
                }
                else
                {
                    SortIdSource = "ic_sort_za.png";
                    StockItems = new ObservableCollection<StockItem>(StockItems.OrderByDescending(z => z.StockId));
                }
            });
            SortPrice = new Command((x) =>
            {
                var btn = x as Image;
                btn.ClassId = btn.ClassId == "up" ? "down" : "up";
                _amountTapSortPrice++;
                ResetSort(ref _amountTapSortPrice, ref _amountTapSortId,ref _amountTapSortMass,ref _amountTapSortPersentOrUpdown);
                SortIdSource = SortMassSource = SortPersentSource = "ic_updown.png";
                if (_amountTapSortPrice == 3)
                {
                    _amountTapSortPrice = 0;
                    SortPriceSource = "ic_updown.png";
                    StockItems = NewStockItems;
                    btn.ClassId = "down";
                    return;
                }
                if (btn.ClassId == "down")
                {
                    SortPriceSource = "ic_sort_down.png";
                    StockItems = new ObservableCollection<StockItem>(StockItems.OrderBy(z => z.PriceGood));
                }
                else
                {
                    SortPriceSource = "ic_sort_up.png";
                    StockItems = new ObservableCollection<StockItem>(StockItems.OrderByDescending(z => z.PriceGood));
                }
            });
            SortPersentOrUpDown = new Command((x) =>
            {
                var btn = x as Image;
                btn.ClassId = btn.ClassId == "up" ? "down" : "up";
                _amountTapSortPersentOrUpdown++;
                ResetSort(ref _amountTapSortPersentOrUpdown, ref _amountTapSortId, ref _amountTapSortPrice, ref _amountTapSortMass);
                SortIdSource = SortPriceSource = SortMassSource = "ic_updown.png";
                if (_amountTapSortPersentOrUpdown == 3)
                {
                    _amountTapSortPersentOrUpdown = 0;
                    SortPersentSource = "ic_updown.png";
                    StockItems = NewStockItems;
                    btn.ClassId = "down";
                    return;
                }
                if (TypeFilter == "%")
                {
                    if (btn.ClassId == "down")
                    {
                        SortPersentSource = "ic_sort_down.png";
                        StockItems = new ObservableCollection<StockItem>(StockItems.OrderBy(z => z.Persent));
                    }
                    else
                    {
                        SortPersentSource = "ic_sort_up.png";
                        StockItems = new ObservableCollection<StockItem>(StockItems.OrderByDescending(z => z.Persent));
                    }
                }
                else
                {
                    if (btn.ClassId == "down")
                    {
                        SortPersentSource = "ic_sort_down.png";
                        StockItems = new ObservableCollection<StockItem>(StockItems.OrderBy(z => z.UpDown));
                    }
                    else
                    {
                        SortPersentSource = "ic_sort_up.png";
                        StockItems = new ObservableCollection<StockItem>(StockItems.OrderByDescending(z => z.UpDown));
                    }
                } 
            });
            SwipeItem = new Command((x) =>
            {
                var item = x as StockItem;
                foreach(StockItem s in StockItems)
                {
                    if(s==item)
                    {
                        continue;
                    }    
                    s.ShowHideSwipeView = false;
                }    
            });
            DeleteItem = new Command(async (x) =>
            {
                var item = x as StockItem;
                bool b = await page.DisplayAlert("Xác nhận","Xóa mã "+item.StockId+" khỏi danh sách?","Đồng ý","Hủy");
                if(b)
                {
                    StockItems.Remove(item);
                    App.CollectionsList.FirstOrDefault(list => list.Name == Preferences.Get("CurrentFollowList", String.Empty)).StockItemList.Remove(item);
                    NewStockItems = StockItems;
                    TmpCount = StockItems.Count;
                }    
            });
            SwipeListItem = new Command((x) =>
            {
                var item = x as StockFollowList;
                foreach (StockFollowList s in StockFollowLists)
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
                if(item.IsShowing != true)
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
            ExchangeDetail = new Command(async (x) =>
            {
                var exchange = x as StockExchange;
                if (_tap == true) return;
                _tap = true;
                    await navigation.PushAsync(new ExchangeDetailPage(exchange.ExchangeId));
                _tap = false;
                
               
            });
            SwictchOverViewMarket = new Command(async () =>
            {
                await navigation.PushAsync(new OverViewMarketPage());
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
            AddList = new Command((x) =>
            {
                var entry = x as Entry;
                if(!String.IsNullOrEmpty(entry.Text))
                {   if (App.CollectionsList.Where(item => item.Name == entry.Text).FirstOrDefault() == null)
                    {
                        StockFollowList z;
                        if (StockFollowLists.Count == 0)
                        {
                            z = new StockFollowList() { Name = entry.Text, IsShowing = true, StockItemList = new ObservableCollection<StockItem>() };
                            Preferences.Set("CurrentFollowList", entry.Text);
                            App.CollectionsList.Add(z);
                            entry.Text = "";
                            NewListLayoutVisible = false;
                            page.FindByName<DXPopup>("popup").IsOpen = false;
                        }
                        else
                        {
                            z = new StockFollowList() { Name = entry.Text, IsShowing = false, StockItemList = new ObservableCollection<StockItem>() };
                            App.CollectionsList.Add(z);
                            entry.Text = "";
                            NewListLayoutVisible = false;
                        }
                    }
                    else
                    {
                        page.DisplayAlert("Lỗi", "Tên này đã tồn tại. Vui lòng nhập tên khác!", "Đồng ý");
                    }
                }
                else
                {
                    page.DisplayAlert("Lỗi", "Tên danh mục không được bỏ trống!", "Đồng ý");
                    entry.Text = "";
                    NewListLayoutVisible = false;
                }
                
                
            });
          

            InitListItem = new Command(async (x) =>
            {
                if (StockFollowLists.Count == 0)
                {
                   bool b = await page.DisplayAlert("Lỗi", "Bạn chưa tạo danh mục theo dõi.", "Tạo mới ngay", "Hủy");
                   if(b)
                    {
                        var z = x as DXPopup;
                        z.IsOpen = true;
                    }
                }
                else
                {
                    await navigation.PushAsync(new SearchPage(3));
                }
            });
            SwitchPriceBoard = new Command(async () =>
            {
                if(_tap == true)
                {
                    return;
                }
                _tap = true;
                if(App.CollectionsList.FirstOrDefault(list => list.Name == Preferences.Get("CurrentFollowList", String.Empty))!=null)
                {
                    await (page.Parent.Parent as Page).Navigation.PushAsync(new PriceBoardPage(0));
                    _tap = false;
                }  
                else
                {
                   await page.DisplayAlert("Lỗi", "Chưa có danh mục nào được tạo. Vui lòng tạo mới một danh sách!", "Đồng ý");
                    
                }
                
            });
            SelectList = new Command((x) =>
            {
                var item = x as StockFollowList;
                Preferences.Set("CurrentFollowList",item.Name);
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
            ResetCollectionView = new Command(() =>
            {
                if (App.CollectionsList.FirstOrDefault(list => list.Name == Preferences.Get("CurrentFollowList", String.Empty)) != null)
                {
                    StockItems = App.CollectionsList.FirstOrDefault(list => list.Name == Preferences.Get("CurrentFollowList", String.Empty)).StockItemList;
                    NewStockItems = StockItems;
                    TmpCount = StockItems.Count;
                }
               


            });
            ResetStockFollowList = new Command(() =>
            {
                StockFollowLists = new ObservableCollection<StockFollowList>(App.CollectionsList);
            });
            SwitchNotifyPage = new Command(async () =>
            {
                if (_tap == true) return;
                _tap = true;
                await page.Navigation.PushModalAsync(new NotifyPage());
                _tap = false;
            });
            SwitchSearchPage = new Command(async () =>
            {
               await page.Navigation.PushAsync(new SearchPage(1));
            });
            SelectItemS = new Command(async (x) =>
            {
                if (_tap == true) return;
                _tap = true;
                var item = x as StockItem;
                await page.Navigation.PushAsync(new StockDetailPage(item));
                _tap = false;
            });
        }
        private string _typeFilter = "+/-";
        public string TypeFilter
        {
            get { return _typeFilter; }
            set {
                ShowHidePersent = value == "%" ? true : false;
                SetProperty(ref _typeFilter, value); 
            }
        }
        public bool ShowHidePersent
        {
            get { return _showHidePersent;  }
            set { SetProperty(ref _showHidePersent, value); }
        }
        
        public bool NewListLayoutVisible
        {
            get { return _newListLayoutVisible; }
            set { SetProperty(ref _newListLayoutVisible, value); }
        }
        public bool IsEnableSort
        {
            get { return _isSortEnable; }
            set 
            { 
                
                SetProperty(ref _isSortEnable, value); 
            }
        }


        public void ResetSort(ref int tap0, ref int tap1, ref int tap2, ref int tap3)
        {
            if (tap0 == 1)
            {
                tap1 = tap2 = tap3 = 0;
            }
        }
        
        public int TmpCount
        {
            get
            {
                return _tmpCount;
            }
            set
            {
                IsEnableSort = value > 1 ? true : false;
                LabelVisible = value == 0 ? true : false;
                if (value <= 1) { SortMassSource = SortPersentSource = SortPriceSource = SortIdSource = "ic_updown.png"; }
                SetProperty(ref _tmpCount, value);
            }
        }
        public string SortPriceSource
        {
            get { return _sortPriceSource; }
            set { SetProperty(ref _sortPriceSource, value); }
        }
        public string SortMassSource
        {
            get { return _sortMassSource; }
            set { SetProperty(ref _sortMassSource, value); }
        }
        public string SortIdSource
        {
            get { return _sortIdSource; }
            set { SetProperty(ref _sortIdSource, value); }
        }
        public string SortPersentSource
        {
            get { return _sortPersentSource; }
            set { SetProperty(ref _sortPersentSource, value); }
        }
        
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }

        public bool LabelVisible
        {
            get { return _labelVisible; }
            set { SetProperty(ref _labelVisible, value); }
        }
        public Command ChangeFilter { get; }
        public Command SortMass { get; }
        public Command SortId { get; }
        public Command SortPersentOrUpDown { get; }
        public Command SortPrice { get; }
        public Command SwipeItem { get; }
        public Command DeleteItem { get; }
        public Command SwipeListItem { get; }
        public Command DeleteListItem { get; }
        public Command ExchangeDetail { get; }
        public Command SwictchOverViewMarket { get; }
        public Command ShowPopup { get; }
        public Command HidePopup { get; }
        public Command AddList { get; }
        public Command ShowHideLayoutAddList { get; }     
        public Command InitListItem { get; }
        public Command SwitchPriceBoard { get; }
        public Command SelectList { get; }
        public Command SelectItemS { get; }
        public Command ResetCollectionView { get; }
        public Command ResetStockFollowList { get; }
        public Command SwitchNotifyPage { get; }
        public Command SwitchSearchPage { get; }

    }
}
