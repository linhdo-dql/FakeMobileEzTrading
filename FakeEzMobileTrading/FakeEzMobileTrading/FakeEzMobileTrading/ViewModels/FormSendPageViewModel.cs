using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FakeEzMobileTrading.Models
{
    public class FormSendPageViewModel : BaseViewModel
    {
        private ObservableCollection<FormSend> _allForms;
        public ObservableCollection<FormSend> AllForms { get { return _allForms; } set { SetProperty(ref _allForms, value); } }

        private string _strSearch;
        public string StrSearch { 
            get { return _strSearch; } 
            set 
            {
               AllForms = new ObservableCollection<FormSend>(App.FormSends.Where(f => ( (f.Title.ToLower().Trim().Contains(value.ToLower().Trim())) || (f.Number.Replace(" ","").Contains(value)) || (f.Name.ToLower().Trim().Contains(value.ToLower().Trim())))).ToList());
               SetProperty(ref _strSearch, value);
            } 
        }
        public FormSendPageViewModel(Page page)
        {
            AllForms = new ObservableCollection<FormSend>(App.FormSends);
            FormSelected = new Command((x) =>
            {
                var item = x as FormSend;
                Preferences.Set("FormSend", item.ID);
                page.Navigation.PopAsync();
            });
            HidePopup = new Command(() =>
            {
                page.Navigation.PopAsync();
            });
            
        }
        public Command FormSelected { get; }
        public Command HidePopup { get; }
    }
}
