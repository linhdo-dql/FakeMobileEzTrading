using FakeEzMobileTrading.Models;
using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace FakeEzMobileTrading.ViewModels
{
    public class NotifyPageViewModel : BaseViewModel
    {
        public ObservableCollection<Notification> Notifications { get; set; }
        public NotifyPageViewModel(Page page)
        {
            Notifications = App.Notifications;
            MoreTap = new Command((x) =>
            {
                var item = x as Notification;
                item.More = !item.More;
            });
            BackPage = new Command(() =>
            {
                page.Navigation.PopModalAsync();
            });
        }
        public Command MoreTap { get; }
        public Command BackPage { get; }
    }
}
