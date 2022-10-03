using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleWPF.Model;


namespace WordleWPF.ViewModel
{
    internal class WordleViewModel
    {
        GameMaster GM;
        public string LetterPressed(string input)
        {
            List<char> Ar;

            if (input.Contains("Backspace"))
            {
                Ar = GM.Guess.ToList();
                //remove last part of List
                Ar.RemoveAt(Ar.Count - 1);
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

            public WordleViewModel()
            {
                GM = new GameMaster();
            }
        
    } 
}
    

