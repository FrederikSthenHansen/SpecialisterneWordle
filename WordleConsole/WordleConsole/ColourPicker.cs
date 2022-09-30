using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleConsole
{
    public static class ColourPicker
    {
        public static void pickColour(int colour) 
        { 
            
                switch (colour)
                {
                    case 3: Console.ForegroundColor = ConsoleColor.Red; break;
                    case 1: Console.ForegroundColor = ConsoleColor.Yellow; break;    
                    case 2: Console.ForegroundColor = ConsoleColor.Green; break;
                    case 4: Console.ForegroundColor = ConsoleColor.Black; break;  
                    default: break;
                } 
            
        } 
        public static void revertColour() { Console.ForegroundColor= ConsoleColor.Gray; }    

    }
}
