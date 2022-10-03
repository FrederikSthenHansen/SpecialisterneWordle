using System.Collections.ObjectModel;

namespace WordleConsole
{
    /// <summary>
    /// This class has the responsibility of managing the flow of the game, like a D&D GM
    /// </summary>
    public class GameMaster
    {
        string wordlePath = "";
                List<string> WordleWords;  /* System.IO.File.ReadAllLines($"{wordlePath}"); */
        Collection<string> previousAnswers= new Collection<string>();
        public string Guess="";
        private string _answer="";
        Collection<string> guesses;
        public int[,] _colours;
        
        public void newGame(bool instructions)
        {
            ColourPicker.revertColour();
            Console.WriteLine("Starting new game");
            guesses = new Collection<string>();
            Thread.Sleep(1000);
            Console.Clear();
            string myReturn = "";
            
            myReturn=AnswerPicker.PickAnswer(WordleWords,previousAnswers);
            previousAnswers.Add(myReturn);
            _colours = new int[6, 5] /*BlankMatrixInitializer.InitializeBlankMatrix()*/;
            _answer = myReturn.ToUpper();

            if (instructions == true)
            {
                Teacher.instruct();
            }
            Console.Clear();
            ScreenPainter.UpdateScreen(guesses,_colours);
        }

        public bool HandleGuess(string incomingGuess)
        {
            bool gameOver = false;
            //Check om gættet kan overholder spillereglerne som error prevention
            if(GuessValidator.isValidGuess(incomingGuess,WordleWords) == true) 
            { Guess = incomingGuess.ToUpper();
                guesses.Add(Guess);
                if (Guess == _answer) 
                {
                    /*Spilleren har gættet rigtig og vundet*/
                    Console.WriteLine("Congratulations! you guessed the word!");
                    gameOver = true; 
                }

                //Gættet sammenlignes mere dybdegående med svaret for at de enkelte valg af bogstaver kan blive evalueret
                 int[] colours= WordComparer.CompareWords(Guess.ToCharArray(), _answer.ToCharArray());
                for(int x= 0; x < colours.Length; x++)
                {
                    //First guess has to index as 0
                     _colours[guesses.Count-1, x] = colours[x];    
                }
            }

            //if the guess is not valid
            else
            {
                Teacher.scold();
            }

            ScreenPainter.UpdateScreen(guesses, _colours); 
            if (guesses.Count==6 && gameOver == false) { Console.WriteLine("Sorry, you lose."); gameOver = true; }
            return gameOver;
        }
        public GameMaster()
        {
            wordlePath = "C:\\Users\\KOM\\Documents\\GitHub\\SpecialisterneWordle\\possible_words.txt";
            WordleWords = System.IO.File.ReadAllLines(wordlePath).ToList();
            guesses = new Collection<string>();
        }
    }
}
