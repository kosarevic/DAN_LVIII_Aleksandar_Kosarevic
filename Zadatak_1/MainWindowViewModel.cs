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
    /// <summary>
    /// Class responsible for various functionalities regarding main window.
    /// </summary>
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Button> GameButtons = new ObservableCollection<Button>();
        //Simbols for Tic Tac Toe game are predefined, meaning User gets an X and AI gets an O.
        public string X_SYMBOL = "X";
        public string O_SYMBOL = "O";
        public string Winner;

        /// <summary>
        /// Ai Logic for selecting fields in a game.
        /// </summary>
        public void PerformAiMove()
        {
            //Temporary collection for empty fields in a game.
            List<Button> notClicked = new List<Button>();

            foreach (Button button in GameButtons)
            {
                if (button.IsEnabled == true)
                {
                    //If field was not clicked previously, it is added to temporary list.
                    notClicked.Add(button);
                }
            }
            //Next AI action is determined randomly.
            Random random = new Random();
            int index = random.Next(0, notClicked.Count);
            Button move = notClicked.ElementAt(index);
            //O sign is assigned to AI for each turn he plays.
            move.Content = O_SYMBOL;
            //Button chosen by random number is disabled after AI select it. 
            move.IsEnabled = false;
        }

        /// <summary>
        /// Method responsible for disabling all fields after win conditions are met.
        /// </summary>
        public void DisableGame()
        {
            foreach (Button button in GameButtons)
            {
                button.IsEnabled = false;
            }
        }

        /// <summary>
        /// Method resposible for clicking Reset button. (resets the game)
        /// </summary>
        public void ResetTheGame()
        {
            foreach (Button button in GameButtons)
            {
                button.IsEnabled = true;
                button.Content = "";
            }
        }

        /// <summary>
        /// Method responsible if no win conditions are achived, so the game result is "Tie".
        /// </summary>
        /// <returns></returns>
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
