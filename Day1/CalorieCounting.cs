using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AoC.Day1
{
    public class CalorieCounting
    {
        public static string[] Input { get; set; } = System.IO.File.ReadAllLines(@"D:\AoC\Day1\Calories.txt");

        private static int GetPartOneAnswer()
        {
            int tempSum = 0;
            int elfTop = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                try
                {
                    int calories = Int32.Parse(Input[i]);

                    tempSum += calories;
                    if(tempSum > elfTop)
                    {
                        elfTop = tempSum;
                    }
                }
                catch (FormatException)
                {
                    tempSum = 0;
                }
            }

            return elfTop;
        }

        private static int GetPartTwoAnswer()
        {
            int tempSum = 0;
            List<int> Calories = new List<int>();

            for (int i = 0; i < Input.Length; i++)
            {
                try
                {
                    int calories = Int32.Parse(Input[i]);

                    tempSum += calories;
                    Calories.Add(tempSum);
                }
                catch (FormatException)
                {
                    tempSum = 0;
                }
            }

            var orderedCalories = Calories.OrderByDescending(c => c).ToList();

            int total = 0;
            for(int i = 0; i < 3; i++)
            {
                total += orderedCalories[i];
            }

            return total;
        }

        public static string GetPrompt()
        {
            return $"Part 1: {GetPartOneAnswer()}\nPart 2: {GetPartTwoAnswer()}";
        }
    }
}
