using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib01_ex2
{
    public class Factorial
    {
        public static long calculateFatorial(int n)
        {
            if (n <= 0) return 1;
            else return n * calculateFatorial(n - 1);
        }
    }
}
