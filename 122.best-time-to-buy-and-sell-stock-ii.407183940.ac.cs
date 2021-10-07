public class Solution {
    public int MaxProfit(int[] x) {
          if (x.Length == 0) return 0;

            var prices = x.ToList();
            int maxProfit = 0;

            int lowPoint;
            int highPoint;
            for (int i = 0; i < prices.Count - 1; i++)
            {
                while(i < prices.Count - 1 && prices[i] > prices[i + 1])
                {
                    i++;
                }
                lowPoint = prices[i];
                while(i < prices.Count - 1 && prices[i] < prices[i + 1])
                {
                    i++;
                }
                highPoint = prices[i];

                maxProfit += highPoint - lowPoint;
            }

            return maxProfit;    
    }
}
