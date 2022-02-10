
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
using Xamarin.Forms.Internals;

namespace FakeEzMobileTrading.Menus
{
    public class FlyoutMenuViewModel : BaseViewModel
    {
        private ObservableCollection<ItemMenu> _itemMenu;
        private bool _settingVisible = true;
        private bool _successVisible = false;
        private bool _listFavouriteVisible = false;
        private bool _istapped = false;
        private int _tapp = 0;
        public FlyoutMenuViewModel(Page page)
        {
            SetResource();
            ShowHideSubMenu = new Command((x) =>
            {
                ItemMenu item = x as ItemMenu;
                item.IsVisible = !item.IsVisible;
            });
            ShowFavouriteIcon = new Command(() =>
            {
               
                foreach (ItemMenu item in ItemMenus)
                {
                    
                    item.IsVisible = false;
                    item.IconShowMoreEnable = false;
                    item.IconFavouriteVisible = true;
                }
                if(ItemMenus.FirstOrDefault(x=> x.Index == 0)!=null)
                {
                    ItemMenus.Remove(ItemMenus.FirstOrDefault(x => x.Index == 0));
                }
                ItemMenus = new ObservableCollection<ItemMenu>(ItemMenus.OrderBy(x => x.Index));
                SuccessVisible = true;
                SettingVisible = false;
            });
            HideFavouriteIcon = new Command(() =>
            {
                bool b = false;
                foreach (ItemMenu item in ItemMenus)
                {       
                        if(item.TypeList == 0) { b = true; }
                        if(item.SubMenu!=null)
                        {
                        item.IconShowMoreEnable = true;
                        }
                        item.IconFavouriteVisible = false;
                }

                if (b==true)
                {
                    if (ItemMenus.FirstOrDefault(x => x.Index == 0) == null)
                    {
                        ItemMenu itemF = new ItemMenu() { Index = 0, TypeTemplate = 0, TypeList = 0, FTypeList = 0, Name = "Yêu thích" };
                        ItemMenus.Insert(0, itemF);
                    }
                    
                }
                else
                {
                    if (ItemMenus.FirstOrDefault(x => x.Index == 0) != null)
                    {
                        ItemMenus.Remove(ItemMenus.FirstOrDefault(x => x.Index == 0));
                    }
                }

                ItemMenus = new ObservableCollection<ItemMenu>(ItemMenus.OrderBy(x => x.TypeList));
                

                SuccessVisible = false;
                SettingVisible = true;
            });
            ControlFavourite = new Command((x) =>
            {
                ItemMenu item = x as ItemMenu;
               
                item.IsFavourite = !item.IsFavourite;
                if(item.IsFavourite == true)
                {
                    item.TypeList = 0;
                }
                else
                {
                    item.TypeList = item.FTypeList;
                }
               
            });
            ChangePage = new Command(async (x) =>
            {
                if(SuccessVisible == true) { return; }
                if (_istapped==true)
                {
                    return;
                }
                ItemMenu item = x as ItemMenu;
                if(item.SubMenu!=null)
                {
                    item.IsVisible = !item.IsVisible;
                    return;
                }
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
                            case "banggia": if (_tapp == 1 || _tapp!=3) { await (page.Parent as FlyoutPage).Navigation.PushAsync(new PriceBoardPage(0)); _tapp = 2; } else { _tapp = 0; }; break;
                            case "tintuc": (page.Parent as FlyoutPage).Detail = new NavigationPage(new NewPage()); break;
                            case "fptsnhandinh": (page.Parent as FlyoutPage).Detail = new NavigationPage(new FPTSIdentityPage()); break;
                            case "lichsukien": (page.Parent as FlyoutPage).Detail = new NavigationPage(new EventCalendarPage()); break;
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
        
        public Command ShowHideSubMenu { get; }
        public Command ShowFavouriteIcon { get; }
        public Command HideFavouriteIcon { get; }
        public Command ControlFavourite { get; }
        public Command ChangePage { get; }
        public void SetResource()
        {
           
           ItemMenus = new ObservableCollection<ItemMenu>()
           {
                new ItemMenu() {Index=1, TypeTemplate = 0, TypeList = 1, FTypeList = 1, Name="Thị trường"},
                new ItemMenu () {Index=2, TypeTemplate = 2, TypeList = 1, FTypeList = 1, Id = "tongquan", Icon="ic_m1_tongquan.png", Name="Tổng quan", SubMenu=null},
                new ItemMenu () {Index=3, TypeTemplate = 2, TypeList = 1, FTypeList = 1, Id = "banggia", Icon="ic_m1_banggia.png", Name="Bảng giá", SubMenu=null},
                new ItemMenu () {Index=4, TypeTemplate = 2, TypeList = 1, FTypeList = 1, Id = "tintuc", Icon="ic_m1_tintuc.png", Name="Tin tức", SubMenu=null},
                new ItemMenu () {Index=5, TypeTemplate = 2, TypeList = 1, FTypeList = 1,Id = "chisothegioi", Icon="ic_m1_chisotg.png", Name="Chỉ số thế giới", SubMenu=null},
                new ItemMenu () {Index=6, TypeTemplate = 2, TypeList = 1, FTypeList = 1,Id = "fptsnhandinh", Icon="ic_m1_fptsnhandinh.png", Name="FPTS nhận định", SubMenu=null},
                new ItemMenu () {Index=7, TypeTemplate = 2, TypeList = 1, FTypeList = 1,Id = "lichsukien", Icon="ic_m1_lichsukien.png", Name="Lịch sự kiện", SubMenu=null},
                new ItemMenu () {Index=8, TypeTemplate = 2, TypeList = 1, FTypeList = 1,Id = "bieudo", Icon="ic_m1_bieudo.png", Name="Biểu đồ", SubMenu=null},
                new ItemMenu () {Index=9, TypeTemplate = 2, TypeList = 1, FTypeList = 1,Id = "giaodichphaisinh", Icon="ic_m1_gdphaisinh.png", Name="Giao dịch phái sinh", SubMenu=null},
                new ItemMenu() {Index=10, TypeTemplate = 0, TypeList = 2, FTypeList = 2,Name="Giao dịch"},
                new ItemMenu () {Index=11, TypeTemplate = 2, TypeList = 2, FTypeList = 2,Id = "datlenh", Icon="ic_m2_datlenh.png", Name="Đặt lệnh", SubMenu=null},
                new ItemMenu () {Index=12, TypeTemplate = 2, TypeList = 2, FTypeList = 2,Id = "lenhdieukien", Icon="ic_m2_datlenhdk.png", Name="Lệnh điều kiện", SubMenu=null},
                new ItemMenu () {Index=13, TypeTemplate = 2, TypeList = 2, FTypeList = 2,Id = "baocaogiaodich", Icon="ic_m2_baocaogd.png", Name="Báo cáo giao dịch", SubMenu = new string[]{"Lệnh trong ngày", "Lịch sử đặt lệnh","Lệnh ứng trước"} },
                new ItemMenu () {Index=14, TypeTemplate = 2, TypeList = 2, FTypeList = 2,Id = "quanlytaikhoan", Icon="ic_m2_quanlytk.png", Name="Quản lý tài khoản", SubMenu= new string[]{"Sao kê chứng khoán", "Sao kê tiền", "Tra cứu phí lưu ký", "Tra cứu tình trạng chứng quyền","Tra cứu biểu phí"}},
                new ItemMenu () {Index=15, TypeTemplate = 2, TypeList = 2, FTypeList = 2, Id= "baocaotaisan", Icon="ic_m2_bctaisan.png", Name="Báo cáo tài sản", SubMenu=null},
                new ItemMenu () {Index=16, TypeTemplate = 2, TypeList = 2, FTypeList = 2,Id = "banlole", Icon="ic_m2_banlole.png", Name="Bán lô lẻ", SubMenu=null},
                new ItemMenu () {Index=17, TypeTemplate = 2, TypeList = 2, FTypeList = 2,Id = "thuchienquyen", Icon="ic_m2_thuchienquyen.png", Name="Thực hiện quyền", SubMenu=null},
                new ItemMenu() {Index=18, TypeTemplate = 0, TypeList = 3, FTypeList = 3,Name="Tư vấn đầu tư"},
                new ItemMenu () {Index=19, TypeTemplate = 2, TypeList = 3, FTypeList = 3,Id = "gioithieudichvu", Icon="ic_m3_hdsd.png", Name="Giới thiệu dịch vụ", SubMenu=null},
                new ItemMenu () {Index=20, TypeTemplate = 2, TypeList = 3, FTypeList = 3,Id = "timkiemchuyenvien", Icon="ic_m3_timkiemcv.png", Name="Tìm kiếm chuyên viên", SubMenu=null},
                new ItemMenu () {Index=21, TypeTemplate = 2, TypeList = 3, FTypeList = 3,Id = "baocaotuvan", Icon="ic_m3_baocaotv.png", Name="Báo cáo tư vấn", SubMenu=null},
                new ItemMenu () {Index=22, TypeTemplate = 2, TypeList = 3, FTypeList = 3,Id = "danhgiachuyenvien", Icon="ic_m3_danhgiacv.png", Name="Đánh giá chuyên viên", SubMenu=null},
                new ItemMenu () {Index=23, TypeTemplate = 2, TypeList = 3, FTypeList = 3,Id = "tailieu", Icon="ic_m3_tailieu.png", Name="Tài liệu", SubMenu=null},
                new ItemMenu() {Index=24, TypeTemplate = 0, TypeList = 4, FTypeList = 4,Name="Trợ giúp"},
                new ItemMenu () {Index=25, TypeTemplate = 2, TypeList = 4, FTypeList = 4,Id = "thongbao", Icon="ic_m4_thongbao.png", Name="Thông báo", SubMenu=null},
                new ItemMenu () {Index=26, TypeTemplate = 2, TypeList = 4, FTypeList = 4,Id = "caidatmatkhau", Icon="ic_m4_caidatmatkhau.png", Name="Cài đặt mật khẩu", SubMenu=null},
                new ItemMenu () {Index=27, TypeTemplate = 2, TypeList = 4, FTypeList = 4,Id = "lienhe", Icon="ic_m4_lienhe.png", Name="Liên hệ", SubMenu=null},
                new ItemMenu () {Index=28, TypeTemplate = 2, TypeList = 4, FTypeList = 4,Id = "gopy", Icon="ic_m4_gopy.png", Name="Góp ý", SubMenu=null},
                new ItemMenu () {Index=29, TypeTemplate = 2, TypeList = 4, FTypeList = 4,Id = "huongdansudung", Icon="ic_m4_hdsd.png", Name="Hướng dẫn sử dụng", SubMenu=null},
                new ItemMenu () {Index=30, TypeTemplate = 2, TypeList = 4, FTypeList = 4,Id = "caidat", Icon="ic_m4_caidat.png", Name="Cài đặt", SubMenu=null}
           };
            
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
