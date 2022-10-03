using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleWPF.Model
{
    public static class ScreenPainter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="guesses"></param>
        /// <param name="colours">array of int to indicate wanted colours. For no request put an array[5] with only 3's</param>
        public static void UpdateScreen(Collection<string> guesses, int[,] colours)
        {
            int alphabetRow = 1;
            int drawGuess = 0;
            string floor = "###########";
            string walls = "# # # # # #";
            string[] alphabet = new string[5] { "ABCDE", "FGHIJ", "KLMNO", "PQRST", "UVWYZ" };

            //Console.;
           // Console.SetCursorPosition(0, 0);
            Console.Write(floor);
            for (int row = 1; row < 13; row++)
            {

                Console.SetCursorPosition(0, row);

                if (row % 2 == 0) { Console.Write(floor); }

                else if (row > guesses.Count * 2 - 1) { Console.Write(walls); } //Problem: for hver gang guesses stiger med 1 stiger row med 2

                else
                {


                    char[] array = guesses[drawGuess].ToCharArray();

                    //special skrivning af første felt

                    Console.Write("#");
                    ColourPicker.pickColour(colours[drawGuess, 0]);
                    Console.Write(array[0]);
                    //ColourPicker.revertColour();
                    Console.Write("#");

                    for (int x = 1; x < array.Length; x++)
                    {
                        ColourPicker.pickColour(colours[drawGuess, x]);
                        Console.Write(array[x]);
                        //ColourPicker.revertColour();
                        Console.Write("#");
                    }
                    drawGuess++;

                }

                Console.SetCursorPosition(13, row);

                if (alphabetRow < 7)
                {
                    if (alphabetRow == 1) { Console.Write("Unused Letters:"); }
                    else
                    {
                        char[] alphabetChar = alphabet[alphabetRow - 2].ToCharArray();
                        for (int x = 0; x < alphabetChar.Length; x++)
                        {
                            foreach (var g in guesses)
                            { if (g.Contains(alphabetChar[x])) { ColourPicker.pickColour(4); } }

                            Console.Write(alphabetChar[x]);
                           // ColourPicker.revertColour();
                        }
                        //Console.Write(alphabet[alphabetRow - 2]); 
                    }

                    alphabetRow++;
                }


            }
            Console.SetCursorPosition(0, 15);
            Console.WriteLine("Please type your guess (a 5 letter english word in the singular) and press enter to 'submit'");

        }

    }
}

