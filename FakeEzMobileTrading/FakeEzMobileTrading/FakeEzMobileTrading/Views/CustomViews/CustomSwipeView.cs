using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FakeEzMobileTrading.Views.CustomViews
{
    public class CustomSwipeView : SwipeView
    {
        public CustomSwipeView()
        {
            SwipeEnded += CustomSwipeView_SwipeEnded;
        }

        public static readonly BindableProperty IsOpenProperty = BindableProperty.Create(
            nameof(IsOpen),
            typeof(bool),
            typeof(CustomSwipeView),
            false,
            BindingMode.TwoWay,
            propertyChanged: IsOpenPropertyChanged);

        public bool IsOpen
        {
            get => (bool)GetValue(IsOpenProperty);
            set => SetValue(IsOpenProperty, value);
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command), typeof(ICommand), typeof(CustomSwipeView), null);
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter), typeof(object), typeof(CustomSwipeView), null);
        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public void Dispose()
        {
            SwipeEnded -= CustomSwipeView_SwipeEnded;
        }

        private static void IsOpenPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is CustomSwipeView control) || !(oldValue is bool wasOpen) || !(newValue is bool isOpen))
                return;

            if (!wasOpen)
                return;

            if (!isOpen)
                control.Close();
        }

        private void CustomSwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            if (e.IsOpen && Command.CanExecute(CommandParameter))
            {
                IsOpen = true;
                Command.Execute(CommandParameter);
            }
        }
    }
}
