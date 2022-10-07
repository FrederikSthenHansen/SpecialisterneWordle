using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WordleWPF.Commands;
using WordleWPF.Model;


namespace WordleWPF.ViewModel
{
    internal class WordleViewModel:ViewModelBase
    {
        Dictionary<string, bool> _bools = new Dictionary<string, bool>();
        List<string> _displayedGuesses = new List<string>();
        ObservableCollection<string> _displayedGuesses2 = new ObservableCollection<string>();
        List<TextBox> boxList = new List<TextBox>();
        string _myGuess;
        public string DisplayAnswer;
        public string MyGuess
        { get { return _myGuess; } set { _myGuess = value; OnPropertyChanged(MyGuess); } }

        

        public ICommand LetterPressCommand { get; }
        
        GameMaster myGameMaster; //Remember to remove this GM

        public string LetterPressed(string input)
        {
            List<char> Ar;

            if (input.Contains("Backspace"))
            {
                Ar = myGameMaster.Guess.ToList();
                if (myGameMaster.Guess != "") 
                {
                    //remove last part of List
                    Ar.RemoveAt(Ar.Count - 1);
                }
                
            }

            else
            {
                if (myGameMaster.Guess.ToArray().Length < 5)
                {
                    myGameMaster.Guess = $"{myGameMaster.Guess}{input}"; 
                }
                Ar = myGameMaster.Guess.ToList();
                //reset guess before assigning Ar to it
                
            }
            myGameMaster.Guess = "";
            for (int i = 0; i < Ar.Count; i++)
            {
                if (Ar[i] != ' ') { myGameMaster.Guess = $"{myGameMaster.Guess}{Ar[i]}"; }

            }

            // for the refactioring
            MyGuess = myGameMaster.Guess;

            // Old code
            return $"{myGameMaster.Guess}";
        }

        public GuessHandlingResultList  GuessSubmitted()
        {
           List<Object> ret = new List<Object>();

           Dictionary<string,bool>dictionary= myGameMaster.HandleGuess(myGameMaster.Guess);
           

            GuessHandlingResultList myReturn = new GuessHandlingResultList(dictionary,myGameMaster._colours);
           
           return myReturn;
        }


        public async Task<bool> NewGame()
        {
            myGameMaster.newGame(false);
            return true;
        }


        

        public WordleViewModel()
        {
            myGameMaster = new GameMaster();
            myGameMaster.newGame(false);
            DisplayAnswer = myGameMaster.DisplayAnswer;
            

            LetterPressCommand = new LetterPressCommand();
            _myGuess = "";
        }
        
    } 
}
    

