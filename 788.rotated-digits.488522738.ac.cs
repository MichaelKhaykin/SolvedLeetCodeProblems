public class Solution {
    public int RotatedDigits(int N) {
        
        int count = 0;    
        for(int i = 2; i <= N; i++)
        {
            if(IsGood(i))
            {
                count++;
            }
        }
        return count;
    }
    
    public bool IsGood(int n)
    {
        bool good = false;
        while(n > 0)
        {
            int digit = n % 10;
            if(digit == 3 || digit == 4 || digit == 7)
            {
                return false;
            }
            
            if(digit == 2 || digit == 5 || digit == 6 || digit == 9)
            {
                good = true;
            }
            n /= 10;
        }
        return good;
    }
}
