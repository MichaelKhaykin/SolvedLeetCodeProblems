public class Solution {
    
    public bool IsPrime(int n)
    {
        for(int i = 2; i * i <= n; i++)
        {
            if(n % i == 0) return false;
        }
        return true;
    }
    
    public int CountPrimes(int n) {
        int countOfPrimes = 0;
        for(int i = 2; i < n; i++)
        {
            countOfPrimes += IsPrime(i) ? 1 : 0;
        }
        return countOfPrimes;
    }
}
