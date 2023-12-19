namespace advent_to_code;

public class Day2()
{

    
    public int Run(List<string> inputLines)
    {
        var gameIDs = new List<int>();

        foreach (var line in inputLines)
        {
            var game = InitialiseGame(line);  
            if (game.IsValid)   
                gameIDs.Add(game.ID); 
        }

        var total = 0;
        gameIDs.ForEach(x => total+=x);
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
        return cubes[colour];
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