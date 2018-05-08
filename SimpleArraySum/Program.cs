using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleArraySum
{
    class Program
    {
        static int SimpleArraySum(int[] ar)
        {
            int sumar = 0;
            for(int i = 0; i < ar.Length ; i++)
            {
                sumar += ar[i];
            }
            return sumar;
        }
        static void Main(string[] args)
        {
        }
    }
}
