namespace advent_to_code;

public class Day2
{

    private List<Game> games;

    public Day2()
    {
        games = new List<Game>();
    }

    public Day2(List<string> inputLines)
    {
        games = new List<Game>();
        InitialiseGames(inputLines);
    }

    private void InitialiseGames(List<string> inputLines)
    {
        games = new List<Game>();
        foreach (var line in inputLines)
        {
            games.Add(InitialiseGame(line)); 
        }
    }
    
    public int GetTotalOfValidGameIDs()
    {
        var gameIDs = new List<int>();

        foreach (var game in games)
        { 
            if (game.IsValid)   
                gameIDs.Add(game.ID); 
        }

        var total = 0;
        gameIDs.ForEach(x => total+=x);
        return total;
    }

    public int GetPowerOFHighestCubeCount()
    {
       var gamePowers = new List<int>();

        foreach (var game in games)
        {
            gamePowers.Add(game.GetPowerOFHighestCubeCount()); 
        }

        var total = 0;
        gamePowers.ForEach(x => total+=x);
        return total;
    }
    
    public Game InitialiseGame(string gameInput)
    {
        var game = new Game(gameInput);
        game.Initialise();
        return game;
    }
}

public class Game
{

    private string gameInput;
    public Game (string gameInput)
    {
        this.gameInput = gameInput;
    }
    
    public enum CubeType
    {
        red,
        blue,
        green
    }
    public int ID {get; private set;}
    public bool IsValid{get;private set;}
    public int NumberOfSets{get {return cubeSets.Count;}}

    public void Initialise()
    {
        InitialiseGameID();
        InitialiseGameSets();
        InitialiseValidity();
    }

    private void InitialiseValidity()
    {
        //only 12 red cubes, 13 green cubes, and 14 blue cubes?
        foreach(var cubeSet in cubeSets)
        {
            if (!cubeSet.IsSetValid())
            {
                IsValid = false;
                return;
            }
        }
        IsValid = true;
    }

    private void InitialiseGameID()
    {
        var tokens1 = gameInput.Split(':');
        ID = int.Parse(tokens1[0].Substring(5));
    }

    private void InitialiseGameSets()
    {
        var tokens1 = gameInput.Split(':');
        var setTokens = tokens1[1].Split(';');
        foreach(var set in setTokens)
        {
            //var cubeTokens = set.Split(',');
            var cubeSet = new CubeSet(set);
            cubeSets.Add(cubeSet);
        }
    }

    List<CubeSet> cubeSets = new();

    public int GetCubesInSet(int setNumber, CubeType colour)
    {
        var set = cubeSets[setNumber];
        return set.GetCubeCount(colour);
    }

    public int GetPowerOFHighestCubeCount()
    {
        int blue = 0;
        int red = 0;
        int green = 0;
        foreach (var set in cubeSets)
        {
            var b = set.GetCubeCount(CubeType.blue);
            blue = b > blue ? b : blue;

            var r = set.GetCubeCount(CubeType.red);
            red = r > red ? r : red;

            var g = set.GetCubeCount(CubeType.green);
            green = g > green ? g : green;

        }
       
        return blue*red*green;
    }
}

internal class CubeSet
{
    internal Dictionary<Game.CubeType, int> cubes = new();

    private Dictionary<Game.CubeType, int> MaxCubeCount = new()
    {
        {Game.CubeType.blue, 14},
        {Game.CubeType.red, 12},
        {Game.CubeType.green, 13},
    };

    private string cubeInput;
    public CubeSet(string cubeInput)
    {
        //"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
        this.cubeInput = cubeInput;
        InitialiseSet();
    }

    public int GetCubeCount(Game.CubeType colour)
    {
        if (cubes.ContainsKey(colour)) 
            return cubes[colour];
        else 
            return 0;
    }

    public bool IsSetValid()
    {
        foreach (var cube in cubes.Keys)
        {
            if (cubes[cube] > MaxCubeCount[cube])
            {
                return false;
            }
        }
        return true;
    }

    private void InitialiseSet()
    {
        var cubes = cubeInput.Split(',');
        foreach (var cube in cubes)
        {
            AddCube(cube);
        }
    }

    private void AddCube(string cube)
    {
        foreach (Game.CubeType type in Enum.GetValues(typeof(Game.CubeType)))
        {
            var index = cube.IndexOf(type.ToString());
            if (index > -1)
            {
                var noOfCubes = cube.Substring(0, index-1);
                cubes.Add(type, int.Parse(noOfCubes));
                break;
            }
        }
    }
}