namespace WordleConsole
{
    public static class WordComparer
    {   /// <summary>
    /// 1=yellow 2=green 0=red
    /// </summary>
        static int[] myReturn = new int[5];
        public static int[] CompareWords( char[] guess, char[] answer)
        { 
            for (int i = 0; i < 5; i++)
            {
                if (guess[i] == answer[i]) { myReturn[i] = 2; /*bogstavet er korrekt+korrekt placeret og bliver grønt*/ }
                else if (answer.Contains(guess[i])) {myReturn[i] = 1; /*bogstavet er korrekt, men forkert placeret og bliver gult*/ }
                else { myReturn[i] = 3; /*bogstavet er helt forkert og bliver rødt*/ }
            } 
            
            return myReturn;
        }
    }
}
