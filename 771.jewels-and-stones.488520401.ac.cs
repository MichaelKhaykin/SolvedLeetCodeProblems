public class Solution {
    public int NumJewelsInStones(string jewels, string stones) {
     
        HashSet<char> meow = new HashSet<char>(jewels.ToCharArray());
        
        int count = 0;
        foreach(var item in stones)
        {
            if(meow.Contains(item))
            {
                count++;
            }
        }
        return count;
    }
}
