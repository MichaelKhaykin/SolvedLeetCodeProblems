public class Solution {
    
    public int LengthLongestPath(string input) {
        var split = input.Split('\n');
        
        int currentlen = 0;
        int maxlen = 0;
        Stack<string> x = new Stack<string>();
        
        foreach(var item in split)
        {
            var lastT = item.LastIndexOf('\t') + 1;
           
            var name = "";
            if(lastT > 1)
            {
                name = item.Substring(lastT - 1);
            }
            else
            {
                name = item;
            }
            
            while(lastT < x.Count)
            {
                currentlen -= x.Pop().Length;
            }
            
            x.Push(name);
            currentlen += name.Length;
            
            if(item.Contains('.'))
            {
                maxlen = Math.Max(maxlen, currentlen);
            }
        }
        
        return maxlen;
    }
}
