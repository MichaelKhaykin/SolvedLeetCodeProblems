public class NumArray {

    public int[] sum;
    public NumArray(int[] nums) {
        sum = new int[nums.Length + 1];
        for(int i = 0; i < nums.Length; i++)
        {
            sum[i + 1] = sum[i] + nums[i];
        }
    }
    
    public int SumRange(int i, int j) {
        return sum[j + 1] - sum[i];
    }
}

/**
 * Your NumArray object will be instantiated and called as such:
 * NumArray obj = new NumArray(nums);
 * int param_1 = obj.SumRange(i,j);
 */
