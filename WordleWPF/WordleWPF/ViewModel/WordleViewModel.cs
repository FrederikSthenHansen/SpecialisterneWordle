using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WordleWPF.Model;


namespace WordleWPF.ViewModel
{
    internal class WordleViewModel:ViewModelBase
    {
        Dictionary<string, bool> _bools = new Dictionary<string, bool>();
        List<string> _displayedGuesses = new List<string>();
        ObservableCollection<string> _displayedGuesses2 = new ObservableCollection<string>();
        List<TextBox> boxList = new List<TextBox>();
        string myGuess;
       

        public ICommand LetterPressCommand { get; }
        
        GameMaster GM; //Remember to remove this GM

        public string LetterPressed(string input)
        {
            List<char> Ar;

            if (input.Contains("Backspace"))
            {
                Ar = GM.Guess.ToList();
                if (GM.Guess != "") 
                {
                    //remove last part of List
                    Ar.RemoveAt(Ar.Count - 1);
                }
                
            }


            else
            {
                if (GM.Guess.ToArray().Length < 5)
                {
                    GM.Guess = $"{GM.Guess}{input}"; 
                }
                Ar = GM.Guess.ToList();
                //reset guess before assigning Ar to it
                
            }
            GM.Guess = "";
            for (int i = 0; i < Ar.Count; i++)
            {
                if (Ar[i] != ' ') { GM.Guess = $"{GM.Guess}{Ar[i]}"; }

            }
            return $"{GM.Guess}";
        }

        public List<Object>  GuessSubmitted()
        {
           List<Object> ret = new List<Object>();

           ret.Add( GM.HandleGuess(GM.Guess));
           ret.Add(GM._colours);
           
           return ret;
        }


        public async Task<bool> NewGame()
        {
            GM.newGame(false);
            return true;
        }


        

        public WordleViewModel()
        {
            GM = new GameMaster();
            GM.newGame(false);
        }
        
    } 
}
    

