using System;
using System.Collections.Generic;
using System.Text;

namespace FakeEzMobileTrading.Models
{
    public class New
    {

        private int _id;
        private string _stockId;
        private string _title;
        private string _datetimeN;
        private string source;
       

        public string StockId { get => _stockId; set => _stockId = value; }
        public string Title { get => _title; set => _title = value; }
        public string DatetimeN { get => _datetimeN; set => _datetimeN = value; }
        public string Source { get => source; set => source = value; }
        public int Id { get => _id; set => _id = value; }
    }
}
