public class Solution
    {
        public class GraphNode<T>
        {
            public T val;
            public int Group { get; set; }
            public List<GraphNode<T>> edges = new List<GraphNode<T>>();
            public GraphNode(T val, int group)
            {
                this.val = val;
                this.Group = group;
            }
        }
        public bool IsCylic<T>(List<GraphNode<T>> verticies)
        {
            int[] state = new int[verticies.Count];
            Dictionary<GraphNode<T>, int> map = new Dictionary<GraphNode<T>, int>();

            for (int i = 0; i < verticies.Count; i++)
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

            static bool Helper(GraphNode<T> vertex, int[] state, Dictionary<GraphNode<T>, int> map)
            {
                if (state[map[vertex]] == 2) return true;

                state[map[vertex]] = 2;

                foreach (var item in vertex.edges)
                {
                    if (state[map[item]] == 1) continue;

                    if (Helper(item, state, map))
                    {
                        return true;
                    }
                }

                state[map[vertex]] = 1;
                return false;
            }
        }

        public List<GraphNode<T>> TopologicalSort<T>(List<GraphNode<T>> allNodes)
        {
            Stack<GraphNode<T>> result = new Stack<GraphNode<T>>();
            HashSet<GraphNode<T>> visited = new HashSet<GraphNode<T>>();

            foreach (var item in allNodes)
            {
                if (visited.Contains(item)) continue;

                TopologicalSortHelper(item, result, visited);
            }


            List<GraphNode<T>> final = new List<GraphNode<T>>();
            while (result.Count > 0)
            {
                final.Add(result.Pop());
            }

            return final;


            static void TopologicalSortHelper(GraphNode<T> current, Stack<GraphNode<T>> result, HashSet<GraphNode<T>> visited)
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


        public int[] SortItems(int n, int m, int[] group, IList<IList<int>> beforeItems)
        {
            //seperate all negative ones into seperate groups
            int neg = -1;
            for(int i = 0; i < group.Length; i++)
            {
                if(group[i] == -1)
                {
                    group[i] = neg;
                    neg -= 1;
                }
            }

            Dictionary<int, GraphNode<int>> nodes = new Dictionary<int, GraphNode<int>>();
            Dictionary<int, HashSet<int>> groups = new Dictionary<int, HashSet<int>>();

            //gen all nodes
            for (int i = 0; i < n; i++)
            {
                if (!groups.ContainsKey(group[i]))
                {
                    groups.Add(group[i], new HashSet<int>() { i });
                }
                else
                {
                    groups[group[i]].Add(i);
                }
                
                
                if (!nodes.ContainsKey(i))
                {
                    nodes.Add(i, new GraphNode<int>(i, group[i]));
                }
                if (beforeItems[i].Count == 0) continue;

                foreach (var val in beforeItems[i])
                {
                    if (!nodes.ContainsKey(val))
                    {
                        nodes.Add(val, new GraphNode<int>(val, group[val]));
                    }
                    nodes[val].edges.Add(nodes[i]);
                }
            }
           

            var nodesList = nodes.Select((kvp) => kvp.Value).ToList();

            if (IsCylic(nodesList)) return new int[] { };

            Dictionary<int, List<GraphNode<int>>> sortedGroups = new Dictionary<int, List<GraphNode<int>>>();
            foreach (var kvp in groups)
            {
                List<GraphNode<int>> sortme = new List<GraphNode<int>>();
                if (kvp.Key == -1)
                {
                    foreach (var item in kvp.Value)
                    {
                        sortedGroups.Add(group[item], new List<GraphNode<int>>() { new GraphNode<int>(item, group[item]) });
                    }
                    continue;
                }

                Dictionary<int, GraphNode<int>> newrefs = new Dictionary<int, GraphNode<int>>();
                foreach (var item in kvp.Value)
                {
                    if (!newrefs.ContainsKey(item))
                    {
                        newrefs.Add(item, new GraphNode<int>(item, kvp.Key));
                    }

                    var og = nodes[item];
                    GraphNode<int> newNode = newrefs[item];

                    foreach (var edge in og.edges)
                    {
                        if (kvp.Key != edge.Group) continue;

                        if (!newrefs.ContainsKey(edge.val))
                        {
                            newrefs.Add(edge.val, new GraphNode<int>(edge.val, edge.Group));
                        }
                        newNode.edges.Add(newrefs[edge.val]);
                    }

                    sortme.Add(newNode);
                }

                sortedGroups.Add(kvp.Key, TopologicalSort(sortme));
            }


            Dictionary<int, GraphNode<List<int>>> xd = new Dictionary<int, GraphNode<List<int>>>();

            foreach (var list in sortedGroups)
            {
                foreach (var item in list.Value)
                {
                    var node = nodes[item.val];
                    foreach (var edge in node.edges)
                    {
                        if (edge.Group != node.Group)
                        {
                            if (!xd.ContainsKey(node.Group))
                            {
                                xd.Add(node.Group, new GraphNode<List<int>>(list.Value.Select((x) => x.val).ToList(), node.Group));
                            }
                            if (!xd.ContainsKey(edge.Group))
                            {
                                xd.Add(edge.Group, new GraphNode<List<int>>(sortedGroups[edge.Group].Select((x) => x.val).ToList(), edge.Group));
                            }
                            xd[node.Group].edges.Add(xd[edge.Group]);
                        }
                    }

                    if (!xd.ContainsKey(node.Group))
                    {
                        xd.Add(node.Group, new GraphNode<List<int>>(list.Value.Select((x) => x.val).ToList(), node.Group));
                    }
                }
            }

            var finallist = xd.Select((kvp) => kvp.Value).ToList();
            var sorted = TopologicalSort(finallist);

            if(IsCylic(finallist)) return new int[] { };
          
            
            var together = new List<int>();
            foreach(var item in sorted)
            {
                together.AddRange(item.val);
            }

            return together.ToArray();
        }
    }


