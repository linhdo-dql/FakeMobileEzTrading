using DevExpress.XamarinForms.Editors;
using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.Views;
using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FakeEzMobileTrading.ViewModels.HomePageViewModels
{
    public class SendMoneyPageViewModel : BaseViewModel
    {
       
        public string _strMoney;
        public string StrMoney
        {
            get { return _strMoney; }
            set { SetProperty(ref _strMoney, value); }
        }
        private string _moneyToLetter = "";
        public string MoneyToLetter
        {
            get { return _moneyToLetter; }
            set { SetProperty(ref _moneyToLetter, value); }
        }

        private bool _showHidePass = true;
        public bool ShowHidePass
        {
            get 
            {
                return _showHidePass;
            }
            set
            {
                ShowHidePassSource = value == true ? "ic_hide_pass.png" : "ic_show_pass.png";
                SetProperty(ref _showHidePass, value);
            }
        }

        public double _feeMoney = 0;
        public double FeeMoney { 
            get { return _feeMoney; } 
            set 
            {
                if (value == 0)
                {
                    StrFeeMoney = "0";
                }
                else
                {
                    StrFeeMoney = String.Format("{0:#,#}", value);
                }
                SetProperty(ref _feeMoney, value); 
            } 
        }
        private string _strContent = ""; 
        public string StrContent { get => _strContent; set { SetProperty(ref _strContent, value); } }
        private string _strFeeMoney = "0";
        public string StrFeeMoney { get => _strFeeMoney; set { SetProperty(ref _strFeeMoney, value); } }
        private string _pass = "";
        public string Pass { get => _pass; set { SetProperty(ref _pass, value); } }
        private double _money = 0;
        public double Money
        {
            get { return _money; }
            set
            {
                MoneyToLetter = NumberToText(value);
                if(FormSend.ID != 100)
                {
                    if (value < 67000000)
                    {
                        FeeMoney = 11000;
                    }
                    else if (value >= 67000000 && value < 3334000000)
                    {
                        FeeMoney = (int)(value * (0.0165 / 100));
                    }
                    else
                    {
                        FeeMoney = 550000;
                    }
                }
                SetProperty(ref _money, value);
            }
        }
        private string _showHidePassSource = "ic_hide_pass.png";
        public string ShowHidePassSource
        {
            get
            {
                return _showHidePassSource;
            }
            set
            {
                SetProperty(ref _showHidePassSource, value);
            }
        }

        public string DateSend { get; set; }
        private FormSend _formSend;
        public FormSend FormSend
        {
            get { return _formSend; }
            set { SetProperty( ref _formSend, value); } 
        }
        public SendMoneyPageViewModel(Page page)
        {
            

            int formId = Preferences.Get("FormSend", 0);
            if (formId != 100)
            {
                FormSend = App.FormSends.FirstOrDefault(f => f.ID == formId);
                page.FindByName<Frame>("frame1").BorderColor = Color.Transparent;
                page.FindByName<Frame>("frame2").BorderColor = Color.Transparent;
                page.FindByName<Frame>("frame3").BorderColor = Color.Transparent;
            }
            else
            {
                FormSend = new FormSend() {ID=100, Number = "Nhập số tài khoản", Name = "Tên người thụ hưởng", Address = "Ngân hàng thụ hưởng" };
            }
            string mony = Preferences.Get("tmpM", "");
            if(mony!="")
            {
                Money = double.Parse(mony.Replace(".", ""));
                StrMoney = String.Format("{0:#,#}", Money);
            }
            
            DateSend = DateTime.Now.ToString("dd/MM/yyyy");
            FormatChanged = new Command(() =>
            {
                
               
                    if (!String.IsNullOrEmpty(StrMoney))
                    {
                        page.FindByName<Frame>("frameMoney").BorderColor = Color.Transparent;
                        Money = double.Parse(StrMoney);
                        StrMoney = String.Format("{0:#,#}", Money);
                    }
                    else
                    {
                        MoneyToLetter = "";
                        FeeMoney = 0;
                    }
                
                
                
            });
            ShowHide = new Command(() =>
            {
                ShowHidePass = ShowHidePass == true ? false : true;
            });
            SwitchFormSendPage = new Command(async () =>
            {
                Preferences.Set("tmpM", StrMoney);
                await page.Navigation.PushAsync(new FormSendPage());
            });
            Accept = new Command(() =>
            {
                var frameMoney = page.FindByName<Frame>("frameMoney");
                var frame1 = page.FindByName<Frame>("frame1");
                var frame2 = page.FindByName<Frame>("frame2");
                var frame3 = page.FindByName<Frame>("frame3");
                var frameContent = page.FindByName<Frame>("frameContent");
                var framePass = page.FindByName<Frame>("framePass");
                bool valid = true;
                if(String.IsNullOrEmpty(StrMoney))
                {
                    frameMoney.BorderColor = Color.Red;
                    valid = false;
                }
                else
                {
                    frameMoney.BorderColor = Color.Transparent;
                }
                if(FormSend.ID==100)
                {
                    frame1.BorderColor = Color.Red;
                    frame2.BorderColor = Color.Red;
                    frame3.BorderColor = Color.Red;
                    valid = false;
                }
                else
                {
                    frame1.BorderColor = Color.Transparent;
                    frame2.BorderColor = Color.Transparent;
                    frame3.BorderColor = Color.Transparent;
                }
                if(String.IsNullOrEmpty(StrContent))
                {
                    frameContent.BorderColor = Color.Red;
                    valid = false;
                }
                else
                {
                    frameContent.BorderColor = Color.Transparent;
                }
                if (String.IsNullOrEmpty(Pass))
                {
                    framePass.BorderColor = Color.Red;
                    valid = false;
                }
                else
                {
                    framePass.BorderColor = Color.Gray;
                }
                if(valid==true)
                {
                    page.DisplayAlert("All", "Thành Công", "OK");
                }
                else
                {
                    page.DisplayAlert("Chuyển tiền", "Bạn vui lòng nhập đủ thông tin.", "OK");
                }
                
            });
            ContentTextChanged = new Command(() =>
            {
                page.FindByName<Frame>("frameContent").BorderColor = Color.Transparent;
            });
            PassTextChanged = new Command(() =>
            {
                page.FindByName<Frame>("framePass").BorderColor = Color.Gray;
            });
        }
        public Command FormatChanged { get; }
        public Command ShowHide { get; }
        public Command SwitchFormSendPage { get; }
        public Command Accept { get; }
        public Command ContentTextChanged { get; }
        public Command PassTextChanged { get; }

        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            if(inputNumber==0)
            {
                return "";
            }     
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };  

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            return result + (suffix ? " đồng chẵn." : "");
        }
    }

}
