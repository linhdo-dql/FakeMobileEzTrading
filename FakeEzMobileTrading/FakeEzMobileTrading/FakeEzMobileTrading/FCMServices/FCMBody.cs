using System;
using System.Collections.Generic;
using System.Text;

namespace FakeEzMobileTrading.FCMServices
{
    public class FCMBody
    {
        public string[] Id { get; set; }
        public FCMNotify Notification { get; set; }
        public FCMData Data { get; set; }
    }
}
