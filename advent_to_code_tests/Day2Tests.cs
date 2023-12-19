using System.Net.Mail;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using advent_to_code;

namespace advent_to_code_tests;

public class Day2Tests
{
    [Theory]
    [InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", true, 1, 3, 4)]
    [InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", false, 3, 3, 20)]
    public void Test_InitialiseGame(string gameInput, bool isValid, int gameID, int noOfSets, int noOfRedsInSet1)
    {
        var day2 = new Day2();
        var game = day2.InitialiseGame(gameInput);

        Assert.Equal(isValid, game.IsValid);
        Assert.Equal(gameID, game.ID);
        Assert.Equal(noOfSets, game.NumberOfSets);
        Assert.Equal(noOfRedsInSet1, game.GetCubesInSet(0, Game.CubeType.red)); 
    }

    [Fact]
    public void Test_RunAndGameTotal()
    {
        var games = new List<string>{
            "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
        };

        var day2 = new Day2();
        var gameTotal = day2.Run(games);

        Assert.Equal(8, gameTotal);
    }
}