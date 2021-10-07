public class Solution {
    
    public double Traverse(int current, double sofar, int target, int t, Dictionary<int, HashSet<int>> map)
    {
        if(current == target && (t == 0 || !map.ContainsKey(current)))
        {
            return sofar;
        }
        
        //either time is 0 or we are a leaf node
        if(t == 0 || !map.ContainsKey(current)) return 0.0;
        
        var neighbors = map[current];
        var newprob = sofar / (double)neighbors.Count;
        t--;
        
        foreach(var item in neighbors)
        {
            var val = Traverse(item, newprob, target, t, map);
            if(val > 0.0)
            {
                return val;
            }
        }
        
        return 0.0;
    }

    public double FrogPosition(int n, int[][] edges, int t, int target)
    {
        Dictionary<int, HashSet<int>> map = new Dictionary<int, HashSet<int>>();
        
        for (int i = 0; i < edges.Length; i++)
        {
            var first = edges[i][0] < edges[i][1] ? edges[i][0] : edges[i][1];
            var second = edges[i][0] > edges[i][1] ? edges[i][0] : edges[i][1];

            if(!map.ContainsKey(first))
            {
                map.Add(first, new HashSet<int>());
            }
            map[first].Add(second);
        }

        var final = Traverse(1, 1, target, t, map);

        return final;
    }

}
