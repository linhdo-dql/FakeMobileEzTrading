﻿using FakeEzMobileTrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FakeEzMobileTrading.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExchangeDetailPage : ContentPage
    {   
        public string TitlePage1 { get; set; }
        public ExchangeDetailPage(string exchangeId)
        {
            InitializeComponent();
            Preferences.Set("TypeTable", 0);
            BindingContext = App.Exchanges.FirstOrDefault(item => item.ExchangeId == exchangeId);
        }
    }
}