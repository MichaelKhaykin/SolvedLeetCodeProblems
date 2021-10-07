public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        
        if(strs.Length == 0) return "";
        if(strs[0].Length == 0) return "";
        
        string longestPrefix = "";
        
        char charToAdd = strs[0][0];
        int currentIndex = 0;
        
        bool shouldLoop = true;
        while(shouldLoop)
        {
            bool allMatch = true;
            
            if(currentIndex >= strs[0].Length) break;
            
            for(int i = 1; i < strs.Length; i++)
            {
                if(currentIndex >= strs[i].Length) 
                {
                    shouldLoop = false;
                    allMatch = false;
                    break;
                }
                
                if(strs[i][currentIndex] != strs[0][currentIndex])
                {
                    allMatch = false;
                    break;
                }
            }
            
            if(!allMatch) break;
            
            longestPrefix += strs[0][currentIndex];
            
            currentIndex++;
        }
        
        return longestPrefix;
    }
}
