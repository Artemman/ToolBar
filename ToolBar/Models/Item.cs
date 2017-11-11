using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using ToolBar.Helpers;

namespace ToolBar.Models
{
    public class Item : NotifyProperyChangedClass
    {

        private string _Path;
        private BitmapImage _Image;
        private string _Name;
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set
            {
                if (_Id != value)
                {
                    Id = value;
                    onPropertyChanged();
                }
            }
        }
        
        public string Name { 
            get
            {
                return _Name;
            }
            set 
            {
                if(_Name!= value)
                {
                    _Name = value;
                    onPropertyChanged();
                }
            }

        }
        public string Path
        {
            get
            {
                return _Path;
            }
            set
            {
                if (_Path != value)
                {
                    _Path = value;
                    onPropertyChanged();
                }
            }
        }
        public BitmapImage Image
        {
            get
            {
                return _Image;
            }
            set
            {
                if (_Image != value)
                {
                    _Image = value; ;
                    onPropertyChanged();
                }
            }
        }
    }
}
