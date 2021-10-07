public class Solution {
    public int MaxProfit(int[] prices) {
        if(prices.Length == 0 || prices.Length == 1) return 0;
       
        int min = 0;
        for(int i = 0; i < prices.Length; i++)
        {
            for(int j = i + 1; j < prices.Length; j++)
            {
                if(prices[i] > prices[j]) continue;
                min = Math.Max(min, prices[j] - prices[i]);
            }
        }
        return min;
    }
}
