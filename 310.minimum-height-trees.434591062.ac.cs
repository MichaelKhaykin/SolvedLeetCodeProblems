public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        
        if(edges.Length == 0) return new List<int>() { 0 };
        
        //first pass is put the edge[][] into a better system
        Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        for(int i = 0; i < edges.Length; i++)
        {
            var n1 = edges[i][0];
            var n2 = edges[i][1];
            
            if(graph.ContainsKey(n1) == false)
            {
                graph.Add(n1, new List<int>() { });
            }
            if(graph.ContainsKey(n2) == false)
            {
                graph.Add(n2, new List<int>() { });
            }
            
            graph[n1].Add(n2);
            graph[n2].Add(n1);
        }
        
        List<int> leaves = new List<int>();
        foreach(var item in graph)
        {
            if(item.Value.Count == 1){
                leaves.Add(item.Key);
            }
        }
        
        int left = n;
        while(left > 2)
        {
            left -= leaves.Count;
            
            List<int> newLeaves = new List<int>();
            
            for(int i = 0; i < leaves.Count; i++)
            {
                var neighbor = graph[leaves[i]][0];
                graph[neighbor].Remove(leaves[i]);
                graph.Remove(leaves[i]);
                
                if(graph[neighbor].Count == 1)
                {
                    newLeaves.Add(neighbor);
                }
            }
            
            leaves = newLeaves;
        }
        
        return leaves;
    }
}
