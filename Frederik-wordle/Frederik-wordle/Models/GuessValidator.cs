using System.Text.RegularExpressions;

namespace Frederik_wordle.Models
{/// <summary>
/// This class has 3 responsibilities: Check if the guess is legal, then check if it is perfect, and finally managing the helper classes that do more in depth guess processing,.
/// </summary>
    public class GuessValidator
    {
        string _guess;
        string _answer;
        bool _valid;

        public bool isValidGuess(string incomingGuess)
        {
            if (incomingGuess == null || incomingGuess.Length < 5) { _valid = false; }

            // regex checks that the incomingGuess only contains letters
            else if (Regex.IsMatch(incomingGuess, @"^[a-zA-Z]+$")) { _valid = true; }   

            else { _valid= false; } 

            return _valid;
        }

    }
}
