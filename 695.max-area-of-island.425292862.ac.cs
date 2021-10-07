public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        int count = 0;

        Queue<(int y, int x)> pathway = new Queue<(int y, int x)>();
        HashSet<(int y, int x)> visited = new HashSet<(int y, int x)>();

        for (int i = 0; i < grid.Length; i++)
        {
            for(int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 0) continue;

                pathway.Clear();
                pathway.Enqueue((i, j));
                visited.Clear();

                int c = 0;
                while (pathway.Count > 0)
                {
                    var (y, x) = pathway.Dequeue();
                    grid[y][x] = 0;

                    int leftIndex = x - 1;
                    int rightIndex = x + 1;
                    int upIndex = y - 1;
                    int downIndex = y + 1;

                    if (!visited.Contains((y, leftIndex)) && leftIndex >= 0 && grid[y][leftIndex] == 1)
                    {
                        pathway.Enqueue((y, leftIndex));
                        visited.Add((y, leftIndex));
                    }
                    if (!visited.Contains((upIndex, x)) && upIndex >= 0 && grid[upIndex][x] == 1)
                    {
                        pathway.Enqueue((upIndex, x));
                        visited.Add((upIndex, x));
                    }
                    if (!visited.Contains((y, rightIndex)) && rightIndex < grid[y].Length && grid[y][rightIndex] == 1)
                    {
                        pathway.Enqueue((y, rightIndex));
                        visited.Add((y, rightIndex));
                    }
                    if (!visited.Contains((downIndex, x)) && downIndex < grid.Length && grid[downIndex][x] == 1)
                    {
                        pathway.Enqueue((downIndex, x));
                        visited.Add((downIndex, x));
                    }
                    
                    c++;
                }
                count = Math.Max(c, count);
        
            }
            
        }

        return count;   
    }
}
