public class Solution {
    
    
    public int[] SumZero(int n) {
        int[] gen = new int[n];
        
        int max = 1000;
        
        int len = n % 2 == 0 ? n : n - 1;
        
        for(int i = 0; i < len; i += 2)
        {
            gen[i] = max;
            gen[i + 1] = -max;
            
            max--;    
        }
        
        if(len != n)
        {
            gen[len] = 0;
        }
        
        return gen;
    }
}
