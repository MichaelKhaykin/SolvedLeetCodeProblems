public class Solution {
    public bool IsValid(string s) {
        
        if(s.Length == 0) return true;
        if(s.Length == 1) return false;
        
        
        Dictionary<char, char> map = new Dictionary<char, char>()
        {
            [')'] = '(',
            [']'] = '[',
            ['}'] = '{'
        };
        
        
        Stack<char> path = new Stack<char>();
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == '(' || s[i] == '{' || s[i] == '[')
            {
                path.Push(s[i]);
            }
            else
            {
                if(path.Count == 0 || map[s[i]] != path.Pop())
                {
                    return false;
                }
            }
        }
        return path.Count == 0;
    }
}
