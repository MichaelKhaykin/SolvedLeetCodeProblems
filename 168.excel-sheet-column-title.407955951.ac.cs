public class Solution {
  
    public string ConvertToTitle(int n) {
        string appendTo = "";
        
        while(n > 0)
        {
            n--;
            appendTo += (char)((n % 26) + 65);
            n /= 26;
        }
        
        return new string(appendTo.Reverse().ToArray());
    }
}
