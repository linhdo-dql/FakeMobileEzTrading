using FakeEzMobileTrading.Views.CustomViews;
using FakeEzMobileTrading.Views.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage(int index)
        {
            InitializeComponent();
            NavigationPage overview = new NavigationPage(new OverViewPage());
            overview.IconImageSource = "ic_bm_thitruong.png";
            overview.Title = "Thị trường";

            NavigationPage asset = new NavigationPage(new AssetPage());
            asset.IconImageSource = "ic_bm_taisan.png";
            asset.Title = "Tài sản";

            NavigationPage actioncommand = new NavigationPage(new ActionCommandPage("", false));
            actioncommand.IconImageSource = "ic_bm_datlenh.png";
            actioncommand.Title = "Đặt lệnh";

            NavigationPage editing = new NavigationPage(new EditPage());
            editing.IconImageSource = "ic_bm_editing.png";
            editing.Title = "Hủy / Sửa";

            NavigationPage sendMoney = new NavigationPage(new SendMoneyPage());
            sendMoney.IconImageSource = "ic_bm_chuyentien.png";
            sendMoney.Title = "Chuyển tiền";

            Children.Add(overview);
            Children.Add(asset);
            Children.Add(actioncommand);
            Children.Add(editing);
            Children.Add(sendMoney);

            CurrentPage = this.Children[index];
            
        }

    }
}