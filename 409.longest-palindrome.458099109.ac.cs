public class Solution {
    
    public int LongestPalindrome(String s) {
        int[] count = new int[128];
        foreach(var character in s)
            count[character]++;

        int ans = 0;
        foreach(var v in count) {
            ans += v / 2 * 2;
            if (ans % 2 == 0 && v % 2 == 1)
                ans++;
        }
        return ans;
    }
}
