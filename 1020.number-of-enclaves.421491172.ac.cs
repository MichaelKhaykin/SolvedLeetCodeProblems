public class Solution {
    
    public bool CanReachEdge(int i, int j, HashSet<(int, int)> visited, int[][] A)
    {
        if(i == 0 || j == 0 || i == A.Length - 1 || j == A[i].Length - 1)
        {
            return true;
        }
        
        visited.Add((i, j));
        
        bool l = false;
        bool r = false;
        bool u = false;
        bool d = false;
        if(i - 1 >= 0 && !visited.Contains((i - 1, j)) && A[i - 1][j] == 1)
        {
            u = CanReachEdge(i - 1, j, visited, A);
        }
        if(i + 1 < A.Length && !visited.Contains((i + 1, j)) && A[i + 1][j] == 1)
        {
            d = CanReachEdge(i + 1, j, visited, A);
        }
        if(j - 1 >= 0 && !visited.Contains((i, j - 1)) && A[i][j - 1] == 1)
        {
            l = CanReachEdge(i, j - 1, visited, A);
        }
        if(j + 1 < A[i].Length && !visited.Contains((i, j + 1)) && A[i][j + 1] == 1)
        {
            r = CanReachEdge(i, j + 1, visited, A);
        }
           
        return l || r || u || d;
    }
    
    public int NumEnclaves(int[][] A) {
      
        HashSet<(int, int)> totalVisited = new HashSet<(int, int)>();
         
        int ans = 0;
        
        for(int i = 0; i < A.Length; i++)
        {
            for(int j = 0; j < A[i].Length; j++)
            {
                if(totalVisited.Contains((i, j)) || A[i][j] == 0) continue;
                
                HashSet<(int, int)> visited = new HashSet<(int, int)>();
                
                bool y = CanReachEdge(i, j, visited, A);
                
                ans += y == false ? visited.Count : 0;
                
                foreach(var item in visited)
                {
                    totalVisited.Add(item);
                }
            }
        }
        
        return ans;
    }
}
