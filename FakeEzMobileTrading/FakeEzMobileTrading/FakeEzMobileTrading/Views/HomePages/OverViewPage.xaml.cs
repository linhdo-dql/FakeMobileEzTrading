using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.ViewModels.HomePageViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading.Views.HomePages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OverViewPage : ContentPage
    {
        StockItem dragItem;
        StockItem dropItem;
        public OverViewPage()
        {
            InitializeComponent();
            BindingContext = new OverViewPageViewModel(this, Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new OverViewPageViewModel(this, Navigation);
        }

        private void StockItems_DragItem(object sender, DevExpress.XamarinForms.CollectionView.DragItemEventArgs e)
        {
            dragItem = (e.DragItem as StockItem);
        }

        private void StockItems_DropItem(object sender, DevExpress.XamarinForms.CollectionView.DropItemEventArgs e)
        {
            dropItem = (e.DropItem as StockItem);
        }

        private void StockItems_CompleteItemDragDrop(object sender, DevExpress.XamarinForms.CollectionView.CompleteItemDragDropEventArgs e)
        {
            List<StockItem> stockItems = App.CollectionsList.FirstOrDefault(l => l.Name == Preferences.Get("CurrentFollowList", "")).StockItemList.ToList();
            int dragI = stockItems.IndexOf(stockItems.FirstOrDefault(d => d.StockId == dragItem.StockId));
            int dropI = stockItems.IndexOf(stockItems.FirstOrDefault(d => d.StockId == dropItem.StockId));
            stockItems.RemoveAll(d => d.StockId == dragItem.StockId);
            if (dragI > dropI)
            {
                stockItems.Insert(dropI == 0 ? 0 : (dropI - 1), dragItem);

            }
            if (dragI < dropI)
            {
                stockItems.Insert(dropI == stockItems.Count ? stockItems.Count : (dropI + 1), dragItem);
            }
            App.CollectionsList.FirstOrDefault(l => l.Name == Preferences.Get("CurrentFollowList", "")).StockItemList = new ObservableCollection<StockItem>(stockItems);
        }
    }

}