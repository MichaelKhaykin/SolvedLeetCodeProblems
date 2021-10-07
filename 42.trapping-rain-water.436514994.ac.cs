public class Solution {
    public int Trap(int[] height) {
        
        int current = 0;
        Stack<int> towers = new Stack<int>();
        int ans =0 ;
        
        while(current < height.Length)
        {
            while(towers.Count > 0 && height[current] > height[towers.Peek()])
            {
                var top = towers.Pop();
                
                if(towers.Count == 0) break;
                
                var dist = current - towers.Peek() - 1;
                var bounded_height = Math.Min(height[current], height[towers.Peek()]) - height[top];
            
                ans += bounded_height * dist;
            }
            towers.Push(current);
            current++;
        }
        
        return ans;
    }
}
