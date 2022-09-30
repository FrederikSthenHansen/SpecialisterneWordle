using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleWPF.Model
{
    public static class BlankMatrixInitializer
    {
        public static int[,] InitializeBlankMatrix()
        {
            int[,] ret = new int[6, 5];
            return ret;
        }
    }
}
