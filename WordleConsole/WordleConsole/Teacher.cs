using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleConsole
{
    public static class Teacher
    {
        public static void instruct()
        {

            Console.WriteLine("The rules are as follows: ");
            Console.WriteLine(" - You have 6 tries to guess a 5 letter word. ");
            Console.WriteLine("The word is NOT case sensitive.");
            Console.WriteLine("(The same letter can feature multiple times in the same word). ");
            Console.WriteLine(" - You can only guess with english words (with no plurals!) ");
            Console.WriteLine("(your guess will be checked for viability before it is counted)");
            Console.WriteLine(" - Upon submitting an answer it will appear in a table in coloured table");
            Console.WriteLine("Green= The letter is correct, and in the correct positon");
            Console.WriteLine("Yellow= The letter is correct, but in the wrong position");
            Console.WriteLine("Red= The letter is not featured in the word");
            Console.WriteLine("When you are ready to begin the game, press any key");
            Console.ReadKey();
        }

        public static void scold()
        {
            Console.WriteLine("You did not input a valid guess");
            Console.WriteLine("Please make sure to use only 5 letter english words in the singular!");
            Console.WriteLine("The guess is not counted towards your total");
            Console.WriteLine("Press any Key guess again...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
