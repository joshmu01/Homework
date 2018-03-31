using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework5_TicTacToe
{
    public  class GameTracker
    {
        public Dictionary<string, int> ScoreCard { get; set; }

        /// <summary>
        /// Generic constructor populates the dictionary object with
        /// keys representing the rows, columns, and cross-lines of a
        /// tic-tac-toe gameboard, while the values are all set to zero
        /// </summary>
        public GameTracker()
        {
            ScoreCard = new Dictionary<string, int>
            {
                { "R1", 0 },
                { "R2", 0 },
                { "R3", 0 },
                { "C1", 0 },
                { "C2", 0 },
                { "C3", 0 },
                { "X1", 0 },
                { "X2", 0 },
            };

        }

        /// <summary>
        /// This method contains a switch statement which increases the values
        /// keyed to the row and column of the button tag parameter
        /// </summary>
        /// <param name="tag"></param>
        public void UpdateRecord(string tag)
        {
            switch (tag)
            {
                case "0,0":
                    ScoreCard["R1"] = ScoreCard["R1"] + 1;
                    ScoreCard["C1"] = ScoreCard["C1"] + 1;
                    ScoreCard["X1"] = ScoreCard["X1"] + 1;
                    break;
                case "0,1":
                    ScoreCard["R1"] = ScoreCard["R1"] + 1;
                    ScoreCard["C2"] = ScoreCard["C2"] + 1;
                    break;
                case "0,2":
                    ScoreCard["R1"] = ScoreCard["R1"] + 1;
                    ScoreCard["C3"] = ScoreCard["C3"] + 1;
                    ScoreCard["X2"] = ScoreCard["X2"] + 1;
                    break;
                case "1,0":
                    ScoreCard["R2"] = ScoreCard["R2"] + 1;
                    ScoreCard["C1"] = ScoreCard["C1"] + 1;
                    break;
                case "1,1":
                    ScoreCard["R2"] = ScoreCard["R2"] + 1;
                    ScoreCard["C2"] = ScoreCard["C2"] + 1;
                    ScoreCard["X1"] = ScoreCard["X1"] + 1;
                    ScoreCard["X2"] = ScoreCard["X2"] + 1;
                    break;
                case "1,2":
                    ScoreCard["R2"] = ScoreCard["R2"] + 1;
                    ScoreCard["C3"] = ScoreCard["C3"] + 1;
                    break;
                case "2,0":
                    ScoreCard["R3"] = ScoreCard["R3"] + 1;
                    ScoreCard["C1"] = ScoreCard["C1"] + 1;
                    ScoreCard["X2"] = ScoreCard["X2"] + 1;
                    break;
                case "2,1":
                    ScoreCard["R3"] = ScoreCard["R3"] + 1;
                    ScoreCard["C2"] = ScoreCard["C2"] + 1;
                    break;
                case "2,2":
                    ScoreCard["R3"] = ScoreCard["R3"] + 1;
                    ScoreCard["C3"] = ScoreCard["C3"] + 1;
                    ScoreCard["X1"] = ScoreCard["X1"] + 1;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// This method runs a ContainsValue method on the dictionary,
        /// specifically searching for a value of 3, representing a win
        /// </summary>
        /// <returns></returns>
        public bool CheckForWinner()
        {
            return ScoreCard.ContainsValue(3);
        }

        /// <summary>
        /// This method converts the keys of the dictionary object to a list,
        /// and then it uses that list of keys to iterate through the dictionary 
        /// object and set all values to zero, effectively clearing the Scorecard
        /// </summary>
        public void ClearScoreCard()
        {
            List<string> keys = new List<string>(ScoreCard.Keys);
            foreach (string key in keys)
            {
                ScoreCard[key] = 0;
            }
        }
    }
}
