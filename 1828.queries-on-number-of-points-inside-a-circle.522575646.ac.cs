public class Solution {
    public int[] CountPoints(int[][] points, int[][] queries) {
        
        int[] counts = new int[queries.Length];
        
        for(int i = 0; i < queries.Length; i++){
            
            var centerX = queries[i][0];
            var centerY = queries[i][1];
            var radius = queries[i][2];
            
            int count = 0;
            
            for(int j = 0; j < points.Length; j++){
                var x = points[j][0];
                var y = points[j][1];
                
                var xoffset = x - centerX;
                var yoffset = y - centerY;
                
                if(xoffset * xoffset + yoffset * yoffset <= radius * radius)
                {
                    count++;
                }
            }
            
            counts[i] = count;
        }
        
        return counts;
    }
}
