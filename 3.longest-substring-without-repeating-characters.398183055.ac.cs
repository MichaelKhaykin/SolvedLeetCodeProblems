public class Solution {
    public int LengthOfLongestSubstring(string s) {
        HashSet<char> hashset = new HashSet<char>();
        
        int ans = 0;
        int min = 0;
        int max = 0;
        while(min < s.Length && max < s.Length)
        {
            if(!hashset.Contains(s[max]))
            {
                hashset.Add(s[max]);
                max++;
                ans = Math.Max(ans, max - min);
            }
            else
            {
                hashset.Remove(s[min]);
                min++;
            }
        }
        
        return ans;
    }
}
