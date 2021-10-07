public class Solution {
    public bool AreAlmostEqual(string s1, string s2) {
        
        int countOfDiffChars = 0;
        int index1 = -1;
        int index2 = -1;
        
        for(int i = 0; i < s1.Length; i++)
        {
            if(s1[i] != s2[i]){
                countOfDiffChars++;
                
                if(index1 == -1) index1 = i;
                else if(index2 == -1) index2 = i;
                
                if(countOfDiffChars > 2) return false;
            }
        }
        
        if(countOfDiffChars == 0) return true;
        
        if(countOfDiffChars == 2)
        {
            if(s1[index1] == s2[index2] && s1[index2] == s2[index1]) return true;
            return false;   
        }
        
        return false;
    }
}
