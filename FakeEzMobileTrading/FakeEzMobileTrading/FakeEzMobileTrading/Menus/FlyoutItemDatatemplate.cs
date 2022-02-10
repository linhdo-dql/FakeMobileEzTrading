using FakeEzMobileTrading.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FakeEzMobileTrading.Menus
{
    public class FlyoutItemDatatemplate : DataTemplateSelector
    {
        public DataTemplate ItemNonIcon { get; set; }
        public DataTemplate ItemWithRightIcon { get; set; }
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            return (item as ItemMenu).TypeTemplate == 0 ? ItemNonIcon : ItemWithRightIcon;
        }
    }
}
