public class Solution {
    public bool IsAnagram(string s, string t) {
        int[] count = new int[26];
        foreach(var item in s)
        {
            count[item - 'a']++;
        }
        
        foreach(var item in t)
        {
            count[item - 'a']--;
        }
        
        return count.Where((x) => x == 0).Count() == count.Length;
    }
}
