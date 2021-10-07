public class Solution {
    public List<String> FindRepeatedDnaSequences(string s)
        {

            if (s.Length < 10) return new List<string>();

            int len = s.Length;
            HashSet<long> hashes = new HashSet<long>();
            HashSet<string> result = new HashSet<string>();

            Dictionary<char, int> map = new Dictionary<char, int>()
            {
                ['A'] = 1,
                ['C'] = 2,
                ['G'] = 3,
                ['T'] = 4
            };

            long hash = 0;
            for (int i = 9; i >= 0; i--)
            {
                hash = hash + map[s[i]] * ((long)Math.Pow(4, 9 - i));
            }
            hashes.Add(hash);

            for (int i = 1; i < len - 9; i++)
            {
                long newHash = hash - map[s[i - 1]] * ((long)Math.Pow(4, 9));
                newHash = newHash * 4;
                newHash = newHash + map[s[i + 9]];
                if (hashes.Contains(newHash))
                {
                    result.Add(s.Substring(i, 10));
                }
                hashes.Add(newHash);
                hash = newHash;
            }

            return result.ToList();
        }
}
