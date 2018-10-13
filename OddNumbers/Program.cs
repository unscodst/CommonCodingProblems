using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int l = 2;
            int r = 5;

            oddNumbers(l, r);
        }
        static int [] oddNumbers(int l, int r)
        {
            int arraySize = 0;
            for(int i = l; i <= r; i++)
            {
                if(i%2 != 0)
                {
                    arraySize++;
                }
            }
            int[] result = new int[arraySize];
            arraySize = 0;
            for (int i = l; i <= r; i++)
            {
                if (i % 2 != 0)
                {
                    result[arraySize] = i;
                    arraySize++;
                }
            }
            return result;
        }
    }
}
