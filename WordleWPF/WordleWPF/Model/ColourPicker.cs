using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WordleWPF.Model
{
    public static class ColourPicker
    {
        public static string pickColour(int colour)
        {
            string ret = "";
            switch (colour)
            {
                case 3: ret = "Brushes.DarkGray"; break;
                case 1: ret = "Brushes.Yellow"; break;
                case 2: ret = "Brushes.Green"; break;
                default: break;
            }
            return ret;
        }
       // public static void revertColour() { Console.ForegroundColor = ConsoleColor.Gray; }

    }
}
