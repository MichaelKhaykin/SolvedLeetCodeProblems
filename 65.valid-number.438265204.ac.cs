public class Solution {
    public bool IsNumber(string s) {
        
        if(double.TryParse(s, out double x)) return true;
        
        s = s.Trim();
        
        int eIndex = -1;
        bool seenLetter = false;
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == ' ' && seenLetter) return false;
            
            if(s[i] != ' ') seenLetter = true;
            if(s[i] != 'e' && s[i] >= 'a' && s[i] <= 'z')
            {
                return false;
            }
            if(s[i] == 'e') 
            {
                if (eIndex != -1) return false;
                eIndex = i;
            }
        }
        
        if(eIndex == -1) return false;
        
        var firstString = s.Substring(0, eIndex);
        var secondString = s.Substring(eIndex + 1);
        
        if(secondString.Contains('.')) return false;
        
        return double.TryParse(firstString, out double p) && double.TryParse(secondString, out double y);
    }
}
