public class Solution {
    public string MakeGood(string s) {
        bool change = false;
        
        do
        {
            change = false;
            StringBuilder x = new StringBuilder();
            
            for(int i = 0; i < s.Length; i++)
            {
                if(i + 1 < s.Length && s[i] == s[i + 1] + 32)
                {
                    change = true;
                    i++;
                    continue;
                }
                else if(i + 1 < s.Length && s[i] == s[i + 1] - 32)
                {
                    change = true;
                    i++;
                    continue;
                }
                
                x.Append(s[i]);
            }
            
            s = x.ToString();
            
        }while(change);
        
        return s;
    }
}
