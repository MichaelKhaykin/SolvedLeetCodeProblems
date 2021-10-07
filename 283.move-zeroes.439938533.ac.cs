public class Solution {
    public void MoveZeroes(int[] nums) {
        
        int firstIndex = 0;
        int relativeIndex = 0;
        int secondIndex = nums.Length - 1;
        
        int[] newNums = new int[nums.Length];
        Array.Fill(newNums, int.MaxValue);
        
        while(true)
        {
            if(firstIndex >= nums.Length || relativeIndex >= nums.Length) break;
            
            if(nums[firstIndex] == 0)
            {
                newNums[secondIndex] = 0;
                secondIndex--;
                firstIndex++;
            }
            else
            {
                newNums[relativeIndex] = nums[firstIndex];
                relativeIndex++;
                firstIndex++;
            }
        }
        
        for(int i = 0; i < newNums.Length; i++)
        {
            nums[i] = newNums[i];
        }
    }
}
