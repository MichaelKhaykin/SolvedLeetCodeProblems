public class Solution {
    public int Jump(int[] nums) {
        
        int len = nums.Length;
        if (len == 0 || len == 1)
            return 0;
        
        int current = 0, to = 0, maxTo = 0, steps = 0;
        
        while (current <= to) {
            steps++;
            while (current <= to) {
                maxTo = Math.Max(maxTo, nums[current] + current);
                if (maxTo >= len-1) return steps;
                current++;
            }
            to = maxTo;
        }
        
        return -1;
    
    }
}
