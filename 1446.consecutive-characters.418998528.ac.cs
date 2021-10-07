public class Solution {
    public int MaxPower(string s) {
        
        int total = -1;
        for(int i = 0; i < s.Length; i++)
        {
            int temp = 1;
            while(i + 1 < s.Length && s[i] == s[i + 1])
            {
                temp++;
                i++;
            }
            
            total = Math.Max(total, temp);
        }
        
        return total;
    }
}
