public class Solution {
    public int MinSteps(string s, string t)
        {
            Dictionary<char, int> sDict = new Dictionary<char, int>();
            Dictionary<char, int> tDict = new Dictionary<char, int>();

            foreach (var item in s)
            {
                if (sDict.ContainsKey(item))
                {
                    sDict[item]++;
                }
                else
                {
                    sDict.Add(item, 1);
                }
            }

            foreach (var item in t)
            {
                if (tDict.ContainsKey(item))
                {
                    tDict[item]++;
                }
                else
                {
                    tDict.Add(item, 1);
                }
            }

            bool doesGoIn = false;
            int global = 0;
            int len = s.Length;
        
            HashSet<char> seen = new HashSet<char>();
        
            do
            {
                doesGoIn = false;
                for(int i = 0; i < len; i++)
                {
                    if(!sDict.ContainsKey(s[i]) || !tDict.ContainsKey(s[i])) continue;
                    if(seen.Contains(s[i])) continue;
                    
                    doesGoIn = true;
                    
                    global += Math.Min(sDict[s[i]], tDict[s[i]]);
                    
                    seen.Add(s[i]);
                }
                
            } while (doesGoIn);
        
            return len - global;
        }
}
