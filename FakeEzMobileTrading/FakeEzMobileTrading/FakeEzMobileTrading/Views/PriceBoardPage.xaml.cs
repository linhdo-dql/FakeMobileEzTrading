using FakeEzMobileTrading.Interfaces;
using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriceBoardPage : ContentPage
    {
        private int time;
        StockItem dragItem;
        StockItem dropItem;
        public PriceBoardPage(int t)
        {
            InitializeComponent();
            time = t;
            BindingContext = new PriceBoardPageViewModel(this, Navigation);
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<IOrientationService>().Landscape();
           
            if(time!=0)
            {
                BindingContext = new PriceBoardPageViewModel(this, Navigation);
            }
            else
            {
                time = 1;
            }
            
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DependencyService.Get<IOrientationService>().Portrait();
           
        }

        private void DataGridView_CompleteRowDragDrop(object sender, DevExpress.XamarinForms.DataGrid.CompleteRowDragDropEventArgs e)
        {
            List<StockItem> stockItems = App.CollectionsList.FirstOrDefault(l => l.Name == Preferences.Get("CurrentFollowList", "")).StockItemList.ToList();
            if(stockItems.Contains(dragItem) && stockItems.Contains(dropItem))
            {
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

        private void DataGridView_DragRow(object sender, DevExpress.XamarinForms.DataGrid.DragRowEventArgs e)
        {
           dragItem = (e.DragItem as StockItem);
        }

        private void DataGridView_DropRow(object sender, DevExpress.XamarinForms.DataGrid.DropRowEventArgs e)
        {
           dropItem = (e.DropItem as StockItem);
        }
    }
}