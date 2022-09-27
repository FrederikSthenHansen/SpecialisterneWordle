namespace Frederik_wordle.Models
{
    public class GuessHandler
    {
        public string Guess;
        private string _answer;
        

        bool _valid;

        public void HandleGuess(string incomingGuess)
        {

            if(GuessValidator.isValidGuess(incomingGuess) == true) 
            {

            }
            return;
        }
    }
}
