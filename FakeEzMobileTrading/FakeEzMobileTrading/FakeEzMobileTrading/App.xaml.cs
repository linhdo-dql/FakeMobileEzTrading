using FakeEzMobileTrading.Models;
using FakeEzMobileTrading.Models.ItemStatistic;
using FakeEzMobileTrading.Views;
using MUAHO.ViewModels;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading
{
    public partial class App : Application
    {
        public static ObservableCollection<StockExchange> Exchanges = new ObservableCollection<StockExchange>()
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
                                 IsFavourite = true,
                                 TimeRefresh = 4
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
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 TimeRefresh = 5
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
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 TimeRefresh = 7
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
                                 IsFavourite = true,
                                 TimeRefresh = 6
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
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 TimeRefresh = 10
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
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 TimeRefresh = 6
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
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 TimeRefresh = 8
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
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 TimeRefresh = 5
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
                                 IsFavourite = true,
                                 TimeRefresh = 7
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
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 TimeRefresh = 9
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
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 IsFavourite = true  ,
                                 TimeRefresh = 3
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
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 TimeRefresh = 7
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
                                 PriceP3=147703, MassP3=887579252, ValueP3=2532002, PersentP3 = 1.38, UpdownP3= 20.07,
                                 TimeRefresh = 5
            }
            


        };

        public static ObservableCollection<StockItem> Items = new ObservableCollection<StockItem>()
        {
                new StockItem(){ StockId="VCB",PriceMedium=76900, PriceCeiling=82200, PriceFloor=71600, PriceB3=76300, PriceB3X=1800, PriceB2=76400,PriceB2X=1300,PriceB1=76500,PriceB1X=80700,PriceS1=76900,PriceS1X=18900,PriceS2=77000,PriceS2X=100,PriceS3=77300,PriceS3X=1300,TotalMass=1489000,PriceOpen=77500,PriceMax=78900,PriceMin=76500,ForeignB=285700,ForeignS=643900,PriceGood=76500, PriceGoodX = 80700, ExchangeId="VNI", FloorId="HOSE", StockName="Ngân hàng Cổ phần Ngoại thương Việt Nam VIETCOMBANK", MassAllowOwn=1112663234, MassOwning=873055660,MassStillAllowB=239607574, PersentB=23.57,ForeignBYTD=-7199440,ForeignBMTD=-3556000,DateUpdate="03/01/2022", PriceClose=71500, RefeshPrice = true, TimeRefresh = 9, TimeRefreshB1 = new Random().Next(3,15), TimeRefreshB2 = new Random().Next(3,15), TimeRefreshB3 = new Random().Next(3,15), TimeRefreshS1 = new Random().Next(2,22), TimeRefreshS2 = new Random().Next(3,20), TimeRefreshS3 = new Random().Next(2,20)  } ,
                new StockItem(){ StockId="LIC",PriceMedium=61400, PriceCeiling=70600, PriceFloor=52200, PriceB3=59000, PriceB3X=100, PriceB2=59500,PriceB2X=100,PriceB1=60000,PriceB1X=500,PriceS1=64000,PriceS1X=400,PriceS2=64300,PriceS2X=100,PriceS3=64400,PriceS3X=2900,TotalMass=25900,PriceOpen=61400,PriceMax=70000,PriceMin=60000,ForeignB=0,ForeignS=0,PriceGood=60000, PriceGoodX = 100, ExchangeId="VNI", FloorId="HNX", StockName="Tổng công ty Licogi", MassAllowOwn=1112663234, MassOwning=873055660,MassStillAllowB=239607574, PersentB=23.57,ForeignBYTD=-7199440,ForeignBMTD=-3556000,DateUpdate="03/01/2022", PriceClose=71500, RefeshPrice = true,  TimeRefresh = 6 ,TimeRefreshB1 = new Random().Next(6,15), TimeRefreshB2 = new Random().Next(3,15), TimeRefreshB3 = new Random().Next(3,15), TimeRefreshS1 = new Random().Next(2,17), TimeRefreshS2 = new Random().Next(2,22), TimeRefreshS3 = new Random().Next(3,20)},
                new StockItem(){ StockId="MSN",PriceMedium=144900, PriceCeiling=155000, PriceFloor=134800, PriceB3=144100, PriceB3X=1100, PriceB2=144200,PriceB2X=1100,PriceB1=144400,PriceB1X=500,PriceS1=144800,PriceS1X=12100,PriceS2=145000,PriceS2X=400,PriceS3=145500,PriceS3X=2000,TotalMass=974500,PriceOpen=145000,PriceMax=146800,PriceMin=141600,ForeignB=556400,ForeignS=554200,PriceGood=144800, PriceGoodX = 54400, ExchangeId="VNI", FloorId ="HOSE", StockName="Công ty cổ phần Tập đoàn MASSAN", MassAllowOwn=1112663234, MassOwning=873055660,MassStillAllowB=239607574, PersentB=23.57,ForeignBYTD=-7199440,ForeignBMTD=-3556000,DateUpdate="03/01/2022", PriceClose=71500, RefeshPrice = true,  TimeRefresh = 5, TimeRefreshB1 = new Random().Next(3,15), TimeRefreshB2 = new Random().Next(3,15), TimeRefreshB3 = new Random().Next(3,15), TimeRefreshS1 = new Random().Next(2,22), TimeRefreshS2 = new Random().Next(2,20), TimeRefreshS3 = new Random().Next(2,17) },
                new StockItem(){ StockId="VNM",PriceMedium=83100, PriceCeiling=88900, PriceFloor=77300, PriceB3=82900, PriceB3X=83500, PriceB2=83000,PriceB2X=16400,PriceB1=83100,PriceB1X=10700,PriceS1=82300,PriceS1X=9700,PriceS2=83300,PriceS2X=22800,PriceS3=83400,PriceS3X=12800,TotalMass=1711600,PriceOpen=83400,PriceMax=83700,PriceMin=82900,ForeignB=401400,ForeignS=391400,PriceGood=82100, PriceGoodX = 68000, ExchangeId="HNX", FloorId = "HSX", StockName ="Công ty cổ phần sữa Việt Nam", MassAllowOwn=1112663234, MassOwning=873055660,MassStillAllowB=239607574, PersentB=23.57,ForeignBYTD=-7199440,ForeignBMTD=-3556000,DateUpdate="03/01/2022", PriceClose=71500, RefeshPrice = true, TimeRefresh = 8, TimeRefreshB1 = new Random().Next(3,15), TimeRefreshB2 = new Random().Next(3,15), TimeRefreshB3 = new Random().Next(3,15), TimeRefreshS1 = new Random().Next(2,22), TimeRefreshS2 = new Random().Next(3,20), TimeRefreshS3 = new Random().Next(2,20)},
                new StockItem(){ StockId="VIC",PriceMedium=100800, PriceCeiling=107800, PriceFloor=93800, PriceB3=99600, PriceB3X=2000, PriceB2=99700,PriceB2X=15800,PriceB1=99800,PriceB1X=2800,PriceS1=100300,PriceS1X=4800,PriceS2=100400,PriceS2X=1700,PriceS3=100500,PriceS3X=34200,TotalMass=10057000,PriceOpen=101000,PriceMax=101000,PriceMin=99300,ForeignB=102100,ForeignS=103860,PriceGood=100300, PriceGoodX = 10000, ExchangeId="VNI", FloorId = "HSX", StockName ="Tập đoàn VINGROUP - Công ty cổ phần VIN", MassAllowOwn=1112663234, MassOwning=873055660,MassStillAllowB=239607574, PersentB=23.57,ForeignBYTD=-7199440,ForeignBMTD=-3556000,DateUpdate="03/01/2022", PriceClose=111500, RefeshPrice = true, TimeRefresh = 11, TimeRefreshB1 = new Random().Next(3,15), TimeRefreshB2 = new Random().Next(3,15), TimeRefreshB3 = new Random().Next(3,15), TimeRefreshS1 = new Random().Next(2,22), TimeRefreshS2 = new Random().Next(3,20), TimeRefreshS3 = new Random().Next(2,17)}
        };
        public static ObservableCollection<StockFollowList> CollectionsList = new ObservableCollection<StockFollowList>()
        {
               new StockFollowList() 
               {
                   Name="Newbie", IsShowing= true, StockItemList= new ObservableCollection<StockItem>()
                    {
                        Items[0], Items[3], Items[1], Items[4], Items[2]
                    } 
               } 
        };
        public static ObservableCollection<ItemStatistic> ItemStatistics = new ObservableCollection<ItemStatistic>()
        {
               new ItemStatistic() {StockIdStatistic ="VCB", 
                    PriceStatistic = new ObservableCollection<PriceStatistic>() 
                    {
                       new PriceStatistic() {Date = "22/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "23/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "24/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0}, 
                       new PriceStatistic() {Date = "25/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "26/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "27/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "28/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "29/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "30/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "01/01/2022", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "02/01/2022", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "03/01/2022", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                    } 
               },
               new ItemStatistic() {StockIdStatistic ="PVC",
                    PriceStatistic = new ObservableCollection<PriceStatistic>()
                    {
                       new PriceStatistic() {Date = "22/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "23/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "24/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "25/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "26/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "27/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "28/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "29/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "30/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "01/01/2022", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "02/01/2022", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "03/01/2022", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                    }
               },
               new ItemStatistic() {StockIdStatistic ="MSN",
                    PriceStatistic = new ObservableCollection<PriceStatistic>()
                    {
                       new PriceStatistic() {Date = "22/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "23/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "24/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "25/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "26/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "27/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "28/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "29/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "30/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "01/01/2022", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "02/01/2022", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "03/01/2022", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                    }
               },
               new ItemStatistic() {StockIdStatistic ="LIC",
                    PriceStatistic = new ObservableCollection<PriceStatistic>()
                    {
                       new PriceStatistic() {Date = "22/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "23/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "24/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "25/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "26/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "27/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "28/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "29/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "30/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "01/01/2022", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "02/01/2022", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "03/01/2022", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                    }
               },
               new ItemStatistic() {StockIdStatistic ="VIC",
                    PriceStatistic = new ObservableCollection<PriceStatistic>()
                    {
                       new PriceStatistic() {Date = "22/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "23/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "24/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "25/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "26/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "27/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "28/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "29/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "30/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "01/01/2022", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "02/01/2022", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "03/01/2022", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                    }
               },
               new ItemStatistic() {StockIdStatistic ="VNM",
                    PriceStatistic = new ObservableCollection<PriceStatistic>()
                    {
                       new PriceStatistic() {Date = "22/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "23/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "24/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "25/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "26/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "27/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "28/12/2021", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "29/12/2021", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "30/12/2021", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                       new PriceStatistic() {Date = "01/01/2022", PriceCeiling=81900, PriceFloor=71300, PriceMedium =98900, PriceOpen=77000, PriceClose=76900, PriceHigh=77800, PriceLow=76600,GoodMass=1915300, AgreeMass=0},
                       new PriceStatistic() {Date = "02/01/2022", PriceCeiling=82200, PriceFloor=71600, PriceMedium =76900, PriceOpen=77500, PriceClose=76500, PriceHigh=78900, PriceLow=76500,GoodMass=1489000, AgreeMass=0},
                       new PriceStatistic() {Date = "03/01/2022", PriceCeiling=81200, PriceFloor=71200, PriceMedium =76500, PriceOpen=76800, PriceClose=78500, PriceHigh=77800, PriceLow=78500,GoodMass=849400, AgreeMass=0},
                    }
               }
        };
        public static ObservableCollection<CompanyNew> CompanyNews = new ObservableCollection<CompanyNew>()
        {
            new CompanyNew() {Id="VCB",Title="Thông báo kí hợp đồng cung cấp dịch vụ kiểm toán BCTC năm 2022", Created=DateTime.Now},
            new CompanyNew() {Id="VCB",Title="CBTT Phó TGĐ Đào Minh Tuấn không còn là PGĐ từ ngày 01/12/2021", Created=DateTime.Now},
            new CompanyNew() {Id="VCB",Title="Thông báo kết quả chào bán trái phiếu riêng lẻ của mã trái phiếu VCB2131008 đợt 8 năm 2021", Created=DateTime.Now},
            new CompanyNew() {Id="VCB",Title="Thông báo về việc đăng kí cuối cùng trả cổ tức năm 2020 bằng tiền và phát hành cổ phiếu để trả cổ tức năm 2019", Created=DateTime.Now},
            new CompanyNew() {Id="VCB",Title="Nghi quyết HĐQT về việc phê duyệt phương án phân phối lợi nhuận năm 2020", Created=DateTime.Now},
            new CompanyNew() {Id="VCB",Title="Nghị quyết HĐQT về việc phê duyệt kế hoạch chi trả cổ tức năm 2020 bằng tiền năm 2019 bằng cổ phiếu", Created=DateTime.Now},
            new CompanyNew() {Id="VCB",Title="Thông báo công văn của UBCKNN về hồ sơ mời thầu cổ phiếu VCB0123183 năm 2021", Created=DateTime.Now}
        };
        public static ObservableCollection<ConditionalCommand> CommandConditions = new ObservableCollection<ConditionalCommand>()
        {
           new ConditionalCommand(){ StockID = "FTS", Mass = 100, Price=55000, Condition=true, PriceCondition = 54300, Status="Chờ kích hoạt", TypeSign="Ký quỹ", TimeOrder= DateTime.Now, TimeActive = DateTime.Now, Type = true },
           new ConditionalCommand(){ StockID = "FTS", Mass = 100, Price=55000, Condition=true, PriceCondition = 54300, Status="Thành công", TypeSign="Ký quỹ", TimeOrder= DateTime.ParseExact("12/01/2022","dd/MM/yyyy", null), TimeActive = DateTime.Now, Type =  false },
        };
        public static ObservableCollection<New> ActionEvents = new ObservableCollection<New>()
        {
           new New() {Id=1, StockId="C32", Title="Thông báo về ngày đăng ký cuối cùng tạm ứng cổ tức đợt 1 năm 2021 bằng tiền"},
           new New() {Id=1, StockId="POT", Title="Ngày đăng ký cuối cùng Đại hội đồng cổ dông thường niên năm 2022"},
           new New() {Id=1, StockId="C47", Title="Thông báo về ngày đăng ký cuối cùng lấy ý kiến cổ dông bằng văn bản"},
           new New() {Id=1, StockId="MIE", Title="Ngày đăng ký cuối cùng trả cổ tức bằng tiền mặt"},
           new New() {Id=2, StockId="MST", Title="Cấp Giáy chứng nhận đăng ký chứng khoán thay đổi lần thứ 5"},
           new New() {Id=2, StockId="SBM", Title="Cấp Giấy chứng nhận đăng ký chứng khoán thay đổi lần thứ 1"},
           new New() {Id=2, StockId="TN1", Title="Cấp Giấy chứng nhận đăng ký chứng khoán thay đổi lần thứ 5"},
           new New() {Id=2, StockId="VUA", Title="Cấp Giấy chứng nhận đăng ký chứng khoán lần đầu"},
           new New() {Id =3,Title ="Báo cáo triển vọng 2021 - Quyển 04 - tác động trái chiều từ diễn biễn giá đầu FPTS - Tháng 01/2021", DatetimeN="05/01/2021 10:06"},
           new New() {Id =3,Title ="Báo cáo triển vọng 2021 - Quyển 03 - tác động trái chiều từ diễn biễn giá đầu FPTS - Tháng 01/2021", DatetimeN="04/01/2021 17:14"},
           new New() {Id =3,Title ="Báo cáo triển vọng 2021 - Quyển 02 - tác động trái chiều từ diễn biễn giá đầu FPTS - Tháng 01/2021", DatetimeN="03/01/2021 08:34"},
           new New() {Id =3,Title ="Báo cáo triển vọng 2021 - Quyển 01 - tác động trái chiều từ diễn biễn giá đầu FPTS - Tháng 01/2021", DatetimeN="02/01/2021 17:51"},
           new New() {Id=4, StockId="CHPG2202", Title="Quyết định chấp thuận niêm yết Chứng quyền CHPG2202"},
           new New() {Id=4, StockId="CMWG2114", Title="Quyết định chấp thuận niêm yết Chứng quyền CMWG2114"},
           new New() {Id=4, StockId="CTPB2101", Title="Quyết định chấp thuận niêm yết Chứng quyền CTPB2101"},
           new New() {Id=4, StockId="CVIC2110", Title="Quyết định chấp thuận niêm yết Chứng quyền CVIC2110"},
           new New() {Id=5, StockId="CAM", Title="Ngày 28/01/2022, ngày hủy ĐKGD cổ phiếu của Công ty cổ phần Môi trường đô thị Cà Mau"},
           new New() {Id=5, StockId="MCT", Title="Ngày 28/01/2022, ngày hủy ĐKGD cổ phiếu của CTCP Kinh doanh Vật tư và Xây dựng"},
           new New() {Id=5, StockId="CTCB2106", Title="Quyết định hủy niêm yết chứng quyền đảm bảo Chứng quyền CTCB2106"},
           new New() {Id=5, StockId="CSTB2107", Title="Quyết định hủy niêm yết chứng quyền đảm bảo Chứng quyền CSTB2107"},
           new New() {Id=6, StockId="PTG", Title="Đăng ký bán 230.296 cổ phiếu quỹ"},
           new New() {Id=6, StockId="MWG", Title="Báo cáo kết quả giao dịch mua lại cổ phiếu quỹ"},
           new New() {Id=6, StockId="MPC", Title="Đăng ký bán 633.170 cổ phiếu quỹ"},
           new New() {Id=6, StockId="VND", Title="Thông báo về việc giao dịch bán cổ phiếu quỹ"}
        };
        public static ObservableCollection<New> FPTSIdentifys = new ObservableCollection<New>()
        {
            new New() {Id =1, Title ="Bản tin khuyến nghị đầu tư 06/01/2021", DatetimeN="06/01/2022 10:51"},
            new New() {Id =1, Title ="Bản tin khuyến nghị đầu tư 05/01/2021", DatetimeN="05/01/2022 16:05"},
            new New() {Id =1, Title ="Bản tin khuyến nghị đầu tư 04/01/2021", DatetimeN="04/01/2022 15:!4"},
            new New() {Id =1, Title ="Bản tin khuyến nghị đầu tư 03/01/2021", DatetimeN="03/01/2022  15:14"},
            new New() {Id =2, Title ="Bản tin tài chính tháng 11 năm 2021", DatetimeN="07/11/2022 12:31"},
            new New() {Id =2, Title ="Bản tin tài chính tháng 10 năm 2021", DatetimeN="07/01/2022 08:41"},
            new New() {Id =2, Title ="Tỷ giá tham khảo tại Sở giao dịch Ngân hàng Nhà nước ngày 03/11/2021", DatetimeN="03/11/2021 14:39"},
            new New() {Id =2, Title ="Bản tin tài chính tháng 09 2021", DatetimeN="31/09/2021 09:33"},
            new New() {Id =3,Title ="Báo cáo triển vọng 2021 - Quyển 04 - tác động trái chiều từ diễn biễn giá đầu FPTS - Tháng 01/2021", DatetimeN="05/01/2021 10:06"},
            new New() {Id =3,Title ="Báo cáo triển vọng 2021 - Quyển 03 - tác động trái chiều từ diễn biễn giá đầu FPTS - Tháng 01/2021", DatetimeN="04/01/2021 17:14"},
            new New() {Id =3,Title ="Báo cáo triển vọng 2021 - Quyển 02 - tác động trái chiều từ diễn biễn giá đầu FPTS - Tháng 01/2021", DatetimeN="03/01/2021 08:34"},
            new New() {Id =3,Title ="Báo cáo triển vọng 2021 - Quyển 01 - tác động trái chiều từ diễn biễn giá đầu FPTS - Tháng 01/2021", DatetimeN="02/01/2021 17:51"},
            new New() {Id =4, StockId="BSP", Title ="THEO DÕI - Báo cáo cập nhật định giá  - FPTS - 20/12/2021", DatetimeN="20/12/2021 14:57"},
            new New() {Id =4, StockId="DC4", Title ="MUA - Báo cáo cập nhật định giá  - FPTS - 06/12/2021", DatetimeN="06/12/2021 10:55"},
            new New() {Id =4, StockId="HRC", Title ="THEO DÕI - Báo cáo cập nhật định giá  - FPTS - 26/11/2021", DatetimeN="26/11/2021 10:54"},
            new New() {Id =4, StockId="LDP", Title ="BÁN - Báo cáo cập nhật định giá  - FPTS - 10/11/2021", DatetimeN="10/11/2021 20:05"},
            new New() {Id =5,Title ="Khuyến nghị mua cổ phiếu BSI ngày 30/12/2021", DatetimeN="30/12/2021 09:11"},
            new New() {Id =5,Title ="Khuyến nghị mua cổ phiếu HCM ngày 30/12/2021", DatetimeN="30/12/2021 08:42"},
            new New() {Id =5,Title ="Khuyến nghị mua cổ phiếu TTA ngày 28/12/2021", DatetimeN="28/12/2021 09:38"},
            new New() {Id =5,Title ="Khuyến nghị mua cổ phiếu SZC ngày 28/12/2021", DatetimeN="28/12/2021 09:38"},
            new New() {Id =6,Title ="Báo cáo cập nhật kết quả kinh doanh quý 3/2021", DatetimeN="04/01/2022 11:25", Source="Theo gso.gov.vn"},
            new New() {Id =6,Title ="Báo cáo chiến lược đầu tư ROIC - FPTS", DatetimeN="04/01/2022 11:23", Source="Theo gso.gov.vn"},
            new New() {Id =6,Title ="Báo cáo cập nhật chiến lược đầu tư Net-Net- Tháng 04/2021", DatetimeN="29/04/2021 10:03", Source="Theo gso.gov.vn"},
            new New() {Id =6,Title ="Báo cáo tình hình kinh tế - xã hội quý IV và năm 2021", DatetimeN="29/12/2021 10:03", Source="Theo Tổng cục Thống kê"},
        };
        public static ObservableCollection<New> News = new ObservableCollection<New>()
        {
            new New(){Id =1, Title = "FPTS củng cố vị trí trong Top 10 công ty có thị phần môi giới lớn nhất năm 2021", DatetimeN="06/01/2022 10:51"},
            new New() {Id =1, Title ="Thông báp Giàm phí giao dịch chứng khoán phái sinh bà Bổ sung biểu phí giao dịch Cổ phiếu/ Chứng chỉ quỹ/ ETF...", DatetimeN="30/12/2021 16:05"},
            new New() {Id =1, Title ="Chương trình ưu đã phí giao dịch chứng khoán cho Khách hàng mở tài khoản mới", DatetimeN="20/12/2021 15:!4"},
            new New() {Id =1, Title ="CTCP Chứng khoán FPT thông báo về việc nghỉ giao dịch nhân dịp tết Dương lịch 2022", DatetimeN="27/12/2021  15:14"},
            new New() {Id =2, Title ="Thông báo danh sách các công ty chứng khoán thành viên làm đại lý cho Sở GDCK TP.HCM trong năm 2022", DatetimeN="07/01/2022 12:31"},
            new New() {Id =2, Title ="Số liệu quản lý sở hữu của nhà đầu tư nước ngoài tại ngày 07/01/2022", DatetimeN="07/01/2022 08:41"},
            new New() {Id =2, Title ="Thông báo về việc hạn chế giao dịch trên hệ thống giao dịch UPCoM đối với cổ phiếu công ty cổ phần VT Vạn Xuân", DatetimeN="06/01/2022 14:39"},
            new New() {Id =2, Title ="Số liệu quản lý sở hữu của nhà đầu tư nước ngoài tại ngày 06/01/2022", DatetimeN="06/01/2022 09:33"},
            new New() {Id =3, StockId="BSP", Title ="Báo cáo tình hình quản trị công ty năm 2021", DatetimeN="08/01/2022 14:57"},
            new New() {Id =3, StockId="DC4", Title ="Báo cáo thay đổi tỷ lệ sở hữu cổ phiếu của cổ đông lớn DIG", DatetimeN="08/01/2022 10:55"},
            new New() {Id =3, StockId="HRC", Title ="Tình hình sản xuất kinh doanh tháng 12 năm 2021", DatetimeN="08/01/2021 10:54"},
            new New() {Id =3, StockId="LDP", Title ="Tài liệu họp Đại hội đồng cổ đông lần 1", DatetimeN="07/01/2022 20:05"},
            new New() {Id =4,Title ="Công ty Cổ phần Chứng khoán FPT thông báo bán đâu giá cổ phần của Công ty Cổ phần Đầu tư phát triểm hạ tầng Phú Quốc", DatetimeN="05/01/2022 10:06"},
            new New() {Id =4,Title ="Thông báo về việc đăng ký làm đại ý đấu giá Công ty Cổ phần Đầu tư phát triển hạ tầng Phú Quốc", DatetimeN="31/12/2021 17:14"},
            new New() {Id =4,Title ="Thông báo kết quả đấu giá bán cổ phần của Tổng công ty Tư vấn Xây dựng Thủy Lợi Việt Nam - CTCP do Tổng công ty Đầu tư và Kinh doanh", DatetimeN="30/12/2021 08:34"},
            new New() {Id =4,Title ="Thông báo kết quả đấu giá cổ phần của Công ty Cổ phần Xuất nhập khẩu An Giang", DatetimeN="28/12/2021 17:51"},
            new New() {Id =5,Title ="Tỷ giá tham khảo tại Sở giao dịch Ngân Nhà nước ngày 7/01/2022", DatetimeN="07/01/2021 09:11"},
            new New() {Id =5,Title ="Tỷ giá trung tâm ngày 07/01/2022", DatetimeN="02/01/2022 08:42"},
            new New() {Id =5,Title ="Lãi suất thị trường liên ngân hàng 06/01/2022", DatetimeN="06/01/2022 09:38"},
            new New() {Id =5,Title ="Tỷ giá trung tâm 06/01/2022", DatetimeN="06/01/2022 09:38"},
            new New() {Id =6,Title ="Tình hình xây dựng quý IV và năm 2021", DatetimeN="04/01/2022 11:25", Source="Theo gso.gov.vn"},
            new New() {Id =6,Title ="Các động lực tăng trướng kinh tế Việt Nam năm 2021", DatetimeN="04/01/2022 11:23", Source="Theo gso.gov.vn"},
            new New() {Id =6,Title ="Chỉ số sản xuất công nghiệ[ tháng 12 năm 2021", DatetimeN="29/12/2021 10:03", Source="Theo gso.gov.vn"},
            new New() {Id =6,Title ="Báo cáo tình hình kinh tế - xã hội quý IV và năm 2021", DatetimeN="29/12/2021 10:03", Source="Theo Tổng cục Thống kê"},
        };
        public static ObservableCollection<StockBalance> SuplusStocks = new ObservableCollection<StockBalance>()
        {
            new StockBalance()  {StockId = "VCB", Mass = 1000, PersentBorrow = 0.25, DateEnd= DateTime.ParseExact("12/12/2022","dd/MM/yyyy", null), Status = true},
            new StockBalance()  {StockId = "PVC", Mass = 500, PersentBorrow = 0.25, DateEnd= DateTime.ParseExact("15/09/2022","dd/MM/yyyy", null), Status = false},
            new StockBalance()  {StockId = "SHB", Mass = 500, PersentBorrow = 0.15, DateEnd= DateTime.ParseExact("22/10/2022","dd/MM/yyyy", null), Status = true},
            new StockBalance()  {StockId = "AAA", Mass = 339, PersentBorrow = 0.15, DateEnd= DateTime.ParseExact("12/02/2022","dd/MM/yyyy", null), Status = false}
        };
        public static ObservableCollection<FormTransfer> FormSends = new ObservableCollection<FormTransfer>()
        {
            new FormTransfer() {ID = 1, Title="NỘP TIỀN ĐẤU GIÁ",Number="1221 0000 3191 39",Name="CTY CP CHUNG KHOAN FPT", Address="Đầu tư và Phát triền - BIDV CN Hà Thành Hà Nội"},
            new FormTransfer() {ID = 2, Title="NỘP PHÍ THUẾ DỊCH VỤ FPTS",Number="1480 0153 6549",Name="CONG TY CO PHAN CHUNG KHOAN FPT", Address="Công Thương - VietinBank CN Nam Thăng Long"},
            new FormTransfer() {ID = 3, Title="NỘP TIỀN THỰC HIỆN QUYỀN MUA PHÁT HÀNH THÊM",Number="1221 0000 3221 46",Name="CTY CP CHUNG KHOAN FPT", Address="Đầu tư và Phát triền - BIDV CN Hà Thành Hà Nội"}
        };
        public static ObservableCollection<Notification> Notifications = new ObservableCollection<Notification>()
        {
           new Notification() {Type=1, Name="Bản tin chứng khoán", Title="FPTS xin gửi tới quý khách hàng Bản tin chứng khoán ngày 12/11/2022", TimeCreated=DateTime.Now},
           new Notification() {Type=1, Name="Bản tin chứng khoán", Title="FPTS xin gửi tới quý khách hàng Bản tin chứng khoán ngày 11/11/2022", TimeCreated=DateTime.ParseExact("11/01/2022","dd/MM/yyyy", null), IsActive=true},
           new Notification() {Type=2, Name="Báo cáo phân tích ký thuật mã BSI", Title="FPTS xin gửi tới quý khách hàng Báo cáo phân tích ký thuật mã BSI", TimeCreated=DateTime.ParseExact("04/01/2022","dd/MM/yyyy", null)},
           new Notification() {Type=1, Name="Dừng dịch vụ rút/chuyển tiền từ 15h ngày 31/12/2021 đến 04/01/2021", Title="FPTS trân trọng thông báo: Để phục vụ cho việc hạch toán cuối năm , FPTS dừng dịch vụ rút/ chuyển tiền từ 15h ngày 31/12/2021. Từ ngày 04/01/2021, dịch vụ này sẽ hoạt động trở lại bình thường. Trân trọng cảm ơn quý khách!", TimeCreated=DateTime.ParseExact("24/12/2021","dd/MM/yyyy", null)},
           new Notification() {Type=3, Name="Nâng cấp hệ thống từ 0h đến 13h ngày 27/11/2021", Title="FPTS sẽ thực hiện nâng cấp hệ thống dự kiến từ 0h đến 13h ngày 27/11/2021. Trong thời gian này, Quý khách sẽ không truy cập được vào Website: fpts.com.vn và không đăng nhập được TKGDCK trên trình duyệt web và các thiết bị di dộng. Kính mong Quý khách thông cảm về sự bất tiện này . Trân trọng cảm ơn Quý khách!", TimeCreated=DateTime.ParseExact("24/10/2021","dd/MM/yyyy", null), IsActive = true},



        };
        public App()
        {
            InitializeComponent();
            DevExpress.XamarinForms.DataGrid.Initializer.Init();
            DevExpress.XamarinForms.Navigation.Initializer.Init();
            DevExpress.XamarinForms.Editors.Initializer.Init();

           
            if (!Preferences.ContainsKey("CurrentFollowList", "Newbie"))
            {
                Preferences.Set("CurrentFollowList", "Newbie");
            };
           
            if (!Preferences.ContainsKey("FullOrSort"))
            {
                Preferences.Set("FullOrSort", false);
            }

            Preferences.Set("FormSend", 100);

            Preferences.Set("tmpM", "");
            MainPage = new NavigationPage( new MainPage(""));

            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"Token: {e.Token}");
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
