public class Solution {
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        
        Dictionary<string, List<string>> ans = new Dictionary<string, List<string>>();
        
        for(int i = 0; i < strs.Length; i++)
        {
            int[] alpha = new int[26];
            foreach(var character in strs[i]) alpha[character - 'a']++;
            
            StringBuilder builder = new StringBuilder();
            for(int y = 0; y < alpha.Length; y++)
            {
                builder.Append("#");
                builder.Append(alpha[y]);
            }
            
            var key = builder.ToString();
            
            if(ans.ContainsKey(key) == false) ans.Add(key, new List<string>());
            ans[key].Add(strs[i]);
        }
                
        List<IList<string>> answer = new List<IList<string>>();
        answer.AddRange(ans.Values);
        
        return answer;
    }
}
