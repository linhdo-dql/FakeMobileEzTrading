using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace FakeEzMobileTrading.Models
{
    public class SurplusStock
    {
        private string _stockId;
        private double _mass;
        private double _persentBorrow;
        private DateTime _dateEnd;
        private bool _status;

        public string StockId { get => _stockId; set => _stockId = value; }
        public double Mass { get => _mass; set => _mass = value; }
        public double PersentBorrow { get => _persentBorrow; set => _persentBorrow = value; }
        public DateTime DateEnd { get => _dateEnd; set => _dateEnd = value; }
        public bool Status { get => _status; set => _status = value; }

        public Color TextColors => Status == true ? Color.PaleVioletRed : Color.Orange;
    }
}
