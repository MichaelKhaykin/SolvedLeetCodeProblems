public class Solution {
    
    public int[] PlusOne(int[] digits) {
    
        int carry = 1;
        
        for(int i = digits.Length - 1; i >= 0; i--)
        {
            if(digits[i] + carry < 10)
            {
                digits[i] += carry;
                return digits;
            }
            else
            {
                var newNum = digits[i] + carry;
                
                digits[i] = newNum % 10;
                carry = newNum / 10;
            }
        }
        
        if(carry != 0)
        {
            int[] copy = new int[digits.Length + 1];
            
            copy[0] = carry;
            
            Array.Copy(digits, 0, copy, 1, digits.Length);
          
            return copy;
        }
        else
        {
            return digits;
        }
    }
}
