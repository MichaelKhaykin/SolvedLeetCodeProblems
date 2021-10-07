public class Solution {
    
    public int Dumb(int n, int k)
    {
        if(n == 0)
        {
            return 0;
        }
        
        int prevK = k / 2;
        int modK = k % 2;
        
        int parent = Dumb(n - 1, prevK);
        
        if(parent == 0)
        {
            return modK;
        }
        
        return (modK + 1) % 2;
    }
    
    public int KthGrammar(int N, int K) {
        return Dumb(N - 1, K - 1);
    }
}
