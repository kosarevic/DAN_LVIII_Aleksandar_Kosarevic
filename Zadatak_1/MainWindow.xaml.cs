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

        private void OnRestartButton_Click(object sender, RoutedEventArgs e)
        {
            mvm.ResetTheGame();
        }

        private void GameAction_Click(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;

            pressedButton.Content = mvm.X_SYMBOL;
            pressedButton.IsEnabled = false;

            if (CheckGameStatus())
                return;

            mvm.PerformAiMove();

            if (CheckGameStatus())
                return;
        }

        private bool CheckGameStatus()
        {
            if (CheckHorizontal())
            {
                mvm.DisableGame();
                MessageBox.Show("Player " + mvm.Winner + " has won the game!");
                return true;
            }

            if (CheckVertical())
            {
                mvm.DisableGame();
                MessageBox.Show("Player " + mvm.Winner + " has won the game!");
                return true;
            }

            if (CheckDiagonal())
            {
                mvm.DisableGame();
                MessageBox.Show("Player " + mvm.Winner + " has won the game!");
                return true;
            }

            if (mvm.CheckForTie())
            {
                mvm.ResetTheGame();
                MessageBox.Show("The game ended in a tie!");
                return true;
            }

            return false;
        }

        private bool CheckHorizontal()
        {
            bool gameOver = false;
            // Horizontal check
            if (A1.Content.Equals(A2.Content)
                && A1.Content.Equals(A3.Content)
                && A2.Content.Equals(A3.Content)
                && !A1.Content.Equals(""))
            {
                // Top row won
                //MessageBox.Show("top row");
                gameOver = true;
                mvm.Winner = Convert.ToString(A1.Content);
            }
            else if (B1.Content.Equals(B2.Content)
                    && B1.Content.Equals(B3.Content)
                    && B2.Content.Equals(B3.Content)
                    && !B1.Content.Equals(""))
            {
                // Middle row won
                //MessageBox.Show("middle row");
                gameOver = true;
                mvm.Winner = Convert.ToString(B1.Content);
            }
            else if (C1.Content.Equals(C2.Content)
                    && C1.Content.Equals(C3.Content)
                    && C2.Content.Equals(C3.Content)
                    && !C1.Content.Equals(""))
            {
                // Bottom row won
                //MessageBox.Show("bottom row");
                gameOver = true;
                mvm.Winner = Convert.ToString(C1.Content);
            }

            return gameOver;
        }

        private bool CheckVertical()
        {
            bool gameOver = false;
            // Vertical check
            if (A1.Content.Equals(B1.Content)
                && A1.Content.Equals(C1.Content)
                && B1.Content.Equals(C1.Content)
                && !A1.Content.Equals(""))
            {
                // Left column won
                //MessageBox.Show("left column");
                gameOver = true;
                mvm.Winner = Convert.ToString(A1.Content);
            }
            else if (A2.Content.Equals(B2.Content)
                    && A2.Content.Equals(C2.Content)
                    && B2.Content.Equals(C2.Content)
                    && !A2.Content.Equals(""))
            {
                // Middle column won
                //MessageBox.Show("middle column");
                gameOver = true;
                mvm.Winner = Convert.ToString(A2.Content);
            }
            else if (A3.Content.Equals(B3.Content)
                    && A3.Content.Equals(C3.Content)
                    && B3.Content.Equals(C3.Content)
                    && !A3.Content.Equals(""))
            {
                // Right column won
                //MessageBox.Show("right column");
                gameOver = true;
                mvm.Winner = Convert.ToString(A3.Content);
            }

            return gameOver;
        }

        private bool CheckDiagonal()
        {
            bool gameOver = false;
            // Diagonal check
            if (A1.Content.Equals(B2.Content)
                && A1.Content.Equals(C3.Content)
                && B2.Content.Equals(C3.Content)
                && !A1.Content.Equals(""))
            {
                // Top left to bottom right won
                //MessageBox.Show("tl-br");
                gameOver = true;
                mvm.Winner = Convert.ToString(A1.Content);
            }
            else if (C1.Content.Equals(B2.Content)
                    && C1.Content.Equals(A3.Content)
                    && B2.Content.Equals(A3.Content)
                    && !C1.Content.Equals(""))
            {
                // Bottom left to top right won
                //MessageBox.Show("bl-tr");
                gameOver = true;
                mvm.Winner = Convert.ToString(C1.Content);
            }

            return gameOver;
        }
    }
}
