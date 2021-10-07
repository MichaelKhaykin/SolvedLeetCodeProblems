public class Solution {
    
    public (int, int) Left(int y, int x, HashSet<(int, int)> queenLocations)
    {
        var moveX = x;
        while(moveX >= 0)
        {
            moveX--;
            if(queenLocations.Contains((y, moveX))) return (y, moveX);
        }
        return (-1, -1);
    }
    
    public (int, int) Right(int y, int x, HashSet<(int, int)> queenLocations)
    {
        var moveX = x;
        while(moveX <= 7)
        {
            moveX++;
            if(queenLocations.Contains((y, moveX))) return (y, moveX);
        }
        return (-1, -1);
    }
    
    public (int, int) Up(int y, int x, HashSet<(int, int)> queenLocations)
    {
        var moveY = y;
        while(moveY >= 0)
        {
            moveY--;
            if(queenLocations.Contains((moveY, x))) return (moveY, x);
        }
        return (-1, -1);
    }
    
    public (int, int) Down(int y, int x, HashSet<(int, int)> queenLocations)
    {
        var moveY = y;
        while(moveY <= 7)
        {
            moveY++;
            if(queenLocations.Contains((moveY, x))) return (moveY, x);
        }
        return (-1, -1);
    }
    
    public (int, int) UpLeft(int y, int x, HashSet<(int, int)> queenLocations)
    {
        var moveY = y;
        var moveX = x;
        
        while(moveX >= 0 && moveY >= 0)
        {
            moveX--;
            moveY--;
            
            if(queenLocations.Contains((moveY, moveX))) return (moveY, moveX);
        }
        return (-1, -1);
    } 
    
    public (int, int) UpRight(int y, int x, HashSet<(int, int)> queenLocations)
    {
        var moveY = y;
        var moveX = x;
        
        while(moveX <= 7 && moveY >= 0)
        {
            moveX++;
            moveY--;
            
            if(queenLocations.Contains((moveY, moveX))) return (moveY, moveX);
        }
        return (-1, -1);
    } 
    
    public (int, int) DownRight(int y, int x, HashSet<(int, int)> queenLocations)
    {
        var moveY = y;
        var moveX = x;
        
        while(moveX <= 7 && moveY <= 7)
        {
            moveX++;
            moveY++;
            
            if(queenLocations.Contains((moveY, moveX))) return (moveY, moveX);
        }
        return (-1, -1);
    } 
    
    public (int, int) DownLeft(int y, int x, HashSet<(int, int)> queenLocations)
    {
        var moveY = y;
        var moveX = x;
        
        while(moveX >= 0 && moveY <= 7)
        {
            moveX--;
            moveY++;
            
            if(queenLocations.Contains((moveY, moveX))) return (moveY, moveX);
        }
        return (-1, -1);
    } 
    
    public IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king) {
        
        HashSet<(int, int)> queenLocations = new HashSet<(int, int)>();
        
        foreach(var tuple in queens)
        {
            queenLocations.Add((tuple[0], tuple[1]));
        }
        
        var x = king[1];
        var y = king[0];
        
        List<IList<int>> response = new List<IList<int>>();
        
        var b = Left(y, x, queenLocations);
        response.Add(new List<int>() { b.Item1, b.Item2 });
        
        b = Up(y, x, queenLocations);
        response.Add(new List<int>() { b.Item1, b.Item2 });
        
        b = Right(y, x, queenLocations);
        response.Add(new List<int>() { b.Item1, b.Item2 });
        
        b = Down(y, x, queenLocations);
        response.Add(new List<int>() { b.Item1, b.Item2 });
        
        b = UpLeft(y, x, queenLocations);
        response.Add(new List<int>() { b.Item1, b.Item2 });
        
        b = UpRight(y, x, queenLocations);
        response.Add(new List<int>() { b.Item1, b.Item2 });
        
        b = DownLeft(y, x, queenLocations);
        response.Add(new List<int>() { b.Item1, b.Item2 });
        
        b = DownRight(y, x, queenLocations);
        response.Add(new List<int>() { b.Item1, b.Item2 });
        
        return response.Where((c) => c[0] != -1 && c[1] != -1).ToList();
    }
}
