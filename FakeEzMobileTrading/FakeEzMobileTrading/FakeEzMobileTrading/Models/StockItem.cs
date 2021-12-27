using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FakeEzMobileTrading.Models
{
    public class StockItem : BaseViewModel
    {
        /// <summary>
        /// Stock
        /// </summary>
        private string _stockId;
        private string _stockName;
        private double _priceMedium;
        private double _priceCeiling;
        private double _priceFloor;
        private double _priceB1;
        private double _priceB2;
        private double _priceB3;
        private double _priceB1X;
        private double _priceB2X;
        private double _priceB3X;
        private double _priceS1;
        private double _priceS2;
        private double _priceS3;
        private double _priceS1X;
        private double _priceS2X;
        private double _priceS3X;
        private double _priceGood;
        private double _priceGoodX;
        private double _priceMax;
        private double _priceMin;
        private double _totalMass;
        private double _priceOpen;
        private double _foreignB;
        private double _foreignS;

        //
        private string _floorId;
        //Document
        private double _priceMax52T;
        private double _priceMin52T;
        private double _mass30d;
        private double _esp;
        private double _pe;
        private double _pb;
        private double _persentForeign;
        private double _money;
        private double _massDNY;
        private double _massDLH;
        private double _moneyValue;
        //
        private double _persentB;
        private double _persentS;
        private bool _showHidePersent= false;
        //
        private string _nameCollection;

        public Color Green = Color.FromArgb(55, 166, 71);
        public Color Red = Color.Red;
        public Color Pink = Color.FromArgb(210, 96, 141);
        public Color Blue = Color.LightSteelBlue;
        public Color Yellow = Color.LightYellow;
        public Color White = Color.White;
        public Color Black = Color.Black;
        
        public string StockId
        {
            get{ return _stockId; }
            set{ SetProperty(ref _stockId, value); }
        } 

        public string StockName
        {
            get { return _stockName; }
            set { SetProperty(ref _stockName, value); }
        }
        public double PriceMedium
        {
            get { return _priceMedium; }
            set { SetProperty(ref _priceMedium, value); }
        }
        public double PriceCeiling
        {
            get { return _priceCeiling; }
            set { SetProperty(ref _priceCeiling,value); }
        }
        public double PriceFloor
        {
            get { return _priceFloor; }
            set { SetProperty(ref _priceFloor, value); }
        }
        public double PriceB1
        {
            get { return _priceB1; }
            set { SetProperty(ref _priceB1, value); }
        }
        public double PriceB1X
        {
            get { return _priceB1X; }
            set { SetProperty(ref _priceB1X, value); }
        }
        public double PriceB2
        {
            get { return _priceB2; }
            set { SetProperty(ref _priceB2, value); }
        }
        public double PriceB2X
        {
            get { return _priceB2X; }
            set { SetProperty(ref _priceB2X, value); }
        }
        public double PriceB3
        {
            get { return _priceB3; }
            set { SetProperty(ref _priceB3, value); }
        }
        public double PriceB3X
        {
            get { return _priceB3X; }
            set { SetProperty(ref _priceB3X, value); }
        }
        public double PriceS1
        {
            get { return _priceS1; }
            set { SetProperty(ref _priceS1, value); }
        }
        public double PriceS1X
        {
            get { return _priceS1X; }
            set { SetProperty(ref _priceS1X, value); }
        }
        public double PriceS2
        {
            get { return _priceS2; }
            set { SetProperty(ref _priceS2, value); }
        }
        public double PriceS2X
        {
            get { return _priceS2X; }
            set { SetProperty(ref _priceS2X, value); }
        }
        public double PriceS3
        {
            get { return _priceS3; }
            set { SetProperty(ref _priceS3, value); }
        }
        public double PriceS3X
        {
            get { return _priceS3X; }
            set { SetProperty(ref _priceS3X, value); }
        }
        public double PriceGood
        {
            get { return _priceGood; }
            set { SetProperty(ref _priceGood, value); }
        }
        public double PriceGoodX
        {
            get { return _priceGoodX; }
            set { SetProperty(ref _priceGoodX, value); }
        }
        public double PriceMax
        {
            get { return _priceMax; }
            set { SetProperty(ref _priceMax, value); }
        }
        public double PriceMin
        {
            get { return _priceMin; }
            set { SetProperty(ref _priceMin, value); }
        }
        public double PriceOpen
        {
            get { return _priceOpen; }
            set { SetProperty(ref _priceOpen, value); }
        }
        public double TotalMass
        {
            get { return _totalMass; }
            set { SetProperty(ref _totalMass, value); }
        }
        public double ForeignB
        {
            get { return _foreignB; }
            set { SetProperty(ref _foreignB, value); }
        }
        public double ForeignS
        {
            get { return _foreignS; }
            set { SetProperty(ref _foreignS, value); }
        }
        public double Value
        {
            get { return (PriceGood * TotalMass) / 10000000; }
        }
        public double UpDown
        {
            get
            {
                return PriceGood - PriceMedium;
            }
        }
        public Color UpDownColor
        {
            get
            {
                return (PriceGood - PriceMedium) >= 0 ? (PriceGood == PriceCeiling ? Pink : Green) : Red;
            }
        }
        public double Persent
        {
            get
            {
                return ((PriceGood - PriceMedium) / PriceMedium) * 100000;
            }
        }
        public Color PresentColor
        {
            get
            {
                return UpDownColor;
            }
        }
        public Color PriceB1Color
        {
            get { return SetColor(PriceB1, PriceMedium, PriceCeiling, PriceFloor);   }
        }
        public Color PriceB2Color
        {
            get { return SetColor(PriceB1, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color PriceB3Color
        {
            get { return SetColor(PriceB1, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color PriceM1Color
        {
            get { return SetColor(PriceS1, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color PriceM2Color
        {
            get { return SetColor(PriceS2, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color PriceM3Color
        {
            get { return SetColor(PriceS3, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color PriceGoodColor
        {
            get { return SetColor(PriceGood, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color PriceMaxColor
        {
            get { return SetColor(PriceMax, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color PriceMinColor
        {
            get { return SetColor(PriceMin, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color PriceOpenColor
        {
            get { return SetColor(PriceOpen, PriceMedium, PriceCeiling, PriceFloor); }
        }
        public Color ColorDefault1
        {
            get { return White; }
        }
        public Color ColorDefault2
        {
            get { return Black; }
        }
        public bool ShowHideSwipeView
        {
            get { return _showHidePersent; }
            set { SetProperty(ref _showHidePersent, value); }
        }

        public string ExchangeId { get => _floorId; set { SetProperty(ref _floorId, value); } }
        public double PriceMax52T { get => _priceMax52T; set { SetProperty(ref _priceMax52T, value); } }
        public double PriceMin52T { get => _priceMin52T; set { SetProperty(ref _priceMin52T, value); } }
        public double Mass30d { get => _mass30d; set { SetProperty(ref _mass30d, value); } }
        public double Esp { get => _mass30d; set { SetProperty(ref _mass30d, value); } }
        public double Pe { get => _pe; set { SetProperty(ref _pe, value); } }
        public double Pb { get => _pb; set { SetProperty(ref _pb, value); } }
        public double PersentForeign { get => _persentForeign; set { SetProperty(ref _persentForeign, value); } }
        public double Money { get => _money; set { SetProperty(ref _money, value); } }
        public double MassDNY { get => _massDNY; set { SetProperty(ref _massDNY, value); } }
        public double MassDLH { get => _massDLH; set { SetProperty(ref _massDLH, value); } }
        public double MoneyValue { get => _moneyValue; set { SetProperty(ref _moneyValue, value); } }
        public double PersentB { get => _persentB; set { SetProperty(ref _persentB, value); } }
        public double PersentS { get => _persentS; set { SetProperty(ref _persentS, value); } }

        public Color SetColor(double value, double priceMedium, double priceCeiling, double priceFloor)
        {
            if(priceMedium == value)
            {
                return Yellow;
            }
            if(priceCeiling == value)
            {
                return Pink;
            }   
            if(priceFloor == value)
            {
                return Blue;
            }

            return UpDownColor;

        }
    }
}
