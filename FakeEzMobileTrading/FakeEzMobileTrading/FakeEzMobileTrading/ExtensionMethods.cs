using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FakeEzMobileTrading
{
    public static class ExtensionMethods
    {
        public static int DecimalDigits(this decimal n)
        {
            return n.ToString(System.Globalization.CultureInfo.InvariantCulture)
                    .SkipWhile(c => c != ',')
                    .Skip(1)
                    .Count();
        }

        public static bool IsDeletion(this TextChangedEventArgs e)
        {
            return !string.IsNullOrEmpty(e.OldTextValue) && e.OldTextValue.Length > e.NewTextValue.Length;
        }
    }
}
