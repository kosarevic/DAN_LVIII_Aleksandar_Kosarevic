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
        private List<Button> gameButtons;

        public static bool TURN = true;

        public MainWindow()
        {
            InitializeComponent();

            gameButtons = new List<Button>();

            gameButtons.Add(A1);
            gameButtons.Add(A2);
            gameButtons.Add(A3);

            gameButtons.Add(B1);
            gameButtons.Add(B2);
            gameButtons.Add(B3);

            gameButtons.Add(C1);
            gameButtons.Add(C2);
            gameButtons.Add(C3);
        }

        private void onRestartButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void aboutButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gameAction_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
