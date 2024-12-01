using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    internal static class Extentions
    {

        public static int IncOne(this int number)
        {
            return ++number;
        }
    }
}
