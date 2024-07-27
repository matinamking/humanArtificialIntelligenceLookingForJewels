class javaher
{
    public static void Main()
    {
        int[,] state = {
         { 1, 1, 1 ,1},
         { 1, 1, 1 ,1},
         { 1, 1, 1 ,1},
         { 1, 1, 1 ,1}};

        rand(state);
        print(state);
        Console.WriteLine("******************");


        BFS bfs = new BFS(state);
        bfs.SolveBFS();

    }
    public static void rand(int[,] arr)
    {
        Random random = new Random();
        for (int i = 0; i < 4; i++)
        {
            arr[random.Next(0, 3), random.Next(0, 3)] = 4;
        }
        while (true)
        {
            int x = random.Next(0, 3);
            int y = random.Next(0, 3);
            if (arr[x, y] != 4)
            {
                arr[x, y] = 3; break;
            }
        }
        while (true)
        {
            int x = random.Next(0, 3);
            int y = random.Next(0, 3);
            if (arr[x, y] != 4 && arr[x, y] != 3)
            {
                arr[x, y] = 0; break;
            }
        }
        while (true)
        {
            int x = random.Next(0, 3);
            int y = random.Next(0, 3);
            if (arr[x, y] != 4 && arr[x, y] != 3 && arr[x, y] != 0)
            {
                arr[x, y] = 2; break;
            }
        }
    }
    public static void print(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            Console.WriteLine("");
            Console.Write(":");
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == 0)
                {
                    Console.Write(" S :");
                }
                else if (arr[i, j] == 1)
                {
                    Console.Write(" . :");
                }
                else if (arr[i, j] == 4)
                {
                    Console.Write(" G :");
                }
                else if (arr[i, j] == 3)
                {
                    Console.Write(" W :");
                }
                else if (arr[i, j] == 2)
                {
                    Console.Write(" J :");
                }
            }
        }
        Console.WriteLine("");
    }
}
class BFS
{
    private readonly int[,] initialState;
    private int[] location = new int[2];
    public int[] locationgoal = new int[2];
    public BFS(int[,] initialState)
    {
        this.initialState = initialState;
        locationGoal(initialState, locationgoal);
    }
    private bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < 4 && y >= 0 && y < 4;
    }

    private List<Tuple<int, int>> GetNeighbors(int[,] matrix, int x, int y)
    {
        var neighbors = new List<Tuple<int, int>>();
        int[,] moves = { { 0, 1 }, { 1, 0 }, { 0, -1 }, { -1, 0 } };

        for (int i = 0; i < moves.GetLength(0); i++)
        {
            int newX = x + moves[i, 0];
            int newY = y + moves[i, 1];
            if (IsValidMove(newX, newY))
            {
                if (stateLocation(initialState, newX, newY))
                {
                    neighbors.Add(new Tuple<int, int>(newX, newY));
                }
            }
        }

        return neighbors;
    }
    public void locationGoal(int[,] arr, int[] location)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == 2)
                {
                    location[0] = i;
                    location[1] = j;
                    break;
                }
            }
        }
    }
    private string ArrayToString(int[,] arr)
    {
        string result = "";
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                result += arr[i, j].ToString();
            }
        }

        return result;
    }

    public void locationZero(int[,] arr, int[] location)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == 0)
                {
                    location[0] = i;
                    location[1] = j;
                    break;
                }
            }
        }
    }

    public bool StateGoal(int[,] arr, int x, int y)
    {
        return arr[x, y] == 0;
    }

    public bool stateLocation(int[,] arr, int x, int y)
    {
        return arr[x, y] != 4 && arr[x, y] != 3;
    }
    public int[,] ConvertStringToArray(string stateKey)
    {
        int[,] arr = new int[4, 4];
        int index = 0;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                arr[i, j] = int.Parse(stateKey[index].ToString());
                index++;
            }
        }

        return arr;
    }
    public void print(int[,] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            Console.WriteLine("");
            Console.Write(":");
            for (int j = 0; j < arr.GetLength(1); j++)
            {
                if (arr[i, j] == 0)
                {
                    Console.Write(" S :");
                }
                else if (arr[i, j] == 1)
                {
                    Console.Write(" . :");
                }
                else if (arr[i, j] == 4)
                {
                    Console.Write(" G :");
                }
                else if (arr[i, j] == 3)
                {
                    Console.Write(" W :");
                }
                else if (arr[i, j] == 2)
                {
                    Console.Write(" J :");
                }
            }
        }
        Console.WriteLine("");
    }
    private List<string> path = new List<string>();

    private string GetMove(int currentX, int currentY, int newX, int newY, int[,] currentState)
    {
        if (newX == currentX - 1 && newY == currentY && currentState[currentX - 1, currentY] != 3 && currentState[currentX - 1, currentY] != 4)
        {
            path.Add("Up");
            return "Up";
        }
        if (newX == currentX + 1 && newY == currentY && currentState[currentX + 1, currentY] != 3 && currentState[currentX + 1, currentY] != 4)
        {
            path.Add("Dn");
            return "Dn";
        }
        if (newX == currentX && newY == currentY - 1 && currentState[currentX, currentY - 1] != 3 && currentState[currentX, currentY - 1] != 4)
        {
            path.Add("Left");
            return "Lefht";
        }
        if (newX == currentX && newY == currentY + 1 && currentState[currentX, currentY + 1] != 3 && currentState[currentX, currentY + 1] != 4)
        {
            path.Add("Right");
            return "Right";
        }

        return "";
    }

    public void SolveBFS()
    {
        Queue<Tuple<int[,], int, int, List<string>>> queue = new Queue<Tuple<int[,], int, int, List<string>>>();
        HashSet<string> visited = new HashSet<string>();

        locationZero(initialState, location);
        List<string> initialPath = new List<string>();
        queue.Enqueue(new Tuple<int[,], int, int, List<string>>(initialState, location[0], location[1], initialPath));

        while (queue.Count > 0)
        {
            var currentStateTuple = queue.Dequeue();
            int[,] currentState = currentStateTuple.Item1;

            int x = currentStateTuple.Item2;
            int y = currentStateTuple.Item3;
            List<string> currentPath = currentStateTuple.Item4;

            if (StateGoal(currentState, locationgoal[0], locationgoal[1]))
            {
                Console.WriteLine("yes");
                Console.WriteLine("visited :" + visited.Count.ToString());
                Console.WriteLine("path: " + string.Join(", ", currentPath));
                return;
            }

            foreach (var neighborTuple in GetNeighbors(currentState, x, y))
            {
                int newX = neighborTuple.Item1;
                int newY = neighborTuple.Item2;
                int[,] newState = (int[,])currentState.Clone();
                newState[x, y] = currentState[newX, newY];
                newState[newX, newY] = currentState[x, y];

                string newStateString = ArrayToString(newState);

                if (!visited.Contains(newStateString))
                {
                    visited.Add(newStateString);
                    List<string> newPath = new List<string>(currentPath);
                    newPath.Add(GetMove(x, y, newX, newY, currentState));
                    queue.Enqueue(new Tuple<int[,], int, int, List<string>>(newState, newX, newY, newPath));
                }
            }

        }
        Console.WriteLine("no");
    }
}
