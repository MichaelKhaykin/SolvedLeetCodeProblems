public class Solution {
    public int MaxArea(int[] height) {
        int ans = 0;
        int begin = 0;
        int end = height.Length - 1;
        
        while(begin < end)
        {
            ans = Math.Max(ans, Math.Min(height[begin], height[end]) * (end - begin));
            if(height[begin] <= height[end])
            {
                begin++;
            }
            else
            {
                end--;
            }
        }
        return ans;
    }
}
