public class Solution
{
        Dictionary<(int, int), int> memo = new Dictionary<(int, int), int>();

        public int DFS(int[][] graph, int i, int j)
        {
            if(memo.ContainsKey((i, j))) return memo[(i, j)];
            
            var curritem = graph[i][j];

            var l = 0;
            var r = 0;
            var u = 0;
            var d = 0;
            if (i - 1 >= 0 && graph[i - 1][j] > curritem)
            {
                u = DFS(graph, i - 1, j) + 1;
            }
            if (j - 1 >= 0 && graph[i][j - 1] > curritem)
            {
                l = DFS(graph, i, j - 1) + 1;
            }
            if (i + 1 < graph.Length && graph[i + 1][j] > curritem)
            {
                d = DFS(graph, i + 1, j) + 1;
            }
            if (j + 1 < graph[i].Length && graph[i][j + 1] > curritem)
            {
                r = DFS(graph, i, j + 1) + 1;
            }

            var max = Math.Max(Math.Max(u, d), Math.Max(l, r));
            if (memo.ContainsKey((i, j)))
            {
                memo[(i, j)] = Math.Max(memo[(i, j)], max);
            }
            else
            {
                memo[(i, j)] = max;
            }
            return max;
        }

        public int LongestIncreasingPath(int[][] matrix)
        {
            int maxSeqLeng = 0;
            memo.Clear();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    maxSeqLeng = Math.Max(DFS(matrix, i, j) + 1, maxSeqLeng);
                }
            }

            return maxSeqLeng;
        }
}
