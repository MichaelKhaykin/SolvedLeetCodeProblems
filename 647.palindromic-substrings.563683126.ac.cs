public class Solution {
    public int CountSubstrings(string s) {
        
        int count = 0;
        
        for(int j = 1; j <= s.Length; j++)
        {
            for(int i = 0; i + j <= s.Length; i += 1)
            {
                if(IsPalindrome(s.Substring(i, j)))
                {
                    count++;
                }
            }   
        }
        return count;
        
    }
    
    public bool IsPalindrome(string s)
    {
        for(int i = 0; i < s.Length / 2; i++)
        {
            if(s[i] != s[s.Length - i - 1]) return false;
        }
        return true;
    }
}
