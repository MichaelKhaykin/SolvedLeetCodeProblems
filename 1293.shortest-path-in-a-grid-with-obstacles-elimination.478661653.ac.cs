public class Solution {
    
    public struct Point
    {
        public int X;
        public int Y;
        
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    
    public int ShortestPath(int[][] grid, int k) {
        
        return BFS(grid, new Point(grid[0].Length - 1, grid.Length - 1), k);
    }
    
    public int BFS(int[][] grid, Point end, int k)
    {
        Queue<(int, int, int)> queue = new Queue<(int, int, int)>();
        HashSet<(int, int, int)> poses = new HashSet<(int, int, int)>();
        
        queue.Enqueue((0, 0, k));
        poses.Add((0, 0, k));
        
        int res = 0;
        
        while(queue.Count > 0)
        {
            int count = queue.Count;
            while(count > 0)
            {
                (int x, int y, int remainder) = queue.Dequeue();

                if(x == end.X && y == end.Y)
                {
                    return res;
                }

                var neighbors = GetNeighbors((x, y, remainder), grid);

                foreach(var item in neighbors)
                {
                    if(poses.Contains((item.Item1, item.Item2, item.Item3))) continue;

                    queue.Enqueue(item);
                    poses.Add((item.Item1, item.Item2, item.Item3));
                }
                count--;
            }
            
            res++;
        }
        
        return -1;
    }
    
    public List<(int, int, int)> GetNeighbors((int, int, int) current, int[][] grid)
    {
        List<(int, int, int)> ret = new List<(int, int, int)>();
        
        if(current.Item2 - 1 >= 0)
        {
            if(grid[current.Item2 - 1][current.Item1] == 0)
            {
                ret.Add((current.Item1, current.Item2 - 1, current.Item3));    
            }
            else if(current.Item3 != 0) 
            {
                ret.Add((current.Item1, current.Item2 - 1, current.Item3 - 1));
            }
        }
        
        if(current.Item2 + 1 < grid.Length)
        {
            if(grid[current.Item2 + 1][current.Item1] == 0)
            {
                ret.Add((current.Item1, current.Item2 + 1, current.Item3));    
            }
            else if(current.Item3 != 0) 
            {
                ret.Add((current.Item1, current.Item2 + 1, current.Item3 - 1));
            }
        }
        
        if(current.Item1 - 1 >= 0)
        {
            if(grid[current.Item2][current.Item1 - 1] == 0)
            {
                ret.Add((current.Item1 - 1, current.Item2, current.Item3));    
            }
            else if(current.Item3 != 0) 
            {
                ret.Add((current.Item1 - 1, current.Item2, current.Item3 - 1));
            }
        }
        
        if(current.Item1 + 1 < grid[current.Item2].Length)
        {
            if(grid[current.Item2][current.Item1 + 1] == 0)
            {
                ret.Add((current.Item1 + 1, current.Item2, current.Item3));    
            }
            else if(current.Item3 != 0) 
            {
                ret.Add((current.Item1 + 1, current.Item2, current.Item3 - 1));
            }
        }
        
        return ret;
    }
}
