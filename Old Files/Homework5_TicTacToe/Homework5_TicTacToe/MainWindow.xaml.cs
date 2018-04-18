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

namespace Homework5_TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel = new ViewModel();
        GameTracker xScore = new GameTracker();
        GameTracker oScore = new GameTracker();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
            uxTurn.Text = viewModel.StatusBarText;
        }

        /// <summary>
        /// This method clears and enables all the buttons on the main window
        /// Then, it passes the scorecards to be cleared, and resets the view model
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {

            foreach (Button button in uxGrid.Children)
            {
                button.Content = "";
                button.IsEnabled = true;
            }
            xScore.ClearScoreCard();
            oScore.ClearScoreCard();
            viewModel.TurnCount = 0;
            viewModel.Player = 0;
        }

        /// <summary>
        /// This method updates the button that was clicked to fire the event
        /// Then it passes the tag to the ResolveTurn method for game udpates
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (sender as Button);
            button.Content = viewModel.Player.ToString();
            button.IsEnabled = false;
            ResolveTurn(button.Tag.ToString());
        }

        /// <summary>
        /// This method shuts down the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// This method uses the tag from the Button_Click event to run through
        /// some GameTracker methods, updating scorecards, and checking for winners
        /// Then, it updates the view model and status bar text
        /// </summary>
        /// <param name="tag"></param>
        private void ResolveTurn(string tag)
        {
            bool isGameOver = false;
            if (viewModel.Player.ToString() == "X")
            {
                xScore.UpdateRecord(tag);
                if (xScore.CheckForWinner())
                {
                    GameOver("X");
                    isGameOver = true;
                }
            }
            else if (viewModel.Player.ToString() == "O")
            {
                oScore.UpdateRecord(tag);
                if (oScore.CheckForWinner())
                {
                    GameOver("O");
                    isGameOver = true;
                }
            }
            if (!isGameOver)
            {
                viewModel.AddCount();
                uxTurn.Text = viewModel.StatusBarText;
            }
        }

        /// <summary>
        /// This method kills the board, disabling all buttons,
        /// and then it changes the status bar to show the winner
        /// </summary>
        /// <param name="winner"></param>
        private void GameOver(string winner)
        {
            foreach (Button button in uxGrid.Children)
            {
                button.IsEnabled = false;
            }
            uxTurn.Text = ($"{winner} is the winner!");
        }

    }
}
