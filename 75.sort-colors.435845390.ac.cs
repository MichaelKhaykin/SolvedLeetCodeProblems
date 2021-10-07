public class Solution {
    public void SortColors(int[] nums) {
        
        var newArr = nums.OrderBy((x) => x).ToArray();
        for(int i = 0; i < newArr.Length; i++)
        {
            nums[i] = newArr[i];
        }
    }
}
