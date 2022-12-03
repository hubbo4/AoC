namespace AoC.Day2
{
    public class RockPaperScissors
    {
        public static string[] Input { get; set; } = System.IO.File.ReadAllLines(@"D:\AoC\Day2\RockPaperScissors.txt");
        public static IDictionary<string,string>? GameDictionary { get; set; }
        public static IDictionary<string, int>? PointsDictionary { get; set; }

        private static int GetPartOneAnswer()
        {
            string[][] games = new string[Input.Length][];
            for(int i = 0; i < Input.Length; i++)
            {
                games[i] = Input[i].Split(" ")!;
            }

            InitializeDictionariesPartOne();

            int myPoints = 0;
            for (int i = 0; i < games.Length; i++)
            {
                if (GameDictionary![games[i][0]] == "rock")
                {
                    if (GameDictionary[games[i][1]] == "paper")
                    {
                        myPoints += 6;
                    }
                    else if(GameDictionary[games[i][1]] == "rock")
                    {
                        myPoints += 3;
                    }
                }
                else if(GameDictionary[games[i][0]] == "paper")
                {
                    if (GameDictionary[games[i][1]] == "scissors")
                    {
                        myPoints += 6;
                    }
                    else if (GameDictionary[games[i][1]] == "paper")
                    {
                        myPoints += 3;
                    }
                }
                else
                {
                    if (GameDictionary[games[i][1]] == "rock")
                    {
                        myPoints += 6;
                    }
                    else if (GameDictionary[games[i][1]] == "scissors")
                    {
                        myPoints += 3;
                    }
                }
                myPoints += PointsDictionary![games[i][1]];
            }

            return myPoints;
        }

        private static int GetPartTwoAnswer()
        {
            InitializeDictionaryPartTwo();

            int myPoints = 0;
            for(int i = 0; i < Input.Length; i++)
            {
                myPoints += PointsDictionary![Input[i]];
            }

            return myPoints;
        }

        private static void InitializeDictionariesPartOne()
        {
            PointsDictionary = new Dictionary<string, int>();
            GameDictionary = new Dictionary<string, string>();

            PointsDictionary.Add("X", 1);
            PointsDictionary.Add("Y", 2);
            PointsDictionary.Add("Z", 3);

            GameDictionary.Add("A", "rock");
            GameDictionary.Add("B", "paper");
            GameDictionary.Add("C", "scissors");

            GameDictionary.Add("X", "rock");
            GameDictionary.Add("Y", "paper");
            GameDictionary.Add("Z", "scissors");
        }

        private static void InitializeDictionaryPartTwo()
        {
            PointsDictionary = new Dictionary<string, int>();

            PointsDictionary.Add("A X", 3);
            PointsDictionary.Add("A Y", 4);
            PointsDictionary.Add("A Z", 8);
            PointsDictionary.Add("B X", 1);
            PointsDictionary.Add("B Y", 5);
            PointsDictionary.Add("B Z", 9);
            PointsDictionary.Add("C X", 2);
            PointsDictionary.Add("C Y", 6);
            PointsDictionary.Add("C Z", 7);
        }

        public static void GetPrompt()
        {
            Console.WriteLine($"Day 2 => Part 1: {GetPartOneAnswer()}, Part 2: {GetPartTwoAnswer()}");
        }
    }
}
