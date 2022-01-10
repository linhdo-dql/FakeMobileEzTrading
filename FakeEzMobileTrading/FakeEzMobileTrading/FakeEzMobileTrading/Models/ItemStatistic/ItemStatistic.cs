using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FakeEzMobileTrading.Models.ItemStatistic
{
    public class ItemStatistic : BaseViewModel
    {
        private string _stockIdStatistic;
        private ObservableCollection<PriceStatistic> _priceStatistic;
        public string StockIdStatistic
        {
            get { return _stockIdStatistic; }
            set { SetProperty(ref _stockIdStatistic, value); }
        }
        public ObservableCollection<PriceStatistic> PriceStatistic
        {
            get { return _priceStatistic; }
            set { SetProperty(ref _priceStatistic, value); }
        }

    }
}
