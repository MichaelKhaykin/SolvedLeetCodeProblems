public class Solution {
    public int[] TwoSum(int[] numbers, int target) {
        int a = 0;
        int b = numbers.Length - 1;
        
        while(a <= b)
        { 
            if(numbers[a] + numbers[b] == target)
            {
                return new int[] { a + 1, b + 1};
            }
            
           if (numbers[a] + numbers[b] > target)
                {
                    b--;
                }
                else 
                {
                    a++;
                }
        }
        
        return null;
    }
}
