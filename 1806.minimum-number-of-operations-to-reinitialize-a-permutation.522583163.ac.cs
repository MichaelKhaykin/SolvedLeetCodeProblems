public class Solution {
    public int ReinitializePermutation(int n) {
     
        int[] perm = new int[n];
        for(int i = 0; i < n; i++){
            perm[i] = i;
        }
        
        int[] copy = new int[n];
        Array.Copy(perm, copy, copy.Length);
        
        int count = 1;
        while(!DoStuff(ref perm, copy)){
            count++;
        }
        return count;
    }
    
    bool DoStuff(ref int[] perm, int[] og){
        
        int[] newArr = new int[perm.Length];
        int hits = 0;
        
        for(int i = 0; i < perm.Length; i++)
        {
            if(i % 2 == 0)
            {
                newArr[i] = perm[i / 2];        
            }
            else
            {
                newArr[i] = perm[perm.Length / 2 + (i - 1) / 2];
            }

                
            if(newArr[i] == og[i])
            {
                hits++;
            }
        }
        
        perm = newArr;
        
        return hits == perm.Length;
    }
}
