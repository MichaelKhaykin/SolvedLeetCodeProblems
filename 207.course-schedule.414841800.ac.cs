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
    
    
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
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

            bool res = IsCylic(allNodes);

            return !res;
        }
}
