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
            int oneElfSum = 0;
            int elfTop = 0;

            for (int i = 0; i < Input.Length; i++)
            {
                try
                {
                    int calories = Int32.Parse(Input[i]);

                    oneElfSum += calories;
                    if(oneElfSum > elfTop)
                    {
                        elfTop = oneElfSum;
                    }
                }
                catch (FormatException)
                {
                    oneElfSum = 0;
                }
            }

            return elfTop;
        }

        private static int GetPartTwoAnswer()
        {
            int oneElfSum = 0;
            List<int> caloriesList = new List<int>();

            for (int i = 0; i < Input.Length; i++)
            {
                try
                {
                    int calories = Int32.Parse(Input[i]);

                    oneElfSum += calories;
                    caloriesList.Add(oneElfSum);
                }
                catch (FormatException)
                {
                    oneElfSum = 0;
                }
            }

            var orderedCalories = caloriesList.OrderByDescending(c => c).ToList();

            int topThreeSum = 0;
            for(int i = 0; i < 3; i++)
            {
                topThreeSum += orderedCalories[i];
            }

            return topThreeSum;
        }

        public static string GetPrompt()
        {
            return $"Part 1: {GetPartOneAnswer()}\nPart 2: {GetPartTwoAnswer()}";
        }
    }
}
