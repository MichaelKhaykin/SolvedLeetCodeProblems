public class Solution {
    public bool IsPalindrome(int x) {
        string v = x.ToString();
        string r = new string(v.Reverse().ToArray());
        
        return v == r;
    }
}
