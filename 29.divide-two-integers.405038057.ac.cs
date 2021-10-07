public class Solution {
    public int Divide(int dividend, int divisor) {
        
        if(divisor == -1 && dividend == -2147483648) 
        {
            return (int)(Math.Pow(2, 31) - 1);
        }
        
        return dividend / divisor;
    }
}
