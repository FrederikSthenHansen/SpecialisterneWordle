using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WordleWPF.Model
{
    /// <summary>
    /// This class has the responsibility of managing the flow of the game, like a D&D GM
    /// </summary>
    public class GameMaster
    {
        string wordlePath = "";
        List<string> WordleWords;  /* System.IO.File.ReadAllLines($"{wordlePath}"); */
        Collection<string> previousAnswers = new Collection<string>();
        public string Guess = "";
        private string _answer = "";
        public string DisplayAnswer { get { return _answer; }  }    
        Collection<string> guesses;
        public int[,] _colours;

        public void newGame(bool instructions)
        {
            guesses = new Collection<string>();
            
            string myReturn = "";

            myReturn = AnswerPicker.PickAnswer(WordleWords, previousAnswers);
            previousAnswers.Add(myReturn);
            _colours = new int[6, 5] ;
            _answer = myReturn.ToUpper();

            if (instructions == true)
            {
                // possible navigate to instructions page?
            }
            
        }

        public Dictionary<string, bool> HandleGuess(string incomingGuess)
        { 
            Dictionary <string,bool> ret= new Dictionary<string,bool>();
            bool gameOver = false;
            bool victory = false;
            bool validity=false;
            //Check om gættet kan overholder spillereglerne som error prevention
            if (GuessValidator.isValidGuess(incomingGuess, WordleWords) == true)
            {
                validity = true;
                
                Guess = incomingGuess.ToUpper();
                guesses.Add(Guess);
                if (Guess == _answer)
                {
                    /*Spilleren har gættet rigtig og vundet*/
                    
                    gameOver = true;
                    victory = true;
                }

                //Gættet sammenlignes mere dybdegående med svaret for at de enkelte valg af bogstaver kan blive evalueret
                int[] colours = WordComparer.CompareWords(Guess.ToCharArray(), _answer);
                for (int x = 0; x < colours.Length; x++)
                {
                    //First guess has to index as 0
                    _colours[guesses.Count - 1, x] = colours[x];
                }
            }

            ret.Add("validity", validity);
            
            if (guesses.Count == 6 && gameOver == false) {  gameOver = true; }
            ret.Add("victory", victory);
            ret.Add("gameOver", gameOver);

            //Finish by clearing the Guess property, so a new guess can be put in next turn
            Guess = "";

            return ret;
        }
        public GameMaster()
        {
            wordlePath = "C:\\Users\\KOM\\Documents\\GitHub\\SpecialisterneWordle\\possible_words.txt";
            WordleWords = System.IO.File.ReadAllLines(wordlePath).ToList();
            guesses = new Collection<string>();
        }
    }
}
