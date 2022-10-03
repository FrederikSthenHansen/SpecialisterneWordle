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
        Collection<string> guesses;
        public int[,] _colours;

        public void newGame(bool instructions)
        {
            //ColourPicker.revertColour();
            // Console.WriteLine("Starting new game");
            guesses = new Collection<string>();
            //Thread.Sleep(1000);
            //Console.Clear();
            string myReturn = "";

            myReturn = AnswerPicker.PickAnswer(WordleWords, previousAnswers);
            previousAnswers.Add(myReturn);
            _colours = new int[6, 5] /*BlankMatrixInitializer.InitializeBlankMatrix()*/;
            _answer = myReturn.ToUpper();

            if (instructions == true)
            {
                //Console.WriteLine("The rules are as follows: ");
                //Console.WriteLine(" - You have 6 tries to guess a 5 letter word. ");
                //Console.WriteLine("The word is NOT case sensitive.");
                //Console.WriteLine("(The same letter can feature multiple times in the same word). ");
                //Console.WriteLine(" - You can only guess with english words (with no plurals!) ");
                //Console.WriteLine("(your guess will be checked for viability before it is counted)");
                //Console.WriteLine(" - Upon submitting an answer it will appear in a table in coloured table");
                //Console.WriteLine("Green= The letter is correct, and in the correct positon");
                //Console.WriteLine("Yellow= The letter is correct, but in the wrong position");
                //Console.WriteLine("Red= The letter is not featured in the word");
                //Console.WriteLine("When you are ready to begin the game, press any key");
                //Console.ReadKey();
            }
            // Console.Clear();
            // ScreenPainter.UpdateScreen(guesses, _colours);
        }

        public Dictionary<string, bool> HandleGuess(string incomingGuess)
        { Dictionary <string,bool> ret= new Dictionary<string,bool>();
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
                    //Console.WriteLine("Congratulations! you guessed the word!");
                    gameOver = true;
                    victory = true;
                }

                //Gættet sammenlignes mere dybdegående med svaret for at de enkelte valg af bogstaver kan blive evalueret
                int[] colours = WordComparer.CompareWords(Guess.ToCharArray(), _answer.ToCharArray());
                for (int x = 0; x < colours.Length; x++)
                {
                    //First guess has to index as 0
                    _colours[guesses.Count - 1, x] = colours[x];
                }
            }

            ret.Add("validity", validity);
            //  ScreenPainter.UpdateScreen(guesses, _colours);
            if (guesses.Count == 6 && gameOver == false) { /*Console.WriteLine("Sorry, you lose.");*/ gameOver = true; }
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
