using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5_TicTacToe
{

    public class ViewModel : INotifyPropertyChanged
    {
        public enum PlayerName { X, O };

        /// <summary>
        /// Player uses the PlayerName enum as a basis for toggling
        /// between X and O depending on the value of TurnCount
        /// </summary>
        #region Player Field/Property

        private PlayerName player = new PlayerName();

        public PlayerName Player
        {
            get
            {
                return player;
            }
            set
            {
                player = value;
                OnPropertyChanged(nameof(Player));
            }
        }

        #endregion

        /// <summary>
        /// TurnCount is simply an int that starts at 0 and tracks the number
        /// of turns, which is used as the basis for Player toggling
        /// </summary>
        #region TurnCount Field/Property

        private int turnCount;

        public int TurnCount
        {
            get
            {
                return turnCount;
            }
            set
            {
                turnCount = value;
                OnPropertyChanged(nameof(TurnCount));
            }
        }

        #endregion

        /// <summary>
        /// StatusBarText is the text that will be contained in the Status Bar control
        /// </summary>
        #region StatusBarText

        private string statusBarText;

        public string StatusBarText
        {
            get
            {
                return statusBarText;
            }
            set
            {
                statusBarText = value;
                OnPropertyChanged(nameof(StatusBarText));
            }
        }

        #endregion

        /// <summary>
        /// The constructor assigns values of 0 to each of the Properties,
        /// which results in the first value of Player being X
        /// Additionally, the StatusBarText property contains info on the first turn
        /// </summary>
        #region Constructor

        public ViewModel()
        {
            Player = 0;
            TurnCount = 0;
            StatusBarText = "X's Turn";

        }

        #endregion

        /// <summary>
        /// This is the required event field and method
        /// for the INotifyPropertyChanged interface
        /// </summary>
        #region PropertyChangedEventHandler/OnPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        #endregion

        /// <summary>
        /// This is the method that iterates the value of TurnCount with each call
        /// Additionally, the result of the TurnCount toggles Player between X=0 and O=1
        /// </summary>
        /// <param name="viewModel"></param>
        public void AddCount()
        {
            TurnCount++;
            Player = (PlayerName)(TurnCount % 2);
            StatusBarText = (Player.ToString() + "'s Turn");
        }
    }
}
