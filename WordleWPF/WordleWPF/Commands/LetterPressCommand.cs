using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleWPF.Commands
{
    public class LetterPressCommand:CommandBase
    {
        private string _guess=""; //ideally this needs to be filled with the existing unsubmitted guess

        public override void Execute(object parameter/*, out object ret*/) //Can i pass multiple parameters? i need both the Letter pressed, and the existing guess
        {
            string inputLetter = parameter.ToString().Split(':')[1];
            //string returnMessage = myViewModel.LetterPressed(inputLetter);
            //myGuess = returnMessage;

            List<char> updatedGuess=handleInputLetter(inputLetter);

            //reset guess before assigning Ar to it
            _guess= "";
            for (int i = 0; i < updatedGuess.Count; i++)
            {
                if (updatedGuess[i] != ' ') { _guess = $"{_guess}{updatedGuess[i]}"; }
            }

            //sneakily disguised returnvalue
            //ret= _guess;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guess">This is the unsubmitted guess in its current form</param>
        public LetterPressCommand(string guess)
        {
            _guess = guess; 
        }
        
        private List<char> handleInputLetter(string input)
        {List <char> Ar;
            if (input.Contains("Backspace"))
            {
                Ar = _guess.ToList();
                if (_guess != "")
                {
                    //remove last part of List
                    Ar.RemoveAt(Ar.Count - 1);
                }
            }


            else
            {
                if (_guess.ToArray().Length < 5)
                {
                    _guess = $"{_guess}{input}";
                }
                Ar = _guess.ToList();

            }
            return Ar;
        }
    }
}
