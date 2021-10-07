public class Solution {
    public int[] NextGreaterElements(int[] nums) {
        
        int[] output = new int[nums.Length];
        Stack<int> stack = new Stack<int>();
        
        for(int i = nums.Length * 2 - 1; i >= 0; i--)
        {
            while(stack.Count > 0 && nums[i % nums.Length] >= nums[stack.Peek()])
            {
                stack.Pop();
            }
            
            output[i % nums.Length] = stack.Count > 0 ? nums[stack.Peek()] : -1;
            stack.Push(i % nums.Length);
        }
        
        return output;
    }
}
