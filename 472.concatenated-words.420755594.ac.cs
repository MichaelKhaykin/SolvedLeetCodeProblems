public class Solution {
    public IList<string> FindAllConcatenatedWordsInADict(string[] words) {
        var result = new List<string>();
        if (words.Length <= 2) return result;

        var wordSet = new HashSet<string>(words);
        foreach (var word in words) {
            if (word == "") continue;

            wordSet.Remove(word);

            var canBreak = WordBreak(word, wordSet);

            if (canBreak) result.Add(word);
            wordSet.Add(word);
        }

        return result;
    }

    private bool WordBreak(string s, HashSet<string> dict) {
        if (s.Length == 0) return false;

        var n = s.Length;
        var dp = new bool[n + 1];
        dp[n] = true;

        for (int i = n - 1; i >= 0; --i) {
            for (int j = i; j < n; ++j) {
                if (dp[j + 1] && dict.Contains(s.Substring(i, j - i + 1))) {
                    dp[i] = true;
                    break;
                }
            }
        }

        return dp[0];
    }
}
