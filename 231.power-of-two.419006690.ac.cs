public class Solution {
    
    public bool IsPowerOfTwo(int n) {
        if(n == 0) return false;
        if(n == int.MinValue) return false;
        
        int k = n;
        k -= 1;
        return (k & n) == 0;
    }
}
