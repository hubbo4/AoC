using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Day3
{
    public class RucksackReorganization
    {
        public static string[] Input { get; set; } = System.IO.File.ReadAllLines(@"D:\AoC\Day3\Rucksack.txt");
        public static IDictionary<char,int>? Priorities { get; set; } = new Dictionary<char,int>();

        private static int GetPartOneAnswer()
        {
            List<char> firstComparement = new List<char>(), secondComparement = new List<char>();
            int prioritiesSum = 0;

            for(int i = 0; i < Input.Length; i++)
            {

                for (int j = 0; j < Input[i].Length; j++)
                {
                    if (j < Input[i].Length / 2)
                    {
                        firstComparement.Add(Input[i][j]);
                    }
                    else
                    {
                        secondComparement.Add(Input[i][j]);
                    }
                }
                var temp = firstComparement.Intersect(secondComparement);

                foreach (char c in temp)
                {
                    prioritiesSum += Priorities![c];
                }

                firstComparement.Clear();
                secondComparement.Clear();
            }

            return prioritiesSum;
        }

        private static int GetPartTwoAnswer()
        {
            List<char> firstRucksack = new List<char>(), secondRucksack = new List<char>(), thirdRucksack = new List<char>();
            int prioritiesSum = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                int position = i % 3;
                for (int j = 0; j < Input[i].Length; j++)
                {
                    switch (position)
                    {
                        case 0:
                            firstRucksack.Add(Input[i][j]);
                            break;
                        case 1:
                            secondRucksack.Add(Input[i][j]);
                            break;
                        case 2:
                            thirdRucksack.Add(Input[i][j]);
                            break;
                    }
                }

                if(position == 2)
                {
                    var temp = firstRucksack.Intersect(secondRucksack).Intersect(thirdRucksack);

                    foreach (char c in temp)
                    {
                        prioritiesSum += Priorities![c];
                    }

                    firstRucksack.Clear();
                    secondRucksack.Clear();
                    thirdRucksack.Clear();
                }
            }

            return prioritiesSum;
        }
        private static void InitializePriorities()
        {
            int lowercasePriority = 1;
            int uppercasePriority = 27;

            for (int i = 65; i < 123; i++)
            {
                if (i < 91)
                {
                    Priorities!.Add((char)i, uppercasePriority);
                    uppercasePriority++;
                }
                else if (i > 96)
                {
                    Priorities!.Add((char)i, lowercasePriority);
                    lowercasePriority++;
                }
            }
        }

        public static void GetPrompt()
        {
            InitializePriorities();
            Console.WriteLine($"Day 3 => Part 1: {GetPartOneAnswer()}, Part 2: {GetPartTwoAnswer()}");
        }
    }
}
