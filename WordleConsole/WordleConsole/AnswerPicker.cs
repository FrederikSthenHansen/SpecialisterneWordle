using System.Collections.ObjectModel;

namespace WordleConsole
{
    public static class AnswerPicker
    {/// <summary>
    /// Pick answer 
    /// </summary>
    /// <param name="options"></param>
    /// <param name=""></param>
    /// <returns> a string array with 2 strings in: </returns>
        public static string PickAnswer(List<string> options, Collection<string>previous)
        {

            foreach (string prevAnswer in previous)
            {
                if(options.Contains(prevAnswer)){options.Remove(prevAnswer);}
            }  
            
            Random random = new Random(); 
            int i= random.Next(0, options.Count-1); 
            return options[i];
            
        }
    }
}
