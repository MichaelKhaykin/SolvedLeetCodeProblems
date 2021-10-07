public class Solution {
    public bool CheckStraightLine(int[][] coordinates) {
        
        var deltaX = coordinates[0][0] - coordinates[1][0];
        var deltaY = coordinates[0][1] - coordinates[1][1];
        double slope = deltaX == 0 ? 0 : deltaY / (double)deltaX;
        double b = coordinates[0][1] - slope * coordinates[0][0];
        
        HashSet<int> xs = new HashSet<int>();
        HashSet<int> ys = new HashSet<int>();
        
        for(int i = 0; i < coordinates.Length; i++)
        {
            xs.Add(coordinates[i][0]);
            ys.Add(coordinates[i][1]);
        }
        
        if(xs.Count == 1 || ys.Count == 1) return true;
        
        for(int i = 2; i < coordinates.Length; i++)
        {
            if(coordinates[i][1] != coordinates[i][0] * slope + b)
            {
                return false;
            }
        }    
        return true;
    }
}
