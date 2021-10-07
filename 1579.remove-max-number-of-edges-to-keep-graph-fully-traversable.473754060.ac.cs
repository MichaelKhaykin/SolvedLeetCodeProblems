  public class Solution
    {
/*
        public class UnionFind
        {
            int[] parents;
            int[] map;
            
            public UnionFind(int n)
            {
                parents = new int[n];
                map = new int[n + 1];
                for (int i = 1; i <= n; i++)
                {
                    parents[i - 1] = i;
                    map[i] = i - 1;
                }
            }

            private int QuickFind(int item)
                => parents[map[item]];

            public bool Union(int a, int b)
            {
                if (AreConnected(a, b)) return false;

                var aParent = QuickFind(a);
                var bParent = QuickFind(b);

                for (int i = 0; i < parents.Length; i++)
                {
                    if (parents[i] == bParent)
                    {
                        parents[i] = aParent;
                    }
                }

                return true;
            }

            public bool IsOneSet()
            {
                HashSet<int> meow = new HashSet<int>(parents);
                return meow.Count == 1;
            }

            public bool AreConnected(int a, int b)
                => QuickFind(a) == QuickFind(b);
        }
        */
      
      public class UnionFind
    {
        private int[] parent; 
        public UnionFind(int n)
        {
            parent = new int[n+1];
            for(int i=1; i<parent.Length; i++)
            {
                parent[i] = i;
            }
        }
        
        public UnionFind(int[] arr)
        {
            parent = arr;
        }
        
       public int[] Duplicate()
       {
           int[] copy = new int[parent.Length];
           for(int i=1; i<parent.Length; i++)
            {
                copy[i] = parent[i];
            }
           return copy;
       }
        
        public int Find(int x)
        {
            if (parent[x] != x) { parent[x] = Find(parent[x]); }
            return parent[x];
        }
        
        public bool Union(int x, int y)
        {
            int px = Find(x);
            int py = Find(y);
            
            if (px == py) { return false; }
            
            parent[py] = px;
            
            return true;
        }
        
        public int ParentCount()
        {
            int count = 0;
            for(int i=1; i < parent.Length; i++)
            {
                if (parent[i] == i) { count++; }
            }
            return count;
        }
          
        public bool IsOneSet() 
            => ParentCount() == 1;
    }

        public int MaxNumEdgesToRemove(int n, int[][] edges)
        {
            UnionFind type1Union = new UnionFind(n);
            UnionFind type2Union = new UnionFind(n);

            List<(int, int)> type1Edges = new List<(int, int)>(n);
            List<(int, int)> type2Edges = new List<(int, int)>(n);

            int totalEdgesOnNewGraph = 0;
            int totalEdgesOriginally = edges.Length;

            for (int i = 0; i < edges.Length; i++)
            {
                var type = edges[i][0];
                var s = edges[i][1];
                var e = edges[i][2];

                if (type == 1)
                {
                    type1Edges.Add((s, e));
                    continue;
                }
                else if (type == 2)
                {
                    type2Edges.Add((s, e));
                    continue;
                }

                if (type1Union.Union(s, e) | type2Union.Union(s, e))
                {
                    totalEdgesOnNewGraph++;
                }
            }

            for (int i = 0; i < type1Edges.Count; i++)
            {
                var current = type1Edges[i];

                if (type1Union.Union(current.Item1, current.Item2))
                {
                    totalEdgesOnNewGraph++;
                }
            }

            for (int i = 0; i < type2Edges.Count; i++)
            {
                var current = type2Edges[i];

                if (type2Union.Union(current.Item1, current.Item2))
                {
                    totalEdgesOnNewGraph++;
                }
            }

            return !type1Union.IsOneSet() || !type2Union.IsOneSet() ? -1 : totalEdgesOriginally - totalEdgesOnNewGraph;
        }
    }
