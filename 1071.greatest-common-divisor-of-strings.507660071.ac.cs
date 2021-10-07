public class Solution {
    public string GcdOfStrings(string str1, string str2) {
        
        var shorterStr = str1.Length < str2.Length ? str1 : str2;
        
        string append = "";
        
        string best = "";
        
        for(int i = 0; i < shorterStr.Length; i++)
        {
            if(Divides(str1, append) && Divides(str2, append))
            {
                best = append;
            }
            
            append += shorterStr[i];
        }
        
        if(Divides(str1, append) && Divides(str2, append))
        {
            best = append;
        }
        
        return best;
    }
    
    public bool Divides(string s, string t)
    {
        if(t == "") return true;
        
        int index = 0;
        
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] != t[index]) return false;
            index++;
            index %= t.Length;
        }
        
        return index == 0;
    }
}
