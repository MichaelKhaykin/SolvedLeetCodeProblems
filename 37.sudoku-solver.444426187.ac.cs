public class Solution
{

    public void SolveSudoku(char[][] board)
    {
        SolverWithCSP s = new SolverWithCSP(board);
        
        for(int i = 0; i < board.Length; i++)
        {
            for(int j = 0; j < board.Length; j++)
            {
                board[i][j] = s.final[i][j];
            }
        }
    }
}

public class SolverWithCSP
{
    struct Point
    {
        public int X;
        public int Y;
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        
        public static bool operator==(Point a, Point b)
        {
            return a.X == b.X && a.Y == b.Y;
        }
        
        public static bool operator!=(Point a, Point b) => !(a == b);
    }
    
    class PriorityQueue<T> : IEnumerable<T>
    {
        private List<T> Data;
        public Comparer<T> Comparer { get; }
        public int Count => Data.Count;

        public PriorityQueue(int capacity, Comparer<T> comparer)
        {
            Data = new List<T>(capacity);
            Comparer = comparer;
        }

        public PriorityQueue(IEnumerable<T> collection, Comparer<T> comparer)
        {
            Comparer = comparer;
            Data = new List<T>();

            foreach(var item in collection)
            {
                Insert(item);
            }
        }

        public void Insert(T data)
        {
            Data.Add(data);
            HeapifyUp(Count - 1);
        }

        public T Pop()
        {
            var top = Data[0];

            Data[0] = Data[Count - 1];
            Data.RemoveAt(Count - 1);

            HeapifyDown(0);

            return top;
        }
        public void HeapifyUp(int index)
        {
            //this means we are root, no swaps to be done
            if (index == 0) return;

            var parent = (index - 1) / 2;

            if(Comparer.Compare(Data[index], Data[parent]) < 0)
            {
                var swap = Data[parent];
                Data[parent] = Data[index];
                Data[index] = swap;
            }
            HeapifyUp(parent);
        }
        public void HeapifyDown(int index)
        {
            var left = index * 2 + 1;
            var right = index * 2 + 2;

            if (left >= Count) return;

            var swap = left;

            if(right < Count)
            {
                swap = Comparer.Compare(Data[left], Data[right]) > 0 ? right : left;
            }

            if(Comparer.Compare(Data[swap], Data[index]) < 0)
            {
                var temp = Data[swap];
                Data[swap] = Data[index];
                Data[index] = temp;
            }
            HeapifyDown(swap);
        }
        public IEnumerator<T> GetEnumerator()
        {
            for(int i = 0; i < Data.Count; i++)
            {
                yield return Data[i];
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Data.Count; i++)
            {
                yield return Data[i];
            }
        }
    }
    class Node
    {
        public Point Location { get; }
        public char CurrentValue { get; set; }
        public HashSet<char> Domain { get; set; }

        public Dictionary<Point, Node> Edges = new Dictionary<Point, Node>();
        public Node(Point location, char currentValue, HashSet<char> initialDomain)
        {
            Location = location;
            CurrentValue = currentValue;
            Domain = initialDomain;
        }
    }

    public char[][] final;
    
    public SolverWithCSP(char[][] board)
    {
        HashSet<char> domain = Enumerable.Range(1, 9).Select((x) => (char)(x + 48)).ToHashSet();

        int cellSize = 3;

        Dictionary<Point, Node> fastLookUp = new Dictionary<Point, Node>();
        Queue<Point> pointsToTry = new Queue<Point>();
        HashSet<Point> currentlyInAgenda = new HashSet<Point>();

        //initialize
        Node[][] nodes = new Node[board.Length][];
        char[][] values = new char[nodes.Length][];
        for (int i = 0; i < nodes.Length; i++)
        {
            nodes[i] = new Node[board.Length];
            for (int j = 0; j < nodes.Length; j++)
            {
                var pnt = new Point(j, i);

                if (board[i][j] != '.')
                {
                    nodes[i][j] = new Node(pnt, board[i][j], new HashSet<char>());

                    if (values[i] == null) values[i] = new char[values.Length];

                    values[i][j] = board[i][j];
                }
                else
                {
                    nodes[i][j] = new Node(pnt, '0', new HashSet<char>(domain));
                }

                fastLookUp.Add(pnt, nodes[i][j]);

                pointsToTry.Enqueue(pnt);
                currentlyInAgenda.Add(pnt);
            }
        }

        //set up graph and valid domains
        for (int i = 0; i < nodes.Length; i++)
        {
            for (int j = 0; j < nodes.Length; j++)
            {
                var node = nodes[i][j];

                //this is a fixed node
                if (node.CurrentValue != '0') continue;

                for (int x = 0; x < nodes.Length; x++)
                {
                    if (x == j) continue;

                    if (node.Edges.ContainsKey(nodes[i][x].Location)) continue;
                    node.Edges.Add(nodes[i][x].Location, nodes[i][x]);
                }
                for (int x = 0; x < nodes.Length; x++)
                {
                    if (x == i) continue;

                    if (node.Edges.ContainsKey(nodes[x][j].Location)) continue;
                    node.Edges.Add(nodes[x][j].Location, nodes[x][j]);
                }

                int xThreeByThree = (j / cellSize) * cellSize;
                int yThreeByThree = (i / cellSize) * cellSize;

                for (int y = yThreeByThree; y < yThreeByThree + cellSize; y++)
                {
                    for (int x = xThreeByThree; x < xThreeByThree + cellSize; x++)
                    {
                        if (x == j && y == i) continue;

                        if (node.Edges.ContainsKey(nodes[y][x].Location)) continue;
                        node.Edges.Add(nodes[y][x].Location, nodes[y][x]);
                    }
                }
            }

        }

        //CSP (pruning)
        while (pointsToTry.Count > 0)
        {
            var currentPoint = pointsToTry.Dequeue();
            currentlyInAgenda.Remove(currentPoint);

            var node = fastLookUp[currentPoint];

            (bool passes, char keyToRemove) = PassesConstraint(node);
            if (passes) continue;

            if (node.Location == new Point(0, 0))
            {

            }
            node.Domain.Remove(keyToRemove);

            pointsToTry.Enqueue(node.Location);
            currentlyInAgenda.Add(currentPoint);
        }


        //Back tracking
        PriorityQueue<Node> emptyNodes = new PriorityQueue<Node>(100, Comparer<Node>.Create(new Comparison<Node>((x, y) => x.Domain.Count.CompareTo(y.Domain.Count))));

        for (int i = 0; i < nodes.Length; i++)
        {
            for (int j = 0; j < nodes.Length; j++)
            {
                if (nodes[i][j].Domain.Count == 0) continue;

                emptyNodes.Insert(nodes[i][j]);
            }
        }

        char[][] final = new char[nodes.Length][];

        BackTracker(emptyNodes, values, final);

        this.final = final;
    }

    private bool BackTracker(PriorityQueue<Node> step, char[][] values, char[][] final)
    {
        if(step.Count == 0)
        {
            for(int i = 0; i < values.Length; i++)
            {
                final[i] = new char[values.Length];
                for(int j = 0; j < values.Length; j++)
                {
                    final[i][j] = values[i][j];
                }
            }
            return true;
        }

        PriorityQueue<Node> nonReference = new PriorityQueue<Node>(step, step.Comparer);
        var current = nonReference.Pop();

        var listy = current.Domain.ToList();
        for(int i = 0; i < listy.Count; i++)
        {
            current.CurrentValue = listy[i];

            if(values[current.Location.Y] == null)
            {
                values[current.Location.Y] = new char[values.Length];
            }

            values[current.Location.Y][current.Location.X] = listy[i];

            List<bool> happened = new List<bool>();
            foreach(var edge in current.Edges)
            {
                var edgeNode = edge.Value;
                happened.Add(edgeNode.Domain.Remove(current.CurrentValue));

                //maybe?
            //    nonReference.HeapifyDown(0);
            }

            if (BackTracker(nonReference, values, final)) return true;

            int indexer = -1;
            foreach(var edge in current.Edges)
            {
                indexer++;
                if (happened[indexer] == false) continue;

                var edgeNode = edge.Value;
                edgeNode.Domain.Add(current.CurrentValue);

                //maybe??
            //    nonReference.HeapifyUp(nonReference.Count - 1);
            }
        }

        return false;
    }

    private (bool didPass, char keyToRemoveIfFailed) PassesConstraint(Node node)
    {
        //having domain pass a constraint is said as every item in the domain 
        //not intersecting with any other item currently on the board

        foreach(var key in node.Domain)
        {
            //check for key intersection

            foreach(var edge in node.Edges)
            {
                var edgeNode = edge.Value;

                if(edgeNode.CurrentValue == key)
                {
                    return (false, key);
                }
            }
        }

        return (true, ' ');
    }
}
