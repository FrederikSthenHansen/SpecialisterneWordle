using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace WordleConsole
{/// <summary>
/// This class has 3 responsibilities: Check if the guess is legal, then check if it is perfect, and finally managing the helper classes that do more in depth guess processing,.
/// </summary>
    public class GuessValidator
    {
        
        

        public static bool isValidGuess(string incomingGuess, List<string> words)
        {
            bool _valid;

            if (incomingGuess!=null && words.Contains(incomingGuess.ToLower() ) ) { _valid = true; }

            
            //if (incomingGuess == null || incomingGuess.Length < 5) { return false; }

            // regex checks that the incomingGuess only contains letters
            //else if (System.IO.File./* Regex.IsMatch(incomingGuess, @"^[a-zA-Z]+$" */)) {  }   

            else { _valid= false; } 

            return _valid;
        }

    }
}
