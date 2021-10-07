public class Solution {
   
    public bool Helper(string s, HashSet<string> dict, int start, bool?[] memo)
    {
        if(start == s.Length)
        {
            memo[start - 1] = true;
            return true;
        }
        
        if(memo[start] != null)
            return (bool)memo[start];
        
        string x = "";
        for(int i = start; i < s.Length; i++)
        {
            x += s[i];
            if(dict.Contains(x) && Helper(s, dict, i + 1, memo))
            {
                memo[start] = true;
                return true;
            }
        }
        
        memo[start] = false;
        return false;
    }
    
    public bool WordBreak(string s, IList<string> wordDict) {
        HashSet<string> set = new HashSet<string>(wordDict);
        
        bool?[] memo = new bool?[s.Length];
        return Helper(s, set, 0, memo);
    }
}
