public class Solution {
    
    public int MinCost(string s, int[] cost)
        {
            List<List<(char, int)>> groups = new List<List<(char, int)>>();
            for(int i = 0; i < s.Length; i++)
            {
                List<(char, int)> group = new List<(char, int)>();
                group.Add((s[i], cost[i]));

                int final = 0;
                for(int j = i + 1; j < s.Length && s[i] == s[j]; j++)
                {
                    group.Add((s[j], cost[j]));
                    final++;
                }

                groups.Add(group);
                i += final;
            }

            var comparison = new Comparison<(char, int)>((a, b) => a.Item2.CompareTo(b.Item2));
            var comparer = Comparer<(char, int)>.Create(comparison);

            int total = 0;
            for (int i = 0; i < groups.Count; i++)
            {
                groups[i].Sort(comparer);

                total += groups[i].Sum((kvp) => kvp.Item2) - groups[i][groups[i].Count - 1].Item2;
            }

            return total;
        }
}
