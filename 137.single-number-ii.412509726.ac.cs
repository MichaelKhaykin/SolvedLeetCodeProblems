public class Solution {
    public int SingleNumber(int[] nums) {
        return nums.GroupBy((t) => t).Where((t) => t.Count() == 1).Select((t) => t.Key).First();
       
    }
}
