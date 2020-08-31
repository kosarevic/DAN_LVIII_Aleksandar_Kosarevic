using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public const string O_SYMBOL = "O";
        public const string X_SYMBOL = "X";

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
