public class Solution {
    public int ThirdMax(int[] nums) {
        
        var l = nums.OrderBy((t) => t).ToHashSet().ToList();
        Stack<int> stack = new Stack<int>(l);
        
        if(stack.Count < 3) return stack.Pop();
        
        stack.Pop();
        stack.Pop();
        
        return stack.Pop();
    }
}
