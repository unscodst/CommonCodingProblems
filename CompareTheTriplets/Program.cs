using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTheTriplets
{
    class Program
    {
        static int[] solve(int a0, int a1, int a2, int b0, int b1, int b2)
        {
            int[] a = { a0, a1, a2 };
            int[] b = { b0, b1, b2 };
            int[] total = { 0, 0 };
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > b[i])
                {
                    total[0]++;
                }
                else if (b[i] > a[i])
                {
                    total[1]++;
                }
            }
            return (total);
        }

        static void Main(string[] args)
        {
            solve(5, 6, 7, 3, 6, 10);
        }
    }
}
