public class Solution {
    public int MaxPoints(int[][] points) {
        
        var map = new Dictionary<(double, double, int), int>();
        
    var lineToPointsInLine = new Dictionary<(double slope, double offset, int), HashSet<(int, int, int)>>();
        
        int max = 1;
        
        Dictionary<int, int> xs = new Dictionary<int, int>();
        Dictionary<int, int> ys = new Dictionary<int, int>();
        
        for(int i = 0; i < points.Length; i++)
        {
            if(xs.ContainsKey(points[i][0])){
                xs[points[i][0]]++;
                
                max = Math.Max(xs[points[i][0]], max);
            }
            else{
                xs.Add(points[i][0], 1);
            }
            
            if(ys.ContainsKey(points[i][1])){
                ys[points[i][1]]++;
                
                max = Math.Max(ys[points[i][1]], max);
            }
            else{
                ys.Add(points[i][1], 1);
            }
            
            for(int j = i + 1; j < points.Length; j++)
            {
                double changeY = points[i][1] - points[j][1];
                double changeX = points[i][0] - points[j][0];
                var slope = changeY / changeX;
                var offset = points[i][1] - slope * points[i][0];
            
                if(map.ContainsKey((slope, offset, i))){
                   
                    if(!lineToPointsInLine[(slope, offset, i)].Contains((points[i][0], points[i][1], i))){
                        map[(slope, offset, i)]++;
                        lineToPointsInLine[(slope, offset, i)].Add((points[i][0], points[i][1], i));
                    }
                    if(!lineToPointsInLine[(slope, offset, i)].Contains((points[j][0], points[j][1], j))){
                        map[(slope, offset, i)]++;
                        lineToPointsInLine[(slope, offset, i)].Add((points[j][0], points[j][1], j));
                    }
                    
                    max = Math.Max(map[(slope, offset, i)], max);
                }
                else{
                    map.Add((slope, offset, i), 2);
                    
                    lineToPointsInLine.Add((slope, offset, i), new HashSet<(int, int, int)>());
                    lineToPointsInLine[(slope, offset, i)].Add((points[i][0], points[i][1], i));
                    lineToPointsInLine[(slope, offset, i)].Add((points[j][0], points[j][1], j));
                    
                    max = Math.Max(max, 2);
                }
            }
        }
        
        return max;
    }
}
