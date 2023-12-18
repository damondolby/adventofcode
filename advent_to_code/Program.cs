// See https://aka.ms/new-console-template for more information

using System.Numerics;

namespace advent_to_code;

public class HelloWorld
{
    public static void Main(string[] args)
    {
        Day1Part1 day1 = new();
        var inputLines = System.IO.File.ReadLines(@"C:\Users\choit\Source\adventtocode\advent_to_code\day1_input.txt").ToList(); 
        Console.WriteLine($"Day 1 Total={day1.Run(inputLines)}");
        Console.WriteLine($"Day 2 Total={new advent_to_code.Day1().Run(inputLines)}");
        //Console.ReadLine();

    }

 


    
}