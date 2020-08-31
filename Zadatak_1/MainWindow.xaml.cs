using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zadatak_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mvm = new MainWindowViewModel();

        public MainWindow()
        {
            InitializeComponent();
            //All buttons that represent fields are added to observable collection for purpose of certain functionalities in ViewModel class.
            mvm.GameButtons.Add(A1);
            mvm.GameButtons.Add(A2);
            mvm.GameButtons.Add(A3);
            mvm.GameButtons.Add(B1);
            mvm.GameButtons.Add(B2);
            mvm.GameButtons.Add(B3);
            mvm.GameButtons.Add(C1);
            mvm.GameButtons.Add(C2);
            mvm.GameButtons.Add(C3);

            DataContext = mvm;
        }
        /// <summary>
        /// Method for reset button functionaliy.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRestartButton_Click(object sender, RoutedEventArgs e)
        {
            mvm.ResetTheGame();
        }

        /// <summary>
        /// Method called when any field is pressed ether by Player or AI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameAction_Click(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;
            //Player button is automaticly assinged "X" symbol.
            pressedButton.Content = mvm.X_SYMBOL;
            pressedButton.IsEnabled = false;
            //Game status is checked after player has selected its move.
            if (CheckGameStatus())
                return;
            //If no wictory condition is met, AI gets a turn.
            mvm.PerformAiMove();
            //After AI has played, game checks for win conditions again.
            if (CheckGameStatus())
                return;
        }
        /// <summary>
        /// Method checks for win condition and displays which player has won the game (User or AI).
        /// </summary>
        /// <returns></returns>
        private bool CheckGameStatus()
        {
            //Horisontal win conditons are checked.
            if (CheckHorizontal())
            {
                mvm.DisableGame();
                MessageBox.Show("Player " + mvm.Winner + " has won the game!");
                return true;
            }
            //Vertical win conditions are checked.
            if (CheckVertical())
            {
                mvm.DisableGame();
                MessageBox.Show("Player " + mvm.Winner + " has won the game!");
                return true;
            }
            //Diagonal win conditions are checked.
            if (CheckDiagonal())
            {
                mvm.DisableGame();
                MessageBox.Show("Player " + mvm.Winner + " has won the game!");
                return true;
            }
            //If no previous conditions are met, code checks for Tie conditions.
            if (mvm.CheckForTie())
            {
                mvm.ResetTheGame();
                MessageBox.Show("The game ended in a tie!");
                return true;
            }

            return false;
        }
        /// <summary>
        /// Method for horizontal win conditions checking logic.
        /// </summary>
        /// <returns></returns>
        private bool CheckHorizontal()
        {
            bool gameOver = false;
            //Horizontal check of A fields values.
            if (A1.Content.Equals(A2.Content)
                && A1.Content.Equals(A3.Content)
                && A2.Content.Equals(A3.Content)
                && !A1.Content.Equals(""))
            {
                //If conditions are met, method returns True and player assinged value (X or O).
                gameOver = true;
                mvm.Winner = Convert.ToString(A1.Content);
            }
            //Horizontal check of B fields values.
            else if (B1.Content.Equals(B2.Content)
                    && B1.Content.Equals(B3.Content)
                    && B2.Content.Equals(B3.Content)
                    && !B1.Content.Equals(""))
            {
                gameOver = true;
                mvm.Winner = Convert.ToString(B1.Content);
            }
            //Horizontal check of C fields values.
            else if (C1.Content.Equals(C2.Content)
                    && C1.Content.Equals(C3.Content)
                    && C2.Content.Equals(C3.Content)
                    && !C1.Content.Equals(""))
            {
                gameOver = true;
                mvm.Winner = Convert.ToString(C1.Content);
            }

            return gameOver;
        }

        /// <summary>
        /// Method for Vertical win conditions checking logic.
        /// </summary>
        /// <returns></returns>
        private bool CheckVertical()
        {
            bool gameOver = false;
            //Vertical check of fields values.
            if (A1.Content.Equals(B1.Content)
                && A1.Content.Equals(C1.Content)
                && B1.Content.Equals(C1.Content)
                && !A1.Content.Equals(""))
            {
                //If conditions are met, method returns True and player assinged value (X or O).
                gameOver = true;
                mvm.Winner = Convert.ToString(A1.Content);
            }
            else if (A2.Content.Equals(B2.Content)
                    && A2.Content.Equals(C2.Content)
                    && B2.Content.Equals(C2.Content)
                    && !A2.Content.Equals(""))
            {
                gameOver = true;
                mvm.Winner = Convert.ToString(A2.Content);
            }
            else if (A3.Content.Equals(B3.Content)
                    && A3.Content.Equals(C3.Content)
                    && B3.Content.Equals(C3.Content)
                    && !A3.Content.Equals(""))
            {
                gameOver = true;
                mvm.Winner = Convert.ToString(A3.Content);
            }

            return gameOver;
        }

        /// <summary>
        /// Method for diagonal win conditions checking logic.
        /// </summary>
        /// <returns></returns>
        private bool CheckDiagonal()
        {
            bool gameOver = false;
            //Diagonal check of fields values.
            if (A1.Content.Equals(B2.Content)
                && A1.Content.Equals(C3.Content)
                && B2.Content.Equals(C3.Content)
                && !A1.Content.Equals(""))
            {
                //If conditions are met, method returns True and player assinged value (X or O).
                gameOver = true;
                mvm.Winner = Convert.ToString(A1.Content);
            }
            else if (C1.Content.Equals(B2.Content)
                    && C1.Content.Equals(A3.Content)
                    && B2.Content.Equals(A3.Content)
                    && !C1.Content.Equals(""))
            {
                gameOver = true;
                mvm.Winner = Convert.ToString(C1.Content);
            }

            return gameOver;
        }
    }
}
