public class Solution {
    public bool IsIsomorphic(string s, string t) {
        if(s.Length != t.Length) return false;
        
        Dictionary<char, char> mapped = new Dictionary<char, char>();
        for(int i = 0; i < s.Length; i++)
        {
            if(mapped.ContainsKey(s[i]))
            {
                if(mapped[s[i]] != t[i]) return false;
            }
            else
            {
                mapped.Add(s[i], t[i]);
            }
        }
        
        mapped = new Dictionary<char, char>();
        for(int i = 0; i < t.Length; i++)
        {
            if(mapped.ContainsKey(t[i]))
            {
                if(mapped[t[i]] != s[i]) return false;
            }
            else
            {
                mapped.Add(t[i], s[i]);
            }
        }
        
        return true;
    }
}
