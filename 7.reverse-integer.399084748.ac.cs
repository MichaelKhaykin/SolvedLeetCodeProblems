public class Solution {
    public int Reverse(int x) {
    
        bool flip = x < 0;
        if(flip)
        {
            x *= -1;
        }
        
        IEnumerable<char> stringy = x.ToString().Reverse();
        string newString = new string(stringy.ToArray());
        string best = flip ? "-" + newString : newString;
        
        if(!int.TryParse(best, out int ans)) return 0;
        
        return ans;
    }
}
