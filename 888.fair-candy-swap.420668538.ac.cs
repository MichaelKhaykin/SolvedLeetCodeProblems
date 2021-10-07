public class Solution {
    public int[] FairCandySwap(int[] A, int[] B) {
        
        HashSet<int> candies = new HashSet<int>(B);
        
        int asum = 0;
        for(int i = 0; i < A.Length; i++)
        {
            asum += A[i];
        }
        int bsum = 0;
        for(int i = 0; i < B.Length; i++){
            bsum += B[i];
        }
        
        var lenover2 = (bsum - asum) / 2;
        
        for(int i = 0; i < A.Length; i++)
        {
            var compute = A[i] + lenover2;
            if(candies.Contains(compute))
            {
                return new int[] { A[i], compute };
            }
        }
        
        return null;
    }
}
