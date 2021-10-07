public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        
        int aMax = -1;
        int bMax = -1;
        int cMax = -1;
        
        for(int i = 0; i < triplets.Length; i++){
            if(triplets[i][0] > target[0]) continue;
            if(triplets[i][1] > target[1]) continue;
            if(triplets[i][2] > target[2]) continue;
            
            aMax = Math.Max(triplets[i][0], aMax);
            bMax = Math.Max(triplets[i][1], bMax);
            cMax = Math.Max(triplets[i][2], cMax);
        }
     
        return aMax == target[0] && bMax == target[1] && cMax == target[2];
    }
}
