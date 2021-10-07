public class Solution {
    public int Candy(int[] ratings) {
        
        int[] candies = new int[ratings.Length];
        Array.Fill(candies, 1);
        
        bool anyChanges;
        do
        {
            anyChanges = false;
            for(int i = 0; i < candies.Length; i++)
            {
                 if (i != ratings.Length - 1 && ratings[i] > ratings[i + 1] && candies[i] <= candies[i + 1]) {
                    candies[i] = candies[i + 1] + 1;
                    anyChanges = true;
                }
                if (i > 0 && ratings[i] > ratings[i - 1] && candies[i] <= candies[i - 1]) {
                    candies[i] = candies[i - 1] + 1;
                    anyChanges = true;
                }
            }
            
        }while(anyChanges);
        
        return candies.Sum();
        
    }
}
