using DevExpress.XamarinForms.DataGrid;
using DevExpress.XamarinForms.Popup;
using FakeEzMobileTrading.Models;
using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FakeEzMobileTrading.ViewModels
{
    public class ActionCommandConditionPageViewModel : BaseViewModel
    {
        
        private StockItem _stockItem = new StockItem();
        private ObservableCollection<ConditionalCommand> _commandConditions;
        private ObservableCollection<StockBalance> _surplusStocks;
        private ConditionalCommand _commandDetail;
        private string _idStock, _idStock2, _idStock3, _pass = "", _showHidePassSource = "ic_hide_pass.png", _stockPrice2, _typeFilter = "Tất cả", _fromDate = DateTime.Now.ToString("dd/MM/yyyy"), _toDate = DateTime.Now.ToString("dd/MM/yyyy");
        private double _stockPrice, _stockPriceCondition, _stockAmount;
        private double _myMoney;
        private bool _stockNameVisible = false;
        private bool _showHidePass = true;
        private bool _sellBuyVisible = false, _typeTranferVisible = false;
        private bool _upDownVisible = true, _lblPriceVisible = false;
        private bool _lessMore = true;
        private bool _isBusy = false;
        private bool _tableCommandVisible = false;
        private bool _contentPageVisible = false;
        private int _currentYear, _currentMonth;
        private int _typePopup;
        public ObservableCollection<ConditionalCommand> CommandConditions { get=> _commandConditions; set { SetProperty(ref _commandConditions, value); } }
        public ConditionalCommand CommandDetail { get => _commandDetail; set { SetProperty(ref _commandDetail, value); } }
        public string IdStock
        {
            get { return _idStock; }
            set
            {
                if (value == "")
                {
                    StockNameVisible = false; StockItem = new StockItem(); 
                    StockPrice = 0; StockAmount = 0; 
                    Pass = "";
                    LblPriceVisible = false;
                    UpDownVisible = true;
                    SellBuyVisible = false;
                    TypeTranferVisible = false;
                };
                SetProperty(ref _idStock, value);
            }
        }
        public string IdStock2
        {
            get { return _idStock2; }
            set
            {
                SetProperty(ref _idStock2, value);
            }
        }
        public string IdStock3
        {
            get { return _idStock3; }
            set
            {
                SurplusStocks = new ObservableCollection<StockBalance>(App.SuplusStocks.Where(s => s.StockId.ToLower().Trim().Contains(value.ToLower().Trim())));
                SetProperty(ref _idStock3, value);
            }
        }
        public string ShowHidePassSource
        {
            get { return _showHidePassSource; }
            set
            {
                SetProperty(ref _showHidePassSource, value);
            }
        }
        public string TypeFilter
        {
            get { return _typeFilter; }
            set { SetProperty(ref _typeFilter, value); }
        }
        public string Pass
        {
            get { return _pass; }
            set { SetProperty(ref _pass, value); }
        }
        public string FromDate
        {
            get { return _fromDate; }
            set { SetProperty(ref _fromDate, value); }
        }
        public string ToDate
        {
            get { return _toDate; }
            set { SetProperty(ref _toDate, value); }
        }
        public string StockPrice2
        {
            get { return _stockPrice2; }
            set { SetProperty(ref _stockPrice2, value); }
        }
        public double StockPrice
        {
            get { return _stockPrice; }
            set { SetProperty(ref _stockPrice, value); }
        }
        public double StockPriceCondition
        {
            get { return _stockPriceCondition; }
            set { SetProperty(ref _stockPriceCondition, value); }
        }
        public double MyMoney
        {
            get { return _myMoney; }
            set { SetProperty(ref _myMoney, value); }
        }
        public double StockAmount
        {
            get { return _stockAmount; }
            set { SetProperty(ref _stockAmount, value); }
        }
        public StockItem StockItem
        {
            get { return _stockItem; }
            set { SetProperty(ref _stockItem, value); }
        }
        public int CurrentYear
        {
            get { return _currentYear; }
            set { SetProperty(ref _currentYear, value); }
        }
        public int CurrentMonth
        {
            get { return _currentMonth; }
            set { SetProperty(ref _currentMonth, value); }
        }
        public int TypePopup
        {
            get { return _typePopup; }
            set { SetProperty(ref _typePopup, value); }
        }
        public ObservableCollection<StockBalance> SurplusStocks { get => _surplusStocks; set { SetProperty(ref _surplusStocks, value); } }

        public bool StockNameVisible { get => _stockNameVisible; set { StockPriceCondition = value == false ? 0 : StockPriceCondition; SetProperty(ref _stockNameVisible, value); } }
        public bool SellBuyVisible { get => _sellBuyVisible; set { SetProperty(ref _sellBuyVisible, value); } }
        public bool TypeTranferVisible { get => _typeTranferVisible; set { SetProperty(ref _typeTranferVisible, value); } }
        public bool ShowHidePass { get => _showHidePass; set { ShowHidePassSource = value == true ? "ic_hide_pass.png" : "ic_show_pass.png"; SetProperty(ref _showHidePass, value); } }
        public bool UpDownVisible { get => _upDownVisible; set { SetProperty(ref _upDownVisible, value); } }
        public bool LblPriceVisible { get => _lblPriceVisible; set { SetProperty(ref _lblPriceVisible, value); } }
        public bool LessMore { get => _lessMore; set { SetProperty(ref _lessMore, value); } }
        public bool IsBusy { get => _isBusy; set { SetProperty(ref _isBusy, value); } }
        public bool TableCommandVisible { get => _tableCommandVisible; set { SetProperty(ref _tableCommandVisible, value); } }
        public bool ContentPageVisible { get => _contentPageVisible; set { SetProperty(ref _contentPageVisible, value); } }
        


        public ActionCommandConditionPageViewModel(Page page)
        {
            ContentPageVisible = false;
            IsBusy = true;
            Device.StartTimer(TimeSpan.FromSeconds(2), () => {
                Device.BeginInvokeOnMainThread(() =>
                {
                    IsBusy = false;
                    ContentPageVisible = true;
                    
                });
                return false;
            });
            MyMoney = 900000000;
            SurplusStocks = App.SuplusStocks;
            Pass = "";
            Preferences.Set("FCMC", "Tất cả");
            StockPrice = StockItem.PriceFloor;
            StockAmount = 0;
            Preferences.Set("ToDateCC", DateTime.Now.ToString("dd/MM/yyyy"));
            Preferences.Set("FromDateCC", DateTime.Now.ToString("dd/MM/yyyy"));
            CurrentYear = DateTime.Now.Year;
            CurrentMonth = DateTime.Now.Month;
            CommandConditions = App.CommandConditions;
            TableCommandVisible = false;
            SelectedStock = new Command(() =>
            {  
                if(!String.IsNullOrEmpty(IdStock))
                {
                    if (App.Items.FirstOrDefault(x => x.StockId == IdStock) != null)
                    {
                        StockItem = App.Items.FirstOrDefault(z => z.StockId == IdStock);
                        StockNameVisible = true;
                        StockPrice = StockItem.PriceFloor;
                        StockPriceCondition = StockItem.PriceFloor;
                        LblPriceVisible = true;
                    }
                    else
                    {
                        page.FindByName<Entry>("IdStockEntry").Text = "";
                        page.DisplayAlert("Lỗi", "Mã CK này không tồn tại vui lòng nhập lại!", "Đóng");
                        page.FindByName<Entry>("IdStockEntry").Focus();
                    }
                }
            });
            SelectedStock2 = new Command(() =>
            {
                
                if (App.Items.FirstOrDefault(x => x.StockId == IdStock2) != null)
                {
                    
                   
                }
                else
                {
                    page.DisplayAlert("Lỗi", "Mã CK này không tồn tại vui lòng nhập lại!", "Đóng");
                }

            });
            UpPrice = new Command(() =>
            {
                if (StockPrice != 0)
                {
                    StockPrice = StockPrice + 100 <= StockItem.PriceCeiling ? StockPrice + 100 : StockPrice;
                }
            });
            DownPrice = new Command(() =>
            {
                if (StockPrice != 0)
                {
                    StockPrice = StockPrice - 100 >= StockItem.PriceFloor ? StockPrice - 100 : StockPrice;
                }
            });
            UpPriceCondition = new Command(() =>
            {

                StockPriceCondition = StockPriceCondition + 100 <= StockItem.PriceCeiling ? StockPriceCondition + 100 : StockPriceCondition;

            });
            DownPriceCondition = new Command(() =>
            {

                StockPriceCondition = StockPriceCondition - 100 >= StockItem.PriceFloor ? StockPriceCondition - 100 : StockPriceCondition;

            });
            UpAmount = new Command(() =>
            {

                StockAmount = StockAmount * StockPrice < MyMoney ? StockAmount + 100 : StockAmount;

            });
            DownAmount = new Command(() =>
            {

                StockAmount = StockAmount - 100 >= 0 ? StockAmount - 100 : StockAmount;

            });
            ScrollToFirst = new Command((x) =>
            {
                var scrollView = x as ScrollView;
                var grid = page.FindByName<Grid>("gridPrice");
                scrollView.ScrollToAsync(grid, ScrollToPosition.Start, true);
            });
            ScrollToEnd = new Command((x) =>
            {
                var scrollView = x as ScrollView;
                var grid = page.FindByName<Grid>("gridPrice");
                scrollView.ScrollToAsync(grid, ScrollToPosition.End, true);
            });
            ChangeSellBuy = new Command(() =>
            {
                SellBuyVisible = SellBuyVisible == true ? false : true;
            });
            ChangeTypeTranfer = new Command(() =>
            {
                TypeTranferVisible = TypeTranferVisible == true ? false : true;
            });
            ShowOrHidePass = new Command((x) =>
            {
                var entry = x as Entry;
                ShowHidePass = ShowHidePass == true ? false : true;
            });
            ClearEntry = new Command(() =>
            {
                IdStock = "";
            });
            RadioChecked = new Command((x) =>
            {
                var button = x as RadioButton;

                switch (button.ClassId)
                {
                    case "LO": UpDownVisible = true; LblPriceVisible = true; StockPrice = StockItem.PriceFloor; break;
                    case "ATO":
                        UpDownVisible = false; LblPriceVisible = true; StockPrice2 = "ATO";
                        StockPrice = StockItem.PriceOpen;
                        break;
                    case "MP":
                        UpDownVisible = false; LblPriceVisible = false; StockPrice2 = "MP";
                        StockPrice = (SellBuyVisible == true ? StockItem.PriceS1 : StockItem.PriceB1);
                        break;
                    case "ATC": UpDownVisible = false; LblPriceVisible = false; StockPrice2 = "ATC"; StockPrice = StockItem.PriceClose; break;
                    case "GTT": UpDownVisible = false; LblPriceVisible = false; StockPrice2 = "Giá thị trường"; StockPrice = StockItem.PriceGood; break;
                    case "GT": UpDownVisible = false; LblPriceVisible = false; StockPrice2 = "Giá trần"; StockPrice = StockItem.PriceCeiling; break;
                    case "GS": UpDownVisible = false; LblPriceVisible = false; StockPrice2 = "Giá sàn"; StockPrice = StockItem.PriceFloor; break;
                }
            });
            BackToActionCommand = new Command(() =>
            {
                page.Navigation.PushAsync(new HomePage(2));
            });
            ShowMoreFilter = new Command((x) =>
            {
                var popup = x as DXPopup;
                popup.IsOpen = true;
            });
            FilterChecked = new Command((x) =>
            {
                var rdb = x as RadioButton;
                string tmp = "";
                switch (rdb.ClassId)
                {
                    case "F1": tmp = "Tất cả"; break;
                    case "F2": tmp = "Chờ kích hoạt"; break;
                    case "F3": tmp = "Thành công"; break;
                    case "F4": tmp = "Bị từ chối"; break;
                    case "F5": tmp = "Đã hủy"; break;
                    case "F6": tmp = "Hết hạn"; break;
                }
                Preferences.Set("FCMC", tmp);
                page.FindByName<DXPopup>("popup").IsOpen = false;
            });
            UpdateUI = new Command(() =>
            {
                TypeFilter = Preferences.Get("FCMC", String.Empty);

            });
            UpdateUI2 = new Command(() =>
            {
                ToDate = Preferences.Get("ToDateCC", String.Empty);
                FromDate = Preferences.Get("FromDateCC", String.Empty);

            });
            ClearFilter = new Command(() =>
            {
                TypeFilter = "Trạng thái";
            });
            ShowPopupCalendar = new Command((x) =>
            {
                int type = int.Parse((x as StackLayout).ClassId);
                InitCalendar(page, CurrentYear, CurrentMonth);
                Preferences.Set("Tp", type);
                page.FindByName<DXPopup>("popupCalendar").IsOpen = true;

            });
            SelectDate = new Command((x) =>
            {
                Button button = x as Button;
                //Nếu ngày thuộc tháng liền sau hoặc liền trước.
                if (int.TryParse(button.StyleId, out int r) == false)
                {
                    return;
                }
                Grid grid = (Grid)button.Parent;
                if (int.Parse(button.StyleId) == 0)
                {
                    button.BackgroundColor = Color.FromHex("#034E95");
                    button.CornerRadius = 30;
                    button.TextColor = Color.White;
                    button.StyleId = "1";
                    var arr = grid.Children;
                    foreach (View v in arr)
                    {
                        var b = v as Button;
                        if (v == button || b.TextColor == Color.FromHex("#929292")) { continue; }
                        b.TextColor = Color.Black;
                        if (button.ClassId != StandartDayMonth(DateTime.Now.Day) + "/" + StandartDayMonth(DateTime.Now.Month) + "/" + DateTime.Now.Year)
                        {
                            if (b.ClassId == StandartDayMonth(DateTime.Now.Day) + "/" + StandartDayMonth(DateTime.Now.Month) + "/" + DateTime.Now.Year)
                            {
                                b.BorderWidth = 1;
                                b.BorderColor = Color.FromHex("#034E95");
                                b.TextColor = Color.FromHex("#034E95");
                                b.BackgroundColor = Color.Transparent;
                            }
                        }

                        b.StyleId = "0";

                    }
                    if (Preferences.Get("Tp", 0) == 0)
                    {
                        Preferences.Set("FromDateCC", button.ClassId);
                    }
                    else
                    {
                        Preferences.Set("ToDateCC", button.ClassId);
                    }



                }
                else
                {
                    button.BackgroundColor = Color.Transparent;
                    button.CornerRadius = 30;
                    button.TextColor = Color.Black;
                    button.StyleId = "0";
                }

            });

            NextMonth = new Command(() =>
            {
                if (CurrentMonth + 1 <= 12)
                {
                    CurrentMonth++;
                }
                else
                {
                    CurrentMonth = 1;
                    CurrentYear++;

                }
                InitCalendar(page, CurrentYear, CurrentMonth);
            });
            PrevMonth = new Command(() =>
            {
                if (CurrentMonth - 1 >= 1)
                {
                    CurrentMonth--;
                }
                else
                {
                    CurrentMonth = 12;
                    CurrentYear--;
                }
                InitCalendar(page, CurrentYear, CurrentMonth);
            });
            ClosePopup = new Command((x) =>
            {
                var popup = x as DXPopup;
                popup.IsOpen = false;
            });
            SaveSelected = new Command((x) =>
            {
                var popup = x as DXPopup;
                popup.IsOpen = false;
            });
            LessTapped = new Command(() =>
            {
                LessMore = false;
            });
            MoreTapped = new Command(() =>
            {
                LessMore = true;
            });
            Buy = new Command(async () =>
            {
                //Check Mật khẩu
                //Kiểm tra các trường dữ liệu
                //Thực hiện lệnh
                if (string.IsNullOrEmpty(IdStock) || StockAmount == 0 || StockPrice == 0 || StockPriceCondition == 0)
                {
                    return;
                }
                bool b = await page.DisplayAlert("Xác nhận", "Bạn có chắc muốn đặt lệnh MUA:" + "\nMã cổ phiếu: " + IdStock + "\nTheo Loại GD: " + (TypeTranferVisible == true ? "Ký Quỹ" : "Thường") + "\nKhối lượng: " + StockAmount + "\nKhi giá khớp: " + (LessMore == true ? "Lớn hơn" : "Nhỏ hơn") + " " + StockPriceCondition + "\nGiá đặt lệnh: " + StockPrice, "Đồng ý", "Hủy bỏ");
                if (b == true)
                {
                    IsBusy = true;
                    ConditionalCommand c = new ConditionalCommand()
                    {
                        StockID = IdStock,
                        Price = StockPrice,
                        Condition = LessMore,
                        Mass = StockAmount,
                        PriceCondition = StockPriceCondition,
                        Status = "Chờ kích hoạt",
                        TypeSign = "Thường",
                        TimeOrder = DateTime.Now,
                        TimeActive = DateTime.Now.AddDays(1),
                        Type = true



                    };
                    App.CommandConditions.Insert(0, c);
                    await Task.Delay(2000);
                    IsBusy = false;
                    IdStock = "";
                    page.FindByName<RadioButton>("rdLO").IsChecked = true;
                    await page.FindByName<ScrollView>("scrollPrice").ScrollToAsync(0, 0, true);
                    await page.DisplayToastAsync("Đặt lệnh thành công!", 3000);
                }

            });
            Sell = new Command(async () =>
            {
                //Check Mật khẩu
                //Kiểm tra các trường dữ liệu
                //Thực hiện lệnh
                if (string.IsNullOrEmpty(IdStock) || StockAmount == 0 || StockPrice == 0 || StockPriceCondition==0)
                {
                    return;
                }
                bool b = await page.DisplayAlert("Xác nhận", "Bạn có chắc muốn đặt lệnh BÁN:" + "\nMã cổ phiếu: " + IdStock + "\nTheo Loại GD: " + (TypeTranferVisible == true ? "Ký Quỹ" : "Thường") + "\nKhối lượng: " + StockAmount + "\nKhi giá khớp: " + (LessMore == true ? "Lớn hơn" : "Nhỏ hơn") + " " + StockPriceCondition + "\nGiá đặt lệnh: " + StockPrice, "Đồng ý", "Hủy bỏ");
                if (b == true)
                {
                    IsBusy = true;
                    ConditionalCommand c = new ConditionalCommand()
                    {
                        StockID = IdStock,
                        Price = StockPrice,
                        Condition = LessMore,
                        Mass = StockAmount,
                        PriceCondition = StockPriceCondition,
                        Status = "Chờ kích hoạt",
                        TypeSign = "Thường",
                        TimeOrder = DateTime.Now,
                        TimeActive = DateTime.Now.AddDays(1),
                        Type = false



                    };
                    App.CommandConditions.Insert(0,c);
                    await Task.Delay(2000);
                    IsBusy = false;
                    IdStock = "";
                    page.FindByName<RadioButton>("rdLO").IsChecked = true;
                    await page.FindByName<ScrollView>("scrollPrice").ScrollToAsync(0, 0, true);
                    await page.DisplayToastAsync("Đặt lệnh thành công!", 3000);
                }
            });
            SeacrhCommandCondition = new Command(async () =>
            {
                TableCommandVisible = false;
                await Task.Delay(100);
                IsBusy = true;
                await Task.Delay(2000);
                DateTime toDate = DateTime.ParseExact(ToDate, "dd/MM/yyyy", null);
                DateTime fromDate = DateTime.ParseExact(FromDate, "dd/MM/yyyy", null);
                if (toDate > fromDate)
                {
                    if (!String.IsNullOrEmpty(IdStock2))
                    {
                        if (TypeFilter != "Tất cả" && TypeFilter != "Trạng thái")
                        {
                            CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions.Where(c => (c.TimeOrder >= fromDate && c.TimeOrder <= toDate) && c.StockID == IdStock2 && c.Status == TypeFilter));
                        }
                        else
                        {
                            CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions.Where(c => (c.TimeOrder >= fromDate && c.TimeOrder <= toDate) && c.StockID == IdStock2));
                        }
                    }
                    else
                    {
                        if (TypeFilter != "Tất cả" && TypeFilter != "Trạng thái")
                        {
                            CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions.Where(c => (c.TimeOrder >= fromDate && c.TimeOrder <= toDate) && c.Status == TypeFilter));
                        }
                        else
                        {
                            CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions.Where(c => c.TimeOrder >= fromDate && c.TimeOrder <= toDate));
                        }
                    }    
                }
                else if(toDate < fromDate)
                {
                    if (!String.IsNullOrEmpty(IdStock2))
                    {
                        if (TypeFilter != "Tất cả" && TypeFilter != "Trạng thái")
                        {
                            CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions.Where(c => (c.TimeOrder >= toDate && c.TimeOrder <= fromDate) && c.StockID == IdStock2 && c.Status == TypeFilter));
                        }
                        else
                        {
                            CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions.Where(c => (c.TimeOrder >= toDate && c.TimeOrder <= fromDate) && c.StockID == IdStock2));
                        }
                    }
                    else
                    {
                        if (TypeFilter != "Tất cả" && TypeFilter != "Trạng thái")
                        {
                            CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions.Where(c => (c.TimeOrder >= toDate && c.TimeOrder <= fromDate) && c.Status == TypeFilter));
                        }
                        else
                        {
                            CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions.Where(c => c.TimeOrder >= toDate && c.TimeOrder <= fromDate));
                        }
                    }
                }
                else
                {
                    if (!String.IsNullOrEmpty(IdStock2))
                    {
                        if (TypeFilter != "Tất cả" && TypeFilter != "Trạng thái")
                        {
                            CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions.Where(c => c.StockID == IdStock2 && c.Status == TypeFilter));
                        }
                        else
                        {
                            CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions.Where(c => c.StockID == IdStock2));
                        }
                    }
                    else
                    {
                        if (TypeFilter != "Tất cả" && TypeFilter != "Trạng thái")
                        {
                             CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions.Where(c => c.Status == TypeFilter));
                        }
                        else
                        {
                            CommandConditions = new ObservableCollection<ConditionalCommand>(App.CommandConditions);
                        }
                    }
                }
                IsBusy = false;
                page.FindByName<DataGridView>("grid3").ScrollToColumn(0);
                TableCommandVisible = true;
            });
            SelectCommand = new Command((x) =>
            {
                var command = x as ConditionalCommand;
                CommandDetail = command;
                if(command.Status!="Đã hủy")
                {
                    page.FindByName<DXPopup>("popup2").IsOpen = true;
                }    
                
                

                /*App.CommandConditions.FirstOrDefault(c => c == command).ClearSource = "";
                App.CommandConditions.FirstOrDefault(c => c == command).Status = "Đã hủy";*/
            });
            DeleteCommand = new Command(() =>
            {
                App.CommandConditions.FirstOrDefault(c => c == CommandDetail).ClearSource = "";
                App.CommandConditions.FirstOrDefault(c => c == CommandDetail).Status = "Đã hủy";
                page.FindByName<DXPopup>("popup2").IsOpen = false;
                page.FindByName<DataGridView>("grid3").ScrollToColumn(0);
            });
            HidePopup2 = new Command(() =>
            {
                page.FindByName<DXPopup>("popup2").IsOpen = false;
            });
            PriceFrameTap = new Command((x) =>
            {
                var grid = x as Grid;
                page.FindByName<RadioButton>("rdLO").IsChecked = true;
                switch (grid.ClassId)
                {
                    case "grT": StockPriceCondition = StockItem.PriceCeiling; break;
                    case "grTC": StockPriceCondition = StockItem.PriceMedium; break;
                    case "grS": StockPriceCondition = StockItem.PriceFloor; break;
                    case "grM1": StockPriceCondition = StockItem.PriceB1; break;
                    case "grK": StockPriceCondition = StockItem.PriceGood; break;
                    case "grB1": StockPriceCondition = StockItem.PriceS1; break;
                }
            });
            ShowPopup3 = new Command(() =>
            {
                page.FindByName<DXPopup>("popup3").IsOpen = true;
            });
            HidePopup3 = new Command(() =>
            {
                page.FindByName<DXPopup>("popup3").IsOpen = false;
            });

            InitCalendar(page, DateTime.Now.Year, DateTime.Now.Month);
           
        }
        public Command SelectedStock { get; }
        public Command SelectedStock2 { get; }
        public Command UpPrice { get; }
        public Command DownPrice { get; }
        public Command UpPriceCondition { get; }
        public Command DownPriceCondition { get; }
        public Command UpAmount { get; }
        public Command DownAmount { get; }
        public Command ScrollToFirst { get; }
        public Command ScrollToEnd { get; }
        public Command ChangeSellBuy { get; }
        public Command ChangeTypeTranfer { get; }
        public Command ShowOrHidePass { get; }
        public Command ClearEntry { get; }
        public Command RadioChecked { get; }
        public Command BackToActionCommand { get; }
        public Command ShowMoreFilter { get; }
        public Command FilterChecked { get; }
        public Command UpdateUI { get; }
        public Command UpdateUI2 { get; }
        public Command ClearFilter { get; }
        public Command ShowPopupCalendar { get; }
        public Command SelectDate { get; }
        public Command NextMonth { get; }
        public Command PrevMonth { get; }
        public Command ClosePopup { get; }
        public Command SaveSelected { get; }
        public Command LessTapped { get; }
        public Command MoreTapped { get; }
        public Command Sell { get; }
        public Command Buy { get; }
        public Command HidePopup2 { get; }
        public Command SeacrhCommandCondition { get; }
        public Command DeleteCommand { get; }
        public Command SelectCommand { get; }
        public Command PriceFrameTap { get; }
        public Command ShowPopup3 { get; }
        public Command HidePopup3 { get; }

        public void InitCalendar(Page page, int currentYear, int currentMonth)
        {
            var grid = page.FindByName<Grid>("gridCalendar");
            DateTime date = new DateTime(currentYear, currentMonth, 1);

            int[] arr = GetCalendarOfMonth(currentMonth, currentYear);
            grid.Children.Clear();


            int dem = 0;
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    bool valid = ((dem < (getThu(date.DayOfWeek.ToString())) || dem >= (getThu(date.DayOfWeek.ToString()) + DateTime.DaysInMonth(currentYear, currentMonth))));
                    Button b = new Button
                    {
                        Text = arr[dem].ToString(),
                        WidthRequest = 30,
                        HeightRequest = 30,
                        FontSize = 15,
                        Padding = 0,
                        BackgroundColor = Color.Transparent,
                        TextColor = valid == true ? Color.FromHex("#929292") : Color.Black,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,


                    };
                    b.IsEnabled = valid == true ? false : true;

                    b.ClassId = valid == true ? "" : StandartDayMonth(int.Parse(b.Text)) + "/" + StandartDayMonth(currentMonth) + "/" + currentYear;

                    b.StyleId = valid == true ? "" : "0";

                    b.Command = SelectDate;
                    b.CommandParameter = b;

                    Trigger pTrigger = new Trigger(typeof(Button));
                    pTrigger.Property = Button.TextColorProperty;
                    pTrigger.Value = Color.Black;

                    Setter setter = new Setter();
                    setter.Property = Button.BackgroundColorProperty;
                    setter.Value = Color.Transparent;

                    pTrigger.Setters.Add(setter);

                    b.Triggers.Add(pTrigger);

                    grid.Children.Add(b, j, i);
                    dem++;
                }
            }

            //Khởi tạo ngày hôm nay
            string id = StandartDayMonth(DateTime.Now.Day) + "/" + StandartDayMonth(DateTime.Now.Month) + "/" + DateTime.Now.Year;
            foreach (View x in grid.Children)
            {
                if ((x as Button).ClassId == id)
                {
                    (x as Button).BackgroundColor = Color.FromHex("#034E95");
                    (x as Button).CornerRadius = 30;
                    (x as Button).TextColor = Color.White;
                    (x as Button).StyleId = "1";
                }
            }

        }
        public int[] GetCalendarOfMonth(int month, int year)
        {
            DateTime date = new DateTime(year, month, 1);
            int startMonth = getThu(date.DayOfWeek.ToString());
            int dayOfMonth = DateTime.DaysInMonth(year, month);

            int[] arr = new int[42];
            int day = 0;
            for (int i = startMonth; i < startMonth + dayOfMonth; i++)
            {
                day++;
                arr[i] = day;
            }
            month = month - 1 == 0 ? 12 : month;
            int dayOfMonth2 = DateTime.DaysInMonth(year, month - 1);
            for (int j = startMonth - 1; j >= 0; j--)
            {
                arr[j] = dayOfMonth2;
                dayOfMonth2--;
            }
            int dem = 1;
            for (int k = startMonth + dayOfMonth; k < 42; k++)
            {
                arr[k] = dem;
                dem++;
            }
            return arr;
        }
        private string StandartDayMonth(int dayOrMonth) => (dayOrMonth < 10) ? "0" + dayOrMonth : dayOrMonth.ToString();
        public int getThu(string WeekOfDay)
        {

            switch (WeekOfDay)
            {
                case "Monday": return 0;
                case "Tuesday": return 1;
                case "Wednesday": return 2;
                case "Thursday": return 3;
                case "Friday": return 4;
                case "Saturday": return 5;
                case "Sunday": return 6;
                default: return 100;

            }
        }

    }
}
