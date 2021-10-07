public class Solution {
    public string BreakPalindrome(string palindrome) {
        
        if(palindrome.Length == 1) return "";
        
        int indOfNonA = -1;
        for(int i = 0; i < palindrome.Length; i++)
        {
            if(palindrome[i] != 'a')
            {
                indOfNonA = i;
                break;
            }
        }
        
        StringBuilder b = new StringBuilder(palindrome);
        
        if(indOfNonA == -1)
        {
            b.Remove(palindrome.Length - 1, 1);
            b.Append('b');
            return b.ToString();
        }
        
        StringBuilder l = new StringBuilder(palindrome);
        l.Remove(indOfNonA, 1);
        l.Insert(indOfNonA, 'a');
        
        if(indOfNonA == -1 || IsPalindrome(l.ToString()))
        {
            b.Remove(palindrome.Length - 1, 1);
            b.Append('b');
            return b.ToString();
        }
    
        return l.ToString();
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
