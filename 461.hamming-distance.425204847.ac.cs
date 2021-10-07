public class Solution {
    public int HammingDistance(int a, int b) {
        
        int mask = 1;
        int dist = 0;
        
        int i = 0;
        while(i < 32)
        {
            int l = a & mask;
            int r = b & mask;
            
            if(l != r)
            {
                dist++;
            }
            
            mask <<= 1;
            i++;
        }
        
        return dist;

    }
}
