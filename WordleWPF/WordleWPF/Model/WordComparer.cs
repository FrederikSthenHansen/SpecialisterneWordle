using System;
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
        public static int[] CompareWords(char[] guess, string answer)
        {
            char[] answerArray = answer.ToCharArray();
            var input = answer;
            input=String.Concat(input.OrderBy(c => c));
            var result = input
                .Aggregate(" ", (seed, next) => seed + (seed.Last() == next ? "" : " ") + next)
                .Trim()
                .Split(' ');

            for (int i = 0; i < 5; i++)
            { 
                if (guess[i] == answerArray[i]) { myReturn[i] = 2; /*bogstavet er korrekt+korrekt placeret og bliver grønt*/ }
                else if (answerArray.Contains(guess[i])) { myReturn[i] = 1; /*bogstavet er korrekt, men forkert placeret og bliver gult*/ }
                else { myReturn[i] = 3; /*bogstavet er helt forkert og bliver mørkegråt*/ }
            }

            return myReturn;
        }
    }
}
