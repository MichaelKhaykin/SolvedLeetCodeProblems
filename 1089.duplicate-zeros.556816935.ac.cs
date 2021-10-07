public class Solution {
    public void DuplicateZeros(int[] arr) {
        
        List<int> nums = new List<int>(arr);
        
        for(int i = 0; i < arr.Length; i++)
        {
            nums.Add(0);
        }
        
        int offset = 1;
        for(int i = 0; i < arr.Length; i++)
        {
            if(arr[i] == 0)
            {
                nums.Insert(i + offset, 0);
                offset++;
            }
        }
        
        for(int i = 0; i < arr.Length; i++){
            arr[i] = nums[i];
        }
    }
}
