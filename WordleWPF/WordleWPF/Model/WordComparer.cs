using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Windows.Annotations;

namespace WordleWPF.Model
{
    public static class WordComparer
    {   /// <summary>
        /// 1=yellow 2=green 0=Dark gray
        /// </summary>
        static int[] myReturn = new int[5];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guess"></param>
        /// <param name="answer"></param>
        /// <returns>Returns an array of ints that are to be fed as parameters into ColourPicker.PickColour()</returns>
        public static int[] CompareWords(char[] guess, string answer)
        {
            Dictionary<char, int> answerLetters = countLetters(answer);
            char[] answerArray = answer.ToCharArray(); 
            for (int i = 0; i < 5; i++)
            {

                if (checkVersusLetterCount(guess[i], answerLetters) == true)
                {
                    if (guess[i] == answerArray[i]) { myReturn[i] = 2; /*bogstavet er korrekt+korrekt placeret og bliver grønt*/ }

                    else  { myReturn[i] = 1; /*bogstavet er korrekt, men forkert placeret og bliver gult*/ }
                }
                else { myReturn[i] = 3; /*bogstavet er helt forkert og bliver mørkegråt*/ }
            }

            return myReturn;
        }



        /// <summary>
        /// Check if a letter occurs multiple times in the word to avoid flagging the same letter multiple times
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        private static bool checkVersusLetterCount(char c, Dictionary<char, int> check) 
        {
            bool ret=false;
            try { if (check[c]!=0) { ret = true; check[c]--; } }
            catch (KeyNotFoundException ex) {/*catchblock to prevent crash if check[c] does not return a value. no action needed*/ }
            return ret;
        }

        private static Dictionary<char, int> countLetters(string input)
        {
            char[] inputArray = input.ToCharArray();
            
            //sorter inholdet i strengen alpabnetisk
            input = String.Concat(input.OrderBy(c => c));

            //strengen splittes hvor bogstaverne skifter
            string[] resultStrings = input
                .Aggregate(" ", (seed, next) => seed + (seed.Last() == next ? "" : " ") + next)
                .Trim()
                .Split(' ');

            Dictionary<char, int> result= new Dictionary<char, int>();
            for (int x = 0; x< resultStrings.Length; x++)
            {
                result.Add(resultStrings[x].ElementAt(0), resultStrings[x].Length);
            }

            return result;
        }
    }
}
