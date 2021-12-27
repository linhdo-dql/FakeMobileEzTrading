using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.Views;
using MUAHO.ViewModels;
using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading
{
    public partial class App : Application
    {
        public static ObservableCollection<StockExchange> Exchanges { get; set; } = new ObservableCollection<StockExchange>()
        {
            new StockExchange() {ExchangeId="VNI",
                                 TypeExchange="HSX",
                                 ExchangeName="UPCOM:VNI",
                                 ExchangePrice=147703,
                                 ExchangeMass = 889477822,
                                 ExchangeUpDown=2007,
                                 ExchangePersent=138,
                                 ExchangeValue = 2543355,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=0.42, UpdownP1=6.14,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 IsFavourite = true
            },
            new StockExchange() {ExchangeId="VN100",
                                 TypeExchange="HSX",
                                 ExchangeName="VN100",
                                 ExchangePrice=149258,
                                 ExchangeMass = 459281600,
                                 ExchangeUpDown=2657,
                                 ExchangePersent=181,
                                 ExchangeValue = 1675240,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07
            },
            new StockExchange() {ExchangeId="VNSML",
                                 TypeExchange="HSX",
                                 ExchangeName="VNSML",
                                 ExchangePrice=213820,
                                 ExchangeMass = 233566700,
                                 ExchangeUpDown=-477,
                                 ExchangePersent=-22,
                                 ExchangeValue = 470851,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07
            },
            new StockExchange() {ExchangeId="VNALL",
                                 TypeExchange="HSX",
                                 ExchangeName="VNALL",
                                 ExchangePrice=152957,
                                 ExchangeMass = 703848300,
                                 ExchangeUpDown=2474,
                                 ExchangePersent=164,
                                 ExchangeValue = 2146090,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 IsFavourite = true
            },
            new StockExchange() {ExchangeId="VNMID",
                                 TypeExchange="HSX",
                                 ExchangeName="VNMID",
                                 ExchangePrice=216778,
                                 ExchangeMass = 459281600,
                                 ExchangeUpDown=3145,
                                 ExchangePersent=147,
                                 ExchangeValue = 851074,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07
            },
            new StockExchange() {ExchangeId="HNX30",
                                 TypeExchange="HNX",
                                 ExchangeName="HNX30",
                                 ExchangePrice=75311,
                                 ExchangeMass = 39230900,
                                 ExchangeUpDown=507,
                                 ExchangePersent=68,
                                 ExchangeValue = 175207,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07
            },
            new StockExchange() {ExchangeId="HNXCON",
                                 TypeExchange="HNX",
                                 ExchangeName="HNXCON",
                                 ExchangePrice=49405,
                                 ExchangeMass = 17801800,
                                 ExchangeUpDown=178,
                                 ExchangePersent=36,
                                 ExchangeValue = 2543355,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07
            },
            new StockExchange() {ExchangeId="HNXFIN",
                                 TypeExchange="HNX",
                                 ExchangeName="HNXFIN",
                                 ExchangePrice=95778,
                                 ExchangeMass = 15499900,
                                 ExchangeUpDown=1746,
                                 ExchangePersent=186,
                                 ExchangeValue = 48748,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07
            },
            new StockExchange() {ExchangeId="HNX",
                                 TypeExchange="HNX",
                                 ExchangeName="HNXINDEX",
                                 ExchangePrice=44561,
                                 ExchangeMass = 11517650,
                                 ExchangeUpDown=300,
                                 ExchangePersent=68,
                                 ExchangeValue = 2999696,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 IsFavourite = true
            },
            new StockExchange() {ExchangeId="HNXLCAP",
                                 TypeExchange="HNX",
                                 ExchangeName="HNXLCAP",
                                 ExchangePrice=5128,
                                 ExchangeMass = 61926700,
                                 ExchangeUpDown=419,
                                 ExchangePersent=82,
                                 ExchangeValue = 217271,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07
            },
            new StockExchange() {ExchangeId="HNXMAN",
                                 TypeExchange="HNX",
                                 ExchangeName="HNXMAN",
                                 ExchangePrice=24455,
                                 ExchangeMass = 18238500,
                                 ExchangeUpDown=-48,
                                 ExchangePersent=-14,
                                 ExchangeValue = 37444,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07
            },
            new StockExchange() {ExchangeId="HNXSCAP",
                                 TypeExchange="HNX",
                                 ExchangeName="HNXSCAP",
                                 ExchangePrice=1580,
                                 ExchangeMass = 53249800,
                                 ExchangeUpDown=158,
                                 ExchangePersent=15,
                                 ExchangeValue = 217271,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07
            },
            new StockExchange() {ExchangeId="UPCOM",
                                 TypeExchange="HNX",
                                 ExchangeName="UPCOM",
                                 ExchangePrice=1120,
                                 ExchangeMass = 14338190,
                                 ExchangeUpDown=67,
                                 ExchangePersent=61,
                                 ExchangeValue = 170568,
                                 MassTT = 33617383,
                                 ValueTT = 2544355,
                                 PriceP1=146310, MassP1=328817, ValueP1=1691, PersentP1=6.14, UpdownP1=0.42,
                                 PriceP2=147588, MassP2=851587207, ValueP2=2423565, PersentP2 = 1.3, UpdownP2=18.92,
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07
            }
            



        };
        public static ObservableCollection<StockItem> Items = new ObservableCollection<StockItem>()
        {
                new StockItem(){ StockId="VCB",PriceMedium=76900, PriceCeiling=82200, PriceFloor=71600, PriceB3=76300, PriceB3X=1800, PriceB2=76400,PriceB2X=1300,PriceB1=76500,PriceB1X=80700,PriceS1=76900,PriceS1X=18900,PriceS2=77000,PriceS2X=100,PriceS3=77300,PriceS3X=1300,TotalMass=1489000,PriceOpen=77500,PriceMax=78900,PriceMin=76500,ForeignB=285700,ForeignS=643900,PriceGood=76500, PriceGoodX = 80700, ExchangeId="VNI" } ,
                new StockItem(){ StockId="PVC",PriceMedium=14700, PriceCeiling=16100, PriceFloor=13300, PriceB3=15700, PriceB3X=12200, PriceB2=15800,PriceB2X=10200,PriceB1=15900,PriceB1X=30900,PriceS1=16000,PriceS1X=18500,PriceS2=16100,PriceS2X=163900,PriceS3=0,PriceS3X=0,TotalMass=2961800,PriceOpen=14800,PriceMax=16100,PriceMin=14200,ForeignB=800,ForeignS=3000,PriceGood=16000, PriceGoodX = 100, ExchangeId="VNI"},
                new StockItem(){ StockId="VCB",PriceMedium=76900, PriceCeiling=82200, PriceFloor=71600, PriceB3=76300, PriceB3X=1800, PriceB2=76400,PriceB2X=1300,PriceB1=76500,PriceB1X=80700,PriceS1=76900,PriceS1X=18900,PriceS2=77000,PriceS2X=100,PriceS3=77300,PriceS3X=1300,TotalMass=1489000,PriceOpen=77500,PriceMax=78900,PriceMin=76500,ForeignB=264900,ForeignS=320100,PriceGood=76500, PriceGoodX = 80700, ExchangeId="VNI" },
                new StockItem(){ StockId="AAA",PriceMedium=20000, PriceCeiling=21400, PriceFloor=18600, PriceB3=21300, PriceB3X=88100, PriceB2=21350,PriceB2X=34900,PriceB1=21400,PriceB1X=106900,PriceS1=0,PriceS1X=0,PriceS2=0,PriceS2X=0,PriceS3=0,PriceS3X=0,TotalMass=18312800,PriceOpen=18700,PriceMax=18700,PriceMin=17300,ForeignB=59300,ForeignS=487300,PriceGood=21400, PriceGoodX = 328200, ExchangeId="VNI" }
        };
        public static ObservableCollection<StockFollowList> CollectionsList { get; set; } = new ObservableCollection<StockFollowList>()
        {
               
        };
        public App()
        {
            InitializeComponent();
            DevExpress.XamarinForms.DataGrid.Initializer.Init();
            DevExpress.XamarinForms.Navigation.Initializer.Init();
            DevExpress.XamarinForms.Editors.Initializer.Init();
            if(!Preferences.ContainsKey("CurrentFollowList"))
            {

            }    
            MainPage = new NavigationPage( new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
