using System.Net.Mail;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using advent_to_code;

namespace advent_to_code_tests;

public class Day1Tests
{
    [Fact]
    public void Test_IsValidNumberFromLine()
    {
        string line = "seven6sbmhmlkjk9clmfive5dbrgflgtbkhtkqlt";

        var day1 = new Day1Part1();
        
        Assert.Equal(65, day1.GetNumberFromLine(line));  
    }

    [Theory]
    [InlineData("seven6sbmhmlkjk9clmfive5dbrgflgtbkhtkqlt", 75)]
    [InlineData("4r", 44)]
    [InlineData("ninebqqbmqklht6mxfdsxdtwothreehrcvlzkqg", 93)]
    [InlineData("9fivenine", 99)]
    [InlineData("jp3", 33)]
    [InlineData("six3four82b8", 68)]
    [InlineData("nx7", 77)]
    [InlineData("224vrbbhfivegfkfxjkdmf3sjfthjzrstwo", 22)]
    public void Test_IsValidDigitOrWordNumber(string line, int expected)
    {
        //string line = "seven6sbmhmlkjk9clmfive5dbrgflgtbkhtkqlt";

        var day1 = new Day1();

        Assert.Equal(expected, day1.GetValidDigitOrWordFromLine(line)); 
    }
}

