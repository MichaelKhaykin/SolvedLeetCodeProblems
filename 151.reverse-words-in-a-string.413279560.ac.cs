public class Solution {
    public string ReverseWords(string s) {
        
        s = s.Trim();
        
        List<string> words = new List<string>();
        string current = "";
        foreach(var letter in s)
        {
            if(letter == ' ') 
            {
                if(current != "")
                {
                    words.Add(current);
                }
                current = "";
                continue;
            }
            
            current += letter;
        }
        words.Add(current);
        
        words.Reverse();
        
        StringBuilder x = new StringBuilder();
        foreach(var item in words)
        {
            x.Append(item);
            x.Append(' ');
        }
        x.Remove(x.Length - 1, 1);
        return x.ToString();
    }
}
