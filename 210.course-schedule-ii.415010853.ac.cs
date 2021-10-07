public class Solution {
    
    public class GraphNode
    {
        public int val;
        public List<GraphNode> edges = new List<GraphNode>();


        public GraphNode(int val)
        {
            this.val = val;
        }
    }
    
    public void TopologicalSort(Stack<GraphNode> result, HashSet<GraphNode> visited, List<GraphNode> allNodes)
    {
        foreach (var item in allNodes)
        {
            if (visited.Contains(item)) continue;

            TopologicalSortHelper(item, result, visited);
        }

        static void TopologicalSortHelper(GraphNode current, Stack<GraphNode> result, HashSet<GraphNode> visited)
        {
            visited.Add(current);

            foreach (var item in current.edges)
            {
                if (visited.Contains(item)) continue;

                TopologicalSortHelper(item, result, visited);
            }

            result.Push(current);
        }
    }

    
     public bool IsCylic(List<GraphNode> verticies)
        {
            int[] state = new int[verticies.Count];
            Dictionary<GraphNode, int> map = new Dictionary<GraphNode, int>();
            Dictionary<int, GraphNode> reversed = new Dictionary<int, GraphNode>();

            for(int i = 0; i < verticies.Count; i++)
            {
                map.Add(verticies[i], i);
            }

            for (int i = 0; i < verticies.Count; i++)
            {
                if (state[map[verticies[i]]] == 0)
                {
                    if (Helper(verticies[i], state, map) == true) return true;
                }
            }
            return false;

            static bool Helper(GraphNode vertex, int[] state, Dictionary<GraphNode, int> map)
            { 
                if (state[map[vertex]] == 2) return true;

                state[map[vertex]] = 2;

                foreach(var item in vertex.edges)
                {
                    if (state[map[item]] == 1) continue;

                    if(Helper(item, state, map))
                    {
                        return true;
                    }
                }

                state[map[vertex]] = 1;
                return false;
            }
        }

    
    public int[] FindOrder(int numCourses, int[][] prerequisites) {
        
        if(prerequisites.Length == 0) 
        {
            int x = numCourses - 1;
            List<int> lol = new List<int>();
            while(x >= 0)
            {
                lol.Add(x);
                x--;
            }
            return lol.ToArray();
        }
        
        Dictionary<int, GraphNode> mapping = new Dictionary<int, GraphNode>();

        List<GraphNode> allNodes = new List<GraphNode>();

        foreach (var item in prerequisites)
        {
            var item1 = item[0];
            var item2 = item[1];

            if (!mapping.ContainsKey(item1))
            {
                var n = new GraphNode(item1);
                mapping.Add(item1, n);
                allNodes.Add(n);
            }
            if (!mapping.ContainsKey(item2))
            {
                var n = new GraphNode(item2);
                mapping.Add(item2, n);
                allNodes.Add(n);
            }

            mapping[item1].edges.Add(mapping[item2]);
        }

        if(IsCylic(allNodes)) return new int[] {};
        
        Stack<GraphNode> result = new Stack<GraphNode>();
        TopologicalSort(result, new HashSet<GraphNode>(), allNodes);
        
        List<int> res = new List<int>();
        while(result.Count > 0)
        {
            res.Add(result.Pop().val);
        }
        res.Reverse();
        
        int rart = numCourses - 1;
        while(rart >= 0)
        {
            if(res.Contains(rart))
            {
                rart--;
                continue;
            }
            res.Insert(0, rart);
        }
        
        return res.ToArray();
    }
}
