public class Solution {
    public string RemoveOuterParentheses(string S) {
        
        int open = 0;
        int close = 0;
        StringBuilder current = new StringBuilder();
        
        StringBuilder final = new StringBuilder();
        
        for(int i = 0; i < S.Length; i++)
        {
            if(S[i] == '(')
            {
                open++;
            }
            else if(S[i] == ')')
            {
                close++;
            }
            current.Append(S[i]);
            
            if(open == close && current.Length != 0)
            {
                final.Append(current.ToString().Substring(1, current.Length - 2));
                
                current.Clear();
                open = 0;
                close = 0;
            }
        }
        
        
        return final.ToString();
    }
}
