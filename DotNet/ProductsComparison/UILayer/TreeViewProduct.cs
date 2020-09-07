using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UILayer.Annotations;

namespace UILayer
{
    public class TreeViewProduct : INotifyPropertyChanged
    {
        private bool _isChecked;
        private string _ammount = "0";
        public bool IsEnabled { get; set; }
        public Visibility Visibility { get; set; }
        public string Text { get; set; }

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged(nameof(IsChecked));
            }
        }

        public string Ammount
        {
            get { return _ammount; }
            set
            {
                _ammount = value; 
                OnPropertyChanged(nameof(Ammount));
            }
        }

        public ObservableCollection<TreeViewProduct> SubProducts { get; set; }

        public TreeViewProduct()
        {
            SubProducts = new ObservableCollection<TreeViewProduct>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
