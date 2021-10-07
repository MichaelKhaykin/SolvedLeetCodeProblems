public class Solution {
    public bool CanConstruct(string ransomNote, string magazine) {
        
        int[] n = new int[26];
        foreach(var character in ransomNote)
        {
            n[character - 'a']++;
        }
        
        foreach(var character in magazine)
        {
            n[character - 'a']--;
        }
        
        for(int i = 0; i < n.Length; i++)
        {
            if(n[i] > 0) return false;
        }
        return true;
    }
}
