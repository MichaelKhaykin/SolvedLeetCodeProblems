public class Solution {
    
    public void Generate(string current, int recursionLevel, int level, List<string> all)
    {
        if(level == recursionLevel)
        {
            all.Add(current);
            
            return;
        }
        
        for(int i = 0; i < 2; i++)
        {
            if(i == 0)
            {
                Generate(current + '(', recursionLevel, level + 1, all);
            }
            else
            {
                Generate(current + ')', recursionLevel, level + 1, all);
            }
        }
    }
    
    public IList<string> GenerateParenthesis(int n) {
        
        Dictionary<char, char> map = new Dictionary<char, char>()
        {
            [')'] = '(',
            [']'] = '[',
            ['}'] = '{'
        };
        
        
        List<string> items = new List<string>();
        Generate("", n*2, 0, items);
        List<string> returnVal = new List<string>();
        foreach(var s in items)
        {
            bool valid = true;
        
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
                        valid = false;
                        break;
                    }
                }
            }

            if(path.Count != 0 || valid == false) continue;
            
            returnVal.Add(s);
        }
        
        return returnVal;
    }
}
