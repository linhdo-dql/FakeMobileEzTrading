using DevExpress.XamarinForms.Popup;
using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.Views;
using FakeEzMobileTrading.Views.CustomViews;
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
    public class OverViewPageViewModel : BaseViewModel
    {   
        private ObservableCollection<StockItem> _stockItems = new ObservableCollection<StockItem>()
            {
                /*new StockItem(){ StockId="VCB",PriceMedium=76900, PriceCeiling=82200, PriceFloor=71600, PriceB3=76300, PriceB3X=1800, PriceB2=76400,PriceB2X=1300,PriceB1=76500,PriceB1X=80700,PriceS1=76900,PriceS1X=18900,PriceS2=77000,PriceS2X=100,PriceS3=77300,PriceS3X=1300,TotalMass=1489000,PriceOpen=77500,PriceMax=78900,PriceMin=76500,ForeignB=285700,ForeignS=643900,PriceGood=76500, PriceGoodX = 80700 } ,
                new StockItem(){ StockId="PVC",PriceMedium=14700, PriceCeiling=16100, PriceFloor=13300, PriceB3=15700, PriceB3X=12200, PriceB2=15800,PriceB2X=10200,PriceB1=15900,PriceB1X=30900,PriceS1=16000,PriceS1X=18500,PriceS2=16100,PriceS2X=163900,PriceS3=0,PriceS3X=0,TotalMass=2961800,PriceOpen=14800,PriceMax=16100,PriceMin=14200,ForeignB=800,ForeignS=3000,PriceGood=16000, PriceGoodX = 100 },
                new StockItem(){ StockId="VCB",PriceMedium=76900, PriceCeiling=82200, PriceFloor=71600, PriceB3=76300, PriceB3X=1800, PriceB2=76400,PriceB2X=1300,PriceB1=76500,PriceB1X=80700,PriceS1=76900,PriceS1X=18900,PriceS2=77000,PriceS2X=100,PriceS3=77300,PriceS3X=1300,TotalMass=1489000,PriceOpen=77500,PriceMax=78900,PriceMin=76500,ForeignB=264900,ForeignS=320100,PriceGood=76500, PriceGoodX = 80700 },
                new StockItem(){ StockId="AAA",PriceMedium=20000, PriceCeiling=21400, PriceFloor=18600, PriceB3=21300, PriceB3X=88100, PriceB2=21350,PriceB2X=34900,PriceB1=21400,PriceB1X=106900,PriceS1=0,PriceS1X=0,PriceS2=0,PriceS2X=0,PriceS3=0,PriceS3X=0,TotalMass=18312800,PriceOpen=18700,PriceMax=18700,PriceMin=17300,ForeignB=59300,ForeignS=487300,PriceGood=21400, PriceGoodX = 328200 }
                */
            };
        private ObservableCollection<StockItem> NewStockItems { get; set; }
        public ObservableCollection<StockExchange> StockExchanges { get; set; }
        public ObservableCollection<StockFollowList> StockFollowLists { get; set; }
        public ObservableCollection<StockItem> StockItems { get { return _stockItems; } set { SetProperty(ref _stockItems, value); } }
        private int _amountTapSortId = 0, _amountTapSortPrice = 0, _amountTapSortPersentOrUpdown = 0, _amountTapSortMass = 0;
        private bool _showHidePersent = false;
        private bool _newListLayoutVisible = false;
        private string _sortPriceSource = "ic_updown.png", _sortMassSource= "ic_updown.png", _sortIdSource= "ic_updown.png", _sortPersentSource = "ic_updown.png";
        private string _nameList = "Đặt tên danh mục...";
        INavigation Navigation { get; set; }
        
        public OverViewPageViewModel(Page page, INavigation navigation)
        {
            StockExchanges = new ObservableCollection<StockExchange>(App.Exchanges.Where(ex=>ex.IsFavourite== true));
            NewStockItems = new ObservableCollection<StockItem>(StockItems);
            StockFollowLists = new ObservableCollection<StockFollowList>(App.CollectionsList);
            if(Preferences.Get("CurrentFollowPage", "").ToString()!="")
            {
                StockItems = StockFollowLists.Where(o => o.Name == Preferences.Get("CurrentFollowPage", "").ToString()).FirstOrDefault().StockItemList;
                NewStockItems = new ObservableCollection<StockItem>(StockItems);
            }


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
                        StockFollowLists.Remove(item);
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
                await navigation.PushAsync(new ExchangeDetailPage(exchange.ExchangeId));
            });
            SwictchOverViewMarket = new Command(() =>
            {
                navigation.PushAsync(new OverViewMarketPage());
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
                if(NewListLayoutVisible==true)
                {
                    NewListLayoutVisible = false;
                }
                else
                {
                    NewListLayoutVisible = true;
                }
            });
            AddList = new Command((x) =>
            {
                var entry = x as Entry;
                
                if (StockFollowLists.Where(item => item.Name == entry.Text).FirstOrDefault()==null)
                {
                    StockFollowList z;
                    if (StockFollowLists.Count == 0)
                    {
                        z = new StockFollowList() { Name = entry.Text, IsShowing = true, StockItemList = new ObservableCollection<StockItem>() };
                        Preferences.Set("CurrentFollowList", entry.Text);
                        StockFollowLists.Add(z);
                        App.CollectionsList.Add(z);
                        entry.Text = "";
                        page.FindByName<DXPopup>("popup").IsOpen = false;
                    }
                    else
                    {
                        z = new StockFollowList() { Name = entry.Text, IsShowing = false, StockItemList = new ObservableCollection<StockItem>() };
                        StockFollowLists.Add(z);
                        App.CollectionsList.Add(z);
                        entry.Text = "";
                        NewListLayoutVisible = false;
                    }
                }
                else
                {
                    page.DisplayAlert("Lỗi", "Tên này đã tồn tại. Vui lòng nhập tên khác!", "Đồng ý");
                }
                
                
            });
            SelectedCollectionList = new Command((x) =>
            {
                var z = x as StockFollowList;
                StockFollowList tmp = StockFollowLists.Where(list => list.Name == z.Name).FirstOrDefault();
                foreach(StockFollowList xz in StockFollowLists)
                {
                    if(xz.Name!=z.Name)
                    {
                        xz.IsShowing = false;
                    }
                }
                tmp.IsShowing = true;
                StockItems = tmp.StockItemList;
                Preferences.Set("CurrentFollowList", tmp.Name);
                page.FindByName<DXPopup>("popup").IsOpen = false;
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
                    await navigation.PushModalAsync(new SearchPage());
                }
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
        

        public void ResetSort(ref int tap0, ref int tap1, ref int tap2, ref int tap3)
        {
            if (tap0 == 1)
            {
                tap1 = tap2 = tap3 = 0;
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
        public Command SelectedCollectionList { get; }
        public Command InitListItem { get; }

    }
}
