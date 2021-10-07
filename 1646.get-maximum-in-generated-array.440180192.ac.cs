public class Solution {
    public int GetMaximumGenerated(int n) {
        
        if(n < 2)
        {
            return n;
        }
        
        
        int[] nums = new int[n + 1];
        nums[0] = 0;
        nums[1] = 1;
        
        bool addone = false;
        int max = int.MinValue;
        
        int i = 0;
        int step = 1;
        while(i * 2 + 1 <= n)
        {
            var next = nums[i] + (addone ? nums[i + 1] : 0);
            max = Math.Max(max, next);
            nums[2 * i + (addone ? 1 : 0)] = next;
            addone = !addone;
            
            if(step % 2 == 0)
            {
                i++;
            }
            step++;
        }
        
        return max;
    }
}
