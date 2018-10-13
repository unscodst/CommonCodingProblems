using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutSticks
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int[] cutCount;
            Console.WriteLine("Which Challenge do you want to try?" +
                "\n1: Cut Sticks" +
                "\n2: Search String");
            int challengeMethod = Convert.ToInt32(Console.ReadLine());
            switch(challengeMethod)
            {
                case 1:
                    Console.WriteLine("How mant=y sticks do you have?");
                    int stickAmount = Convert.ToInt32(Console.ReadLine());
                    int[] stickArray = new int[stickAmount];
                    Console.WriteLine("You have {0} sticks. What is the length of the sticks. Please seperate the lengths with a space.", stickAmount);
                    var stickLengths = Console.ReadLine();
                    stickArray = stickLengths.Split(' ').Select(int.Parse).ToArray();
                    cutCount = StickCut(stickArray);
                    foreach(int i in cutCount)
                    {
                        Console.WriteLine(i);
                    }
                    break;
                case 2:
                    Console.WriteLine("Please enter the characters to search");
                    string charSet = Console.ReadLine();
                    Console.WriteLine("Which method do you want to use?" +
                        "\n1: ForLoop" +
                        "\n2: List");
                    int method = Convert.ToInt32(Console.ReadLine());
                    count = SearchString(charSet, method);
                    Console.WriteLine(count);
                    break;
                default:
                    break;

            }           
            
            
            Console.ReadLine();
        }

        private static int[] StickCut(int[] stickArray)
        {
            List<int> output = new List<int>();
            var totalValues = stickArray.OrderBy(sA => sA).Distinct();
            foreach (int i in totalValues)
            {
                output.Add(stickArray.Count(stick => stick >= i));
            }
            return output.ToArray();
        }

        private static int SearchString(string charSet, int method)
        {
            int count = 0;
            int lowestTeam = 0;
            string searchString = "abcdabcdabcdadefagfeabcd";
            switch (method)
            {
                case 1:
                    char[] charArray = charSet.ToArray();
                    for (int i = 0; i < charArray.Length; i++)
                    {
                        count = 0;
                        for (int j = 0; j < searchString.Length; j++)
                        {
                            if (charArray[i] == searchString[j])
                            {
                                count++;
                            }
                        }
                        if (lowestTeam > count || lowestTeam == 0)
                        {
                            lowestTeam = count;
                        }

                    }
                    break;
                case 2:
                    var searchChar = searchString.OrderBy(sC => sC);
                    foreach(char currentChar in charSet)
                    {
                        count = searchChar.Count(passChar => passChar == currentChar);
                        if(lowestTeam > count || lowestTeam == 0)
                        {
                            lowestTeam = count;
                        }
                    }

                    break;
                default:
                    break;
            }

            
            return lowestTeam;
        }
    }
}
