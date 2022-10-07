using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleWPF.ViewModel
{   /// <summary>
/// This class encapsulates the information the view needs to display the result of a guess being submitted.
/// </summary>
    internal class GuessHandlingResultList
    {
        /// <summary>
        ///
        /// validity: true=the guess was valid and a round of the game has elapsed 
        /// gameOver: true= the game was ended this round
        /// victory: true= the player won the game this round
        /// </summary>
       public Dictionary<string, bool> GameStates;


        /// <summary>
        /// 
        /// </summary>
        public int[,] colours;

        public GuessHandlingResultList(Dictionary<string, bool> gameStates, int[,] colours)
        {
            GameStates = gameStates;
            this.colours = colours; 
        }
    }
}
