public class Solution {
    
    public int IntegerBreak(int n) {

        var memo = new List<int>();
        for(int i = 0; i <= n+1; i++){
            memo.Add(0);
        }

        if(n <= 2) return 1;
        memo[1] = 0;
        memo[2] = 1;

        for (int i = 3; i<=n; i++){
            for(int j = 1; j < i; j ++){ 
                 memo[i] = Math.Max(memo[i], Math.Max(j*(i-j) , j*memo[i-j]));
            }
        }

        return memo[n];
    }
    
    public int IntegerBreak2(int n) {
        
        if(n == 2) return 1;
        if(n == 3) return 2;
        
        int amountOfThrees = n / 3;
        int amountOfTwos = 0;
        
        int cachedBitch = n % 3;
        
        if(cachedBitch == 1)
        {
            amountOfThrees--;
            amountOfTwos = 2;
        }
        else if(cachedBitch == 2)
        {
            amountOfTwos = 1;
        }
        return (int)Math.Pow(2, amountOfTwos) * (int)Math.Pow(3, amountOfThrees);
    }
}
