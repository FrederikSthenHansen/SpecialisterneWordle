using System;
using System.Collections.ObjectModel;

namespace WordleWPF
{
    public static class AnswerPicker
    {/// <summary>
    /// Pick answer 
    /// </summary>
    /// <param name="options"></param>
    /// <param name=""></param>
    /// <returns> a string array with 2 strings in: </returns>
        public static string PickAnswer(string[] options, Collection<string>previous)
        {
            
            Random random = new Random(); 
            int i= random.Next(0, options.Length-1); 
            return options[i];
            
        }
    }
}
