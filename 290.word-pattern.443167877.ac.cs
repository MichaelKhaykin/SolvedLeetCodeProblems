public class Solution {
    public bool WordPattern(string pattern, string s) {
        
        var split = s.Split(' ');
        
        if(split.Length != pattern.Length) return false;
        
        Dictionary<char, string> l = new Dictionary<char, string>();
        Dictionary<string, char> r = new Dictionary<string, char>();
        
        for(int i = 0; i < pattern.Length; i++)
        {
            if(l.ContainsKey(pattern[i]) == false)
            {
                l.Add(pattern[i], split[i]);
                
                if(r.ContainsKey(split[i]) == true) return false;
                r.Add(split[i], pattern[i]);
                
                continue;
            }
            else
            {
                if(split[i] != l[pattern[i]]) return false;
            }
        }
        
        return true;
    }
}
