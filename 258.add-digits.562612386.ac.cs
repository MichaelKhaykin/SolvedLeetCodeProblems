public class Solution {
    public int AddDigits(int num) {
        
        if(num < 10) return num;
        
        int sum = 0;
        do
        {
            int digit = num % 10;
            num /= 10;
            sum += digit;
            
        }while(num != 0);
        
        return AddDigits(sum);
    }
}
