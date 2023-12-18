namespace advent_to_code;

public class Day1Part1()
{
    public int Run(List<string> inputLines)
    {
        var codes = new List<int>();

        foreach (var line in inputLines)
        {
            int number = GetNumberFromLine(line);  
            codes.Add(number); 
        }

        var total = 0;
        codes.ForEach(x => total+=x);
        return total;
    }

    public int GetNumberFromLine(string line)
    {
        char? first = null;
            char? last = null;
            foreach(var c in line)
            {
                
                if (char.IsNumber(c))
                {
                    if (first == null)
                    {
                        first = c;
                        last = c;
                    }
                    else 
                        last = c;
                }
            }

            return int.Parse(first.ToString() + last.ToString());
    }

}

public class Day1()
{
    public Dictionary<string, int> numberMap = new Dictionary<string, int>{
        {"1", 1},
        {"2", 2}, 
        {"3", 3}, 
        {"4", 4}, 
        {"5", 5}, 
        {"6", 6}, 
        {"7", 7}, 
        {"8", 8}, 
        {"9", 9}, 
        {"one", 1}, 
        {"two", 2}, 
        {"three", 3}, 
        {"four", 4}, 
        {"five", 5}, 
        {"six", 6}, 
        {"seven", 7}, 
        {"eight", 8}, 
        {"nine", 9}
    };

    public int Run(List<string> inputLines)
    {
        var codes = new List<int>();

        foreach (var line in inputLines)
        {
            int number = GetValidDigitOrWordFromLine(line);  
            codes.Add(number); 
        }

        var total = 0;
        codes.ForEach(x => total+=x);
        return total;
    }
    
    public int GetValidDigitOrWordFromLine(string line)
    {
        var firstIndex = line.Length;
        var lastIndex = -1;
        var firstNumber = "";
        var lastNumber = "";
        foreach (var number in numberMap.Keys)
        {
            var firstIndexPos = line.IndexOf(number);
            if (firstIndexPos > -1 && firstIndexPos < firstIndex)
            {
                firstIndex = firstIndexPos;
                firstNumber = number;
            }

            var lastIndexPos = line.LastIndexOf(number);
            if (lastIndexPos > lastIndex)
            {
                lastIndex = lastIndexPos;
                lastNumber = number;
            }
        }

        return int.Parse(string.Format("{0}{1}", numberMap[firstNumber], numberMap[lastNumber]));
        
    }
}