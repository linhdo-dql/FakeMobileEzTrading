using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FakeEzMobileTrading.Models.ItemStatistic
{
    public class PriceStatistic : BaseViewModel
    {
        private string _date;
        private double _priceFloor;
        private double _priceCeiling;
        private double _priceMedium;
        private double _priceOpen;
        private double _priceClose;
        private double _priceLow;
        private double _priceHigh;
        private double _goodMass;
        private double _agreeMass;
        public Color Green = Color.FromArgb(0, 254, 0);
        public Color Red = Color.OrangeRed;
        public Color Pink = Color.DeepPink;
        public Color Blue = Color.DeepSkyBlue;
        public Color Yellow = Color.Yellow;
        public Color White = Color.White;
        public Color Black = Color.Black;
        public double UpDownPrice => PriceClose - PriceMedium;
        public double Persent => UpDownPrice / PriceMedium * 100;
        public double PriceAvg => (PriceHigh + PriceLow) / 2;

        public string Date { get => _date; set { SetProperty(ref _date, value); } }
        public double PriceFloor { get => _priceFloor; set { SetProperty(ref _priceFloor, value); } }
        public double PriceCeiling { get => _priceCeiling; set { SetProperty(ref _priceCeiling, value); } }
        public double PriceMedium { get => _priceMedium; set { SetProperty(ref _priceMedium, value); } }
        public double PriceOpen { get => _priceOpen; set { SetProperty(ref _priceOpen, value); } }
        public double PriceClose { get => _priceClose; set { SetProperty(ref _priceClose, value); } }
        public double PriceLow { get => _priceLow; set { SetProperty(ref _priceLow, value); } }
        public double PriceHigh { get => _priceHigh; set { SetProperty(ref _priceHigh, value); } }
        public double GoodMass { get => _goodMass; set { SetProperty(ref _goodMass, value); } }
        public double GoodValue => PriceAvg * GoodMass; 
        public double AgreeMass { get => _agreeMass; set { SetProperty(ref _agreeMass, value); } }
        public double AgreeValue => PriceAvg * AgreeMass; 
        public double TotalMass => GoodMass + AgreeMass;
        public double TotalValue => GoodValue + AgreeValue;
        public Color PriceOpenColor => SetColor(PriceOpen, PriceMedium, PriceCeiling, PriceFloor);
        public Color PriceCloseColor => SetColor(PriceClose, PriceMedium, PriceCeiling, PriceFloor);
        public Color PriceLowColor => SetColor(PriceLow, PriceMedium, PriceCeiling, PriceFloor);
        public Color PriceHighColor => SetColor(PriceHigh, PriceMedium, PriceCeiling, PriceFloor);
        public Color PriceAvgColor => SetColor(PriceAvg, PriceMedium, PriceCeiling, PriceFloor);
        public Color UpDownColor => UpDownPrice > 0 ? Green : Red;

        public Color SetColor(double value, double priceMedium, double priceCeiling, double priceFloor)
        {
            if (value == priceMedium)
            {
                return Yellow;
            }
            else if (value == priceCeiling)
            {
                return Pink;
            }
            else if (value == priceFloor)
            {
                return Blue;
            }
            else if (value > priceMedium)
            {
                return Green;
            }
            else if (value < priceMedium)
            {
                return Red;
            }
            else
            {
                return UpDownColor;
            }

        }
    }
}
