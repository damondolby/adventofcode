// See https://aka.ms/new-console-template for more information

using System.Numerics;

namespace advent_to_code;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Day1Part1 day1 = new();
        var inputLines = System.IO.File.ReadLines(@"day1_input.txt").ToList(); 
        Console.WriteLine($"Day 1 Part 1 Total={day1.Run(inputLines)}");
        Console.WriteLine($"Day 1 Part 2 Total={new advent_to_code.Day1().Run(inputLines)}");

        var day2Input = System.IO.File.ReadLines(@"input/day2.txt").ToList();
        Day2 day2 = new(day2Input);
        Console.WriteLine($"Day 2 Total={day2.GetTotalOfValidGameIDs()}");
        Console.WriteLine($"Day 2 Powers={day2.GetPowerOFHighestCubeCount()}");
        //Console.ReadLine();

        /*
            Day 1 Part 1 Total=53921
            Day 1 Part 2 Total=54676
            Day 2 Game Total=2795
            Day 2 Powers Total=75561
        */

    }

 


    
}