public class Solution {
    public int LongestWPI(int[] hours) {
        
        int[] bits = new int[hours.Length];
        for(int i = 0; i < hours.Length; i++)
        {
            bits[i] = hours[i] > 8 ? 1 : -1;
        }
        
        int max = 0;
        int runningSum = 0;
        
        for(int i = 0; i < hours.Length; i++)
        {
            runningSum = bits[i];
            if(runningSum > 0)
            {
                max = Math.Max(max, 1);
            }
            for(int j = i + 1; j < hours.Length; j++)
            {
                runningSum += bits[j];
                
                if(runningSum > 0)
                {
                    max = Math.Max(max, j - i + 1);
                }
            }
            
            
        }
        
        return max;
    }
}
