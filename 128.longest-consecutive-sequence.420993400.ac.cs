public class Solution {
    public int LongestConsecutive(int[] nums) {
        
        HashSet<int> set = new HashSet<int>(nums);
        
        int longestStreak = 0;
        foreach(var number in nums)
        {
            if(set.Contains(number - 1)) continue;
            
            int currentStreak = 1;
            int currentNumber = number;
            
            while(set.Contains(currentNumber + 1))
            {
                currentNumber++;
                currentStreak++;
            }
            
            longestStreak = Math.Max(longestStreak, currentStreak);
        }
        
        return longestStreak;
    }
}
