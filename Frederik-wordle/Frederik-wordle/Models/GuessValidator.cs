using System.Text.RegularExpressions;

namespace Frederik_wordle.Models
{/// <summary>
/// This class has 3 responsibilities: Check if the guess is legal, then check if it is perfect, and finally managing the helper classes that do more in depth guess processing,.
/// </summary>
    public class GuessValidator
    {
        
        

        public static bool isValidGuess(string incomingGuess)
        {
            bool _valid;
            if (incomingGuess == null || incomingGuess.Length < 5) { return false; }

            // regex checks that the incomingGuess only contains letters
            else if (Regex.IsMatch(incomingGuess, @"^[a-zA-Z]+$")) { _valid = true; }   

            else { _valid= false; } 

            return _valid;
        }

    }
}
