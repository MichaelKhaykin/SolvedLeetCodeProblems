public class Solution {
    
      private (int, int) Helper(string s, int l, int r)
        {
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
            }
            return (r, l);
        }
    
    public string LongestPalindrome(string s) {
        
        if(s.Length ==0) return "";
        
        int min = 0;
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                (int x, int y) l1 = Helper(s, i, i);
                (int x, int y) l2 = Helper(s, i, i + 1);

                int l1Diff = l1.x - l1.y - 1;
                int l2Diff = l2.x - l2.y - 1;

                if (l1Diff > l2Diff && l1Diff > max - min)
                {
                    max = l1.x - 1;
                    min = l1.y + 1;
                }
                else if (l1Diff < l2Diff && l2Diff > max - min)
                {
                    max = l2.x - 1;
                    min = l2.y + 1;
                }
            }

            string sub = "";
            for (int i = min; i <= max; i++)
            {
                sub += s[i];
            }

            return sub;
    }
}
