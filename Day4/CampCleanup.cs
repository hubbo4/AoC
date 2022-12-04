namespace AoC.Day4
{
    public class CampCleanup
    {
        public static string[] Input { get; set; } = System.IO.File.ReadAllLines(@"D:\AoC\Day4\CampCleanup.txt");
        private static (int, int) GetAnswers()
        {
            int sumPart1 = 0, sumPart2 = 0;
            for(int i = 0; i < Input.Length; i++)
            {
                int p1min = Int32.Parse(Input[i].Split(",")[0].Split("-")[0]);
                int p1max = Int32.Parse(Input[i].Split(",")[0].Split("-")[1]);
                int p2min = Int32.Parse(Input[i].Split(",")[1].Split("-")[0]);
                int p2max = Int32.Parse(Input[i].Split(",")[1].Split("-")[1]);

                if(p1min >= p2min && p1max <= p2max || p2min >= p1min && p2max <= p1max)
                {
                    sumPart1++;
                }

                if (!(p1min > p2max || p2min > p1max || p1max < p2min || p2max < p1min))
                {
                    sumPart2++;
                }
            }
            return (sumPart1, sumPart2);
        }
        public static void GetPrompt()
        {
            Console.WriteLine($"Day 3 => Part 1: {GetAnswers().Item1}, Part 2: {GetAnswers().Item2}");
        }
    }
}
