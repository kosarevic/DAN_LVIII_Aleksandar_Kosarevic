using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Zadatak_1
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Button> GameButtons = new ObservableCollection<Button>();

        public string X_SYMBOL = "X";
        public string O_SYMBOL = "O";
        public string Winner;


        public void PerformAiMove()
        {
            List<Button> notClicked = new List<Button>();

            foreach (Button button in GameButtons)
            {
                if (button.IsEnabled == true)
                {
                    notClicked.Add(button);
                }
            }

            Random random = new Random();
            int index = random.Next(0, notClicked.Count);
            Button move = notClicked.ElementAt(index);

            move.Content = O_SYMBOL;
            move.IsEnabled = false;
        }

        public void DisableGame()
        {
            foreach (Button button in GameButtons)
            {
                button.IsEnabled = false;
            }
        }

        public void ResetTheGame()
        {
            foreach (Button button in GameButtons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
        }

        public bool CheckForTie()
        {
            foreach (Button button in GameButtons)
            {
                if (button.IsEnabled == true)
                {
                    return false;
                }
            }
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
