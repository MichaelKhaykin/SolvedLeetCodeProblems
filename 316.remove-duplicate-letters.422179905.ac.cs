public class Solution {
    
    
    public string RemoveDuplicateLetters(string s) {
        
        var alpha = new int[26];

        foreach (var c in s) {
            alpha[c - 'a']++;
        }

        
        HashSet<char> vis = new HashSet<char>();
        Stack<char> stack = new Stack<char>();
        
        foreach(var c in s)
        {
            if(!vis.Contains(c)) 
            {
                while(stack.Count > 0)
                {
                    var peek = stack.Peek();

                    if(peek > c && alpha[peek - 'a'] > 0)
                    {
                        var l = stack.Pop();
                        vis.Remove(l);
                    }
                    else
                    {
                        break;
                    }
                }
                
                vis.Add(c);
                stack.Push(c);
            }
            
            alpha[c - 'a']--;
        }
        
        var result = new List<char>();

        while (stack.Count > 0) {
            result.Add(stack.Pop());
        }

        result.Reverse();

        return string.Join("", result);
    }
}
