public class Solution {
  
    public int[][] SpiralMatrixIII(int R, int C, int r0, int c0) 
   {
        //Right = 0, Down = 1, Left = 2, Up = 3
        
        int currDir = 0;
        HashSet<(int, int)> seen = new HashSet<(int, int)>();
        
        seen.Add((r0, c0));
        
        int width = C;
        int height = R;
        int totalElements = width * height;
        
        int startX = c0;
        int startY = r0;
        
        int countOfValid = 1;
        
        while(countOfValid < totalElements)
        {
            switch(currDir)
            {
                case 0:
                    startX++;
                    seen.Add((startY, startX));
                    
                    if(seen.Contains((startY + 1, startX)) == false)
                    {
                        currDir++;
                    }
                
                    break;
                    
                case 1:
            
                    startY++;
                    seen.Add((startY, startX));
                    
                    if(seen.Contains((startY, startX - 1)) == false)
                    {
                        currDir++;
                    }
                    
                    break;
                    
                case 2:
                    
                    startX--;
                    seen.Add((startY, startX));
                    
                    if(seen.Contains((startY - 1, startX)) == false)
                    {
                        currDir++;
                    }
                    
                    break;
                    
                case 3:
                    
                    startY--;
                    seen.Add((startY, startX));
                    
                    if(seen.Contains((startY, startX + 1)) == false)
                    {
                        currDir = 0;
                    }
                    
                    break;
            }
            
            if(IsValid(startX, startY, width, height))
            {
                countOfValid++;
            }
        }
        
        //do a select statement to transform items.. (REMEMBER TO DISCARD ALL ITEMS THAT ARE NOT WITHIN BOUNDARY)
        var matrix = seen.Where((x) => IsValid(x.Item2, x.Item1, width, height)).Select((x) => new int[] { x.Item1, x.Item2 }).ToArray();
    
        return matrix;
    }
   
    public bool IsValid(int x, int y, int width, int height)
    {
        return x >= 0 && x < width && y >= 0 && y < height;
    }
}
