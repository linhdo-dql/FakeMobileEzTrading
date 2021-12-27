using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FakeEzMobileTrading.Models
{
    public class StockFollowList : BaseViewModel
    {
           private string _name;
           private bool _isShowing, _showHidePersent;
           private ObservableCollection<StockItem> _stockItemList;
           public string Name { get => _name; set { SetProperty(ref _name, value); } }
           public bool IsShowing { get => _isShowing; set { SetProperty(ref _isShowing, value); } }
           public bool ShowHideSwipeView
           {
                get { return _showHidePersent; }
                set { SetProperty(ref _showHidePersent, value); }
           }
           public ObservableCollection<StockItem> StockItemList { get => _stockItemList; set { SetProperty(ref _stockItemList, value); } }
    }
}
