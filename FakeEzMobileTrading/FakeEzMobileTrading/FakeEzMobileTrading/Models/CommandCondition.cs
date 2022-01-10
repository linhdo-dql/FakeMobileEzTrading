using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FakeEzMobileTrading.Models
{
    public class CommandCondition : BaseViewModel
    {
        private string _stockID;
        private string _conditionID;
        private double _mass;
        private double _price;
        private double _priceCondition;
        private bool _condition;
        private string _notify;
        private string _typeSign;
        private DateTime _timeOrder;
        private DateTime _timeActive;
        private string _status;         
        private string _number;
        private string _calendarLHQ;
        private string _clearSource;
        public bool _type;

        public string LessThanCondition =>  Type == true ? (Condition == true ? "ic_big_3.png" : "ic_small_3.png") : (Condition == true ? "ic_big_4.png" : "ic_small_4.png");

        public string StockID { get => _stockID; set { SetProperty(ref _stockID, value); } }
        public string ConditionID { get => _conditionID; set { SetProperty(ref _conditionID, value); } }
        public double Mass { get => _mass; set { SetProperty(ref _mass, value); } }
        public double Price { get => _price; set { SetProperty(ref _price, value); } }
        public double PriceCondition { get => _priceCondition; set { SetProperty(ref _priceCondition, value); } }
        public bool Condition { get => _condition; set { SetProperty(ref _condition, value); } }
        public string Notify { get => _notify; set { SetProperty(ref _notify, value); } }
        public string TypeSign { get => _typeSign; set { SetProperty(ref _typeSign, value); } }
        public DateTime TimeOrder { get => _timeOrder; set { SetProperty(ref _timeOrder, value); } }
        public DateTime TimeActive { get => _timeActive; set { SetProperty(ref _timeActive, value); } }
        public string Status { get => _status; set { SetProperty(ref _status, value); } }
        public string Number { get => _number; set { SetProperty(ref _number, value); } }
        public string CalendarLHQ { get => _calendarLHQ; set { SetProperty(ref _calendarLHQ, value); } }
        public string ClearSource { get => _clearSource; set { SetProperty(ref _clearSource, value); } }
        public bool Type { 
            get => _type; 
            set 
            { 
                ClearSource = (value == true) ? "ic_del.png" : "ic_del2.png"; 
                SetProperty(ref _type,value); 
            } 
        }

        public string TextColor => Type == true ? "#034E95" : "#FF0000";
        public string LessMorePopupSource => Condition == true ? "ic_big_5.png" : "ic_small_5.png";
       
        public string StrType => Type == true ? "Mua" : "Bán";
    }
}
                                                                                