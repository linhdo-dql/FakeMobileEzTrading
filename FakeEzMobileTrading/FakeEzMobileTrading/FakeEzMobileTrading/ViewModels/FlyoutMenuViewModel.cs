using Android.Webkit;
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
using Xamarin.Forms;
namespace FakeEzMobileTrading.ViewModels
{
    public class FlyoutMenuViewModel : BaseViewModel
    {
        private ObservableCollection<ItemMenu> _itemMenu;
        private ObservableCollection<ItemMenu> _itemFavour;
        private ObservableCollection<ItemMenu> _itemTrans;
        private ObservableCollection<ItemMenu> _itemSale;
        private ObservableCollection<ItemMenu> _itemMarket;
        private ObservableCollection<ItemMenu> _itemSupport;
        private bool _settingVisible = true;
        private bool _successVisible = false;
        private bool _listFavouriteVisible = false;
        private bool _istapped = false;
        private int _tapp = 0;
        public FlyoutMenuViewModel(Page page)
        {
            SetResource();
            ItemFavourites = new ObservableCollection<ItemMenu>();
            ShowHideSubMenu = new Command((x) =>
            {
                ItemMenu item = x as ItemMenu;
                    item.IsVisible = !item.IsVisible;
                    //UpdateUIItem(item);
            });
            ShowFavouriteIcon = new Command(() =>
            {
                foreach(ItemMenu item in ItemMenus)
                {
                    item.IsVisible = false;
                    item.IconShowMore = "";
                    item.IconShowMoreEnable = false;
                    item.IconFavouriteVisible = true;
                }
                ItemMarkets = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 1));
                ItemTrans = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 2));
                ItemSales = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 3));
                ItemSupports = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 4));
                var scrollView = page.FindByName<ScrollView>("scrollView");
                var scrollLayout = page.FindByName<StackLayout>("scrollLayout");
                scrollView.ScrollToAsync(scrollLayout, ScrollToPosition.Start, false);
                ListFavouriteVisible = false;
                SuccessVisible = true;
                SettingVisible = false;
            });
            HideFavouriteIcon = new Command(() =>
            {
                foreach (ItemMenu item in ItemMenus)
                {
                    item.IconShowMore = "ic_showmore1.png";
                    if (item.SubMenu != null)
                    {
                        item.IconShowMoreEnable = true;
                    }
                    item.IconFavouriteVisible = false;
                }
                ListFavouriteVisible = ItemFavourites.Count>0 || ItemFavourites == null ? true:false;
                ItemMarkets = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 1 && item.IsFavourite == false));
                ItemTrans = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 2 && item.IsFavourite == false));
                ItemSales = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 3 && item.IsFavourite == false));
                ItemSupports = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 4 && item.IsFavourite == false));
                var scrollView = page.FindByName<ScrollView>("scrollView");
                var scrollLayout = page.FindByName<StackLayout>("scrollLayout");
                scrollView.ScrollToAsync(scrollLayout, ScrollToPosition.Start, false);
                SuccessVisible = false;
                SettingVisible = true;
            });
            ControlFavourite = new Command((x) =>
            {
                ItemMenu item = x as ItemMenu;
                item.IsFavourite = !item.IsFavourite;
                ItemFavourites = new ObservableCollection<ItemMenu>(ItemMenus.Where(i => i.IsFavourite == true));
            });
            ChangePage = new Command(async (x) =>
            {
                if(SuccessVisible) { return; }
                if (_istapped==true)
                {
                    return;
                }
                ItemMenu item = x as ItemMenu;
                _tapp++;
                _istapped = true;
                await Task.Run(() =>
                {
                    Task.Delay(300).Wait();
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        switch (item.Id)
                        {
                            case "tongquan": (page.Parent as FlyoutPage).Detail = new NavigationPage(new HomePage(0)); break;
                            case "banggia": if (_tapp == 1 || _tapp!=3) { (page.Parent as FlyoutPage).Navigation.PushAsync(new PriceBoard(0)); _tapp = 2; } else { _tapp = 0; }; break;
                            case "tintuc": (page.Parent as FlyoutPage).Detail = new NavigationPage(new NewPage()); break;
                            case "fptsnhandinh": (page.Parent as FlyoutPage).Detail = new NavigationPage(new FPTSIdentityPage()); break;
                            case "lichsukien": (page.Parent as FlyoutPage).Detail = new NavigationPage(new ActionEventPage()); break;
                            case "bieudo": (page.Parent as FlyoutPage).Detail = new NavigationPage(new ChartPage()); break;
                            case "baocaogiaodich": item.IsVisible = !item.IsVisible; break;
                            default: (page.Parent as FlyoutPage).Detail = new NavigationPage(new SendMoneyPage()); break;
                        }
                        
                          
                    });
                });
                (page.Parent as FlyoutPage).IsPresented = false;
                _istapped = false;
            });
        }
        public ObservableCollection<ItemMenu> ItemMenus
        {
            get { return _itemMenu; }
            set {
                SetProperty(ref _itemMenu, value);
            }
        }
        public ObservableCollection<ItemMenu> ItemFavourites
        {
            get { return _itemFavour; }
            set {
                SetProperty(ref _itemFavour, value); 
            }
        }
        public ObservableCollection<ItemMenu> ItemTrans
        {
            get { return _itemTrans; }
            set { SetProperty(ref _itemTrans, value); }
        }
        public ObservableCollection<ItemMenu> ItemSales
        {
            get { return _itemSale; }
            set { SetProperty(ref _itemSale, value); }
        }
        public ObservableCollection<ItemMenu> ItemMarkets
        {
            get { return _itemMarket; }
            set { SetProperty(ref _itemMarket, value); }
        }
        public ObservableCollection<ItemMenu> ItemSupports
        {
            get { return _itemSupport; }
            set { SetProperty(ref _itemSupport, value); }
        }
        public Command ShowHideSubMenu { get; }
        public Command ShowFavouriteIcon { get; }
        public Command HideFavouriteIcon { get; }
        public Command ControlFavourite { get; }
        public Command ChangePage { get; }
        public void SetResource()
        {
           ItemMenus = new ObservableCollection<ItemMenu>()
           {
                new ItemMenu () {TypeList = 1, Id = "tongquan", Icon="ic_m1_tongquan.png", Name="Tổng quan", SubMenu=null},
                new ItemMenu () {TypeList = 1, Id = "banggia", Icon="ic_m1_banggia.png", Name="Bảng giá", SubMenu=null},
                new ItemMenu () {TypeList = 1, Id = "tintuc", Icon="ic_m1_tintuc.png", Name="Tin tức", SubMenu=null},
                new ItemMenu () {TypeList = 1, Id = "chisothegioi", Icon="ic_m1_chisotg.png", Name="Chỉ số thế giới", SubMenu=null},
                new ItemMenu () {TypeList = 1, Id = "fptsnhandinh", Icon="ic_m1_fptsnhandinh.png", Name="FPTS nhận định", SubMenu=null},
                new ItemMenu () {TypeList = 1, Id = "lichsukien", Icon="ic_m1_lichsukien.png", Name="Lịch sự kiện", SubMenu=null},
                new ItemMenu () {TypeList = 1, Id = "bieudo", Icon="ic_m1_bieudo.png", Name="Biểu đồ", SubMenu=null},
                new ItemMenu () {TypeList = 1, Id = "giaodichphaisinh", Icon="ic_m1_gdphaisinh.png", Name="Giao dịch phái sinh", SubMenu=null},
                new ItemMenu () {TypeList = 2, Id = "datlenh", Icon="ic_m2_datlenh.png", Name="Đặt lệnh", SubMenu=null},
                new ItemMenu () {TypeList = 2, Id = "lenhdieukien", Icon="ic_m2_datlenhdk.png", Name="Lệnh điều kiện", SubMenu=null},
                new ItemMenu () {TypeList = 2, Id = "baocaogiaodich", Icon="ic_m2_baocaogd.png", Name="Báo cáo giao dịch", SubMenu = new string[]{"Lệnh trong ngày", "Lịch sử đặt lệnh","Lệnh ứng trước"} },
                new ItemMenu () {TypeList = 2, Id = "quanlytaikhoan", Icon="ic_m2_quanlytk.png", Name="Quản lý tài khoản", SubMenu= new string[]{"Sao kê chứng khoán", "Sao kê tiền", "Tra cứu phí lưu ký", "Tra cứu tình trạng chứng quyền","Tra cứu biểu phí"}},
                new ItemMenu () {TypeList = 2, Id = "baocaotaisan", Icon="ic_m2_bctaisan.png", Name="Báo cáo tài sản", SubMenu=null},
                new ItemMenu () {TypeList = 2, Id = "banlole", Icon="ic_m2_banlole.png", Name="Bán lô lẻ", SubMenu=null},
                new ItemMenu () {TypeList = 2, Id = "thuchienquyen", Icon="ic_m2_thuchienquyen.png", Name="Thực hiện quyền", SubMenu=null},
                new ItemMenu () {TypeList = 3, Id = "gioithieudichvu", Icon="ic_m3_hdsd.png", Name="Giới thiệu dịch vụ", SubMenu=null},
                new ItemMenu () {TypeList = 3, Id = "timkiemchuyenvien", Icon="ic_m3_timkiemcv.png", Name="Tìm kiếm chuyên viên", SubMenu=null},
                new ItemMenu () {TypeList = 3, Id = "baocaotuvan", Icon="ic_m3_baocaotv.png", Name="Báo cáo tư vấn", SubMenu=null},
                new ItemMenu () {TypeList = 3, Id = "danhgiachuyenvien", Icon="ic_m3_danhgiacv.png", Name="Đánh giá chuyên viên", SubMenu=null},
                new ItemMenu () {TypeList = 3, Id = "tailieu", Icon="ic_m3_tailieu.png", Name="Tài liệu", SubMenu=null},
                new ItemMenu () {TypeList = 4, Id = "thongbao", Icon="ic_m4_thongbao.png", Name="Thông báo", SubMenu=null},
                new ItemMenu () {TypeList = 4, Id = "caidatmatkhau", Icon="ic_m4_caidatmatkhau.png", Name="Cài đặt mật khẩu", SubMenu=null},
                new ItemMenu () {TypeList = 4, Id = "lienhe", Icon="ic_m4_lienhe.png", Name="Liên hệ", SubMenu=null},
                new ItemMenu () {TypeList = 4, Id = "gopy", Icon="ic_m4_gopy.png", Name="Góp ý", SubMenu=null},
                new ItemMenu () {TypeList = 4, Id = "huongdansudung", Icon="ic_m4_hdsd.png", Name="Hướng dẫn sử dụng", SubMenu=null},
                new ItemMenu () {TypeList = 4, Id = "caidat", Icon="ic_m4_caidat.png", Name="Cài đặt", SubMenu=null}
           };
            ItemMarkets = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 1));
            ItemTrans = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 2));
            ItemSales = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 3));
            ItemSupports = new ObservableCollection<ItemMenu>(ItemMenus.Where(item => item.TypeList == 4));
        }
        public bool SuccessVisible
        {
            get { return _successVisible; }
            set { SetProperty(ref _successVisible, value); }
        }
        public bool SettingVisible
        { get { return _settingVisible; } 
          set { SetProperty(ref _settingVisible, value);} 
        }
        public bool ListFavouriteVisible
        {
           get { return _listFavouriteVisible; }
           set { SetProperty(ref _listFavouriteVisible, value); }
        }
    }
}
