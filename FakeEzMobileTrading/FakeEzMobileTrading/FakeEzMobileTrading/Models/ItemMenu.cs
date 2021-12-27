using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeEzMobileTrading.Models
{
    public class ItemMenu : BaseViewModel
    {  
       public string Id { get; set; }
       public int TypeList { get; set; }
       public string Name { get; set; }
       public string Icon { get; set; }
        private bool _iconShowmoreEnable = true;
       public bool IconShowMoreEnable
        {
            get { return SubMenu == null ? false : true; }
            set { SetProperty(ref _iconShowmoreEnable, value); }
        }
        private string _iconShowmore = "ic_showmore1.png";
       public string IconShowMore
        {
            get
            {
                if(SubMenu == null)
                {
                    return "";
                }
                return _iconShowmore;
            }
            set
            {
                 SetProperty(ref _iconShowmore, value);
            }
        }
       public string[] SubMenu { get; set; }
       private bool _isVisible = false; 
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                IconShowMore = value ? "ic_showmore2.png" : "ic_showmore1.png";
                SetProperty  (ref _isVisible, value);
            }
        }
        private bool _isFavourite = false ;
        public bool IsFavourite
        {
            get { return _isFavourite; }
            set {
                IconFavourite = value ? "ic_fillstar.png" : "ic_emptystar.png";
                SetProperty(ref _isFavourite, value); 
            }
        }
        private string _iconFavourite = "ic_emptystar.png";
        public string IconFavourite
        {
            get { return _iconFavourite; }
            set { SetProperty(ref _iconFavourite,value); }
        }
        public bool _iconFavouriteVisible = false;
        public bool IconFavouriteVisible
        {
           get { return _iconFavouriteVisible; }
           set { SetProperty(ref _iconFavouriteVisible, value); }
        }
        
    }
}
