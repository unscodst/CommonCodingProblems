using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeChains
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node first = new Node { Value = 3 };
            Node middle = new Node { Value = 5 };
            //We are setting the Next value of first to middle. This creates the link to the middle node.
            first.Next = middle;

            Node last = new Node { Value = 7 };
            middle.Next = last;
            //We start from first, then link first.Next to middle, middle.Next to last.
            PrintList(first);
        }
        private static void PrintList(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
