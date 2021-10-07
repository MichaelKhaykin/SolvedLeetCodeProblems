public class Solution {
    
    public int RemovePalindromeSub(string s)
    {
        if(s == "") return 0;
        if(IsPalindrome(s)) return 1;
        
        return 2;
    }
    
    bool IsPalindrome(string word)
    {
        for(int i = 0; i < word.Length / 2; i++)
        {
            if(word[i] != word[word.Length - 1 - i]) return false;
        }
        return true;
    }
}
