using System.Collections.ObjectModel;

namespace Frederik_wordle.Models
{
    public class GameMaster
    {
        string wordlePath = "";
        string[] WordleWords;  /* System.IO.File.ReadAllLines($"{wordlePath}"); */
        public string Guess="";
        private string _answer="";
        

        public void HandleGuess(string incomingGuess)
        {
            //Check om gættet kan overholder spillereglerne som error prevention
            if(GuessValidator.isValidGuess(incomingGuess,WordleWords) == true) 
            { Guess = incomingGuess;
                if (Guess == _answer) { /*Spilleren har gættet rigtig og vundet*/}
                //Gættet sammenlignes mere dybdegående med svaret for at de enkelte valg af bogstaver kan blive evalueret
                else { int[] colours= WordComparer.CompareWords(Guess.ToCharArray(), _answer.ToCharArray());
                }
            }
            return;
        }
        public GameMaster()
        {
            wordlePath = "...\\GitHub\\SpecialisterneWordle";
            WordleWords = System.IO.File.ReadAllLines(wordlePath);
        }
    }
}
