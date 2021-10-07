public class Solution {
    
    public bool DFS(int currentNode, int[] colors, int[][] edges, int colorWith, int prev)
    {
        if(colors[currentNode] != 0)
        {
            return colors[currentNode] == colorWith;
        }
    
        colors[currentNode] = colorWith;
        
        for(int i = 0; i < edges[currentNode].Length; i++)
        {
            if(edges[currentNode][i] == prev) continue;
            
            bool res = DFS(edges[currentNode][i], colors, edges, colorWith * -1, currentNode);
            if(res == false) return false;
        }
        
        return true;
    }
    
    public bool IsBipartite(int[][] graph) {
        
        for(int i = 0; i < graph.Length; i++){
            
            int[] colors = new int[graph.Length];
            if(DFS(i, colors, graph, 1, -1) == false) return false;
            
        }
        return true;
    }
}
