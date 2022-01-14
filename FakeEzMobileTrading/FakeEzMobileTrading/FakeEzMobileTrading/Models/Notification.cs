using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FakeEzMobileTrading.Models
{
    public class Notification : BaseViewModel
    {
        public int Type { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime TimeCreated { get; set; }
        private bool _isActive = false;
        public bool IsActive { get => _isActive; set { SetProperty(ref _isActive, value); } }
        private bool _more = false;
        public bool More { 
            get => _more; 
            set 
            {
                if(value == true)
                {
                    MaxLine = 10;
                }
                else
                {
                    MaxLine = 2;
                }
                SetProperty(ref _more, value); 
            } 
        }

        private int _maxLine = 2;
        public int MaxLine { get=> _maxLine; set { SetProperty(ref _maxLine, value); } }
        public string ColorActive => IsActive == true ? "#FFFFFF" : "#F1F1F1"; 
        public string DateTimeAgo => CalTimes(TimeCreated, DateTime.Now);
        public string TypeSoure => Type == 1 ? "ic_no_bell.png" : (Type == 2 ? "ic_no_document.png" : (Type == 3 ? "ic_no_setting.png" : ""));
        public string CalTimes (DateTime timeFrom, DateTime timeTo)
        {
            string result = "";
            TimeSpan ts = timeTo - timeFrom;
            int tsDays = (int)ts.TotalDays;
            if(tsDays >= 30)
            {
                if(tsDays >= 365)
                {
                    result = (tsDays / 365) + " năm";
                }
                else
                {
                    result = tsDays / 30 + " tháng";
                }
            }
            else
            {
                if (tsDays >= 7)
                {
                    result = (tsDays / 7) + " tuần";
                }
                else
                {
                    if(tsDays >= 1)
                    {
                        result = tsDays + " ngày";
                    }
                    else
                    {
                        int tsHours = (int)ts.TotalHours;
                        if(tsHours >= 1)
                        {
                            result = tsHours + " giờ";
                        }
                        else
                        {
                            int tsMinutes = (int)ts.TotalMinutes;
                            if(tsMinutes >= 1)
                            {
                                result = tsMinutes + " phút";
                            }
                            else
                            {
                                int tsSeconds = (int)ts.TotalSeconds;
                                result = tsSeconds + " giây";
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
