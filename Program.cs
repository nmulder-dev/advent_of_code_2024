namespace advent_of_code_2024;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, Adevnt of Code 2024!!");
        Day1Part1();
        Day1Part2();
        Day2Part1();
        Day2Part2();
    }

    static void Day1Part1()
    {
        Console.WriteLine("Day 1: Part 1");

        // Load the input file
        string[] lines = System.IO.File.ReadAllLines("../../../input1a.txt");
        //string[] lines = ["3   4", "4   3", "2   5", "1   3", "3   9", "3   3"];
        List<int> list1 = [];
        List<int> list2 = [];

        // Parse line into lists
        foreach (string line in lines)
        {
            string[] parts = line.Split("   ");
            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[1]));
        }

        // Sort number lists
        list1.Sort();
        list2.Sort();

        int totalDistance = 0;
        // Get distance of list1 and list2
        for (int i = 0; i < list1.Count; i++)
        {
            totalDistance += Math.Abs(list1[i] - list2[i]);

            int distance = Math.Abs(list1[i] - list2[i]);
            //Console.WriteLine($"Distance between {list1[i]} and {list2[i]} is {distance}");
        }
        Console.WriteLine($"Total distance is {totalDistance}");
    }

    static void Day1Part2()
    {
        Console.WriteLine("Day 1: Part 2");

        // Load the input file
        string[] lines = System.IO.File.ReadAllLines("../../../input1a.txt");
        //string[] lines = ["3   4", "4   3", "2   5", "1   3", "3   9", "3   3"];
        List<int> list1 = [];
        List<int> list2 = [];

        // Parse line into lists
        foreach (string line in lines)
        {
            string[] parts = line.Split("   ");
            list1.Add(int.Parse(parts[0]));
            list2.Add(int.Parse(parts[1]));
        }

        // Sort number lists
        list1.Sort();
        list2.Sort();

        int count = 0;
        int score = 0;
        foreach (int num in list1)
        {
            // Get countof occurnces of num in list2
            foreach (int num2 in list2)
            {
                if (num == num2)
                {
                    count++;
                }
            }
            score = score + count * num;
            count = 0;
        }
        Console.WriteLine($"Total score is {score}");
    }

    static void Day2Part1()
    {
        int safeCount = 0;

        Console.WriteLine("Day 2: Part 1");
        string[] levelLines = File.ReadAllLines("../../../input2.txt");

        foreach (string line in levelLines)
        {
            int[] levels = line.Split(" ").Select(int.Parse).ToArray();
            int length = levels.Length;
            bool safe = true;
            string changeType = "";

            for (int i = 1; i < length; i++)
            {
                int value = levels[i - 1] - levels[i];
                int delta = Math.Abs(value);

                // Change too great, unsafe
                if (delta == 0 || delta > 3)
                {
                    safe = false;
                    break;
                }

                if (value < 0)
                {
                    // Change in direction, unsafe
                    if (changeType == "decrease")
                    {
                        safe = false;
                        break;
                    }
                    changeType = "increase";
                }
                else if (value > 0)
                {
                    // Change in direction, unsafe
                    if (changeType == "increase")
                    {
                        safe = false;
                        break;
                    }
                    changeType = "decrease";
                }
                else
                {
                    // No change in direction. unsafe
                    safe = false;
                    break;
                }
            }
            if (safe)
                safeCount++;
        }
        Console.WriteLine($"Safe count is {safeCount}");
    }

    static void Day2Part2() { }
}
