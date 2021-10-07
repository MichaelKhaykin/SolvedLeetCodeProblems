public class Solution {
    public int HammingWeight(uint n) {
        int power = 31;
        int amount = 0;
        while(n > 0)
        {
            if((n & 1) << power != 0)
            {
                amount++;
            }
            n >>= 1;
            power--;
        }
        return amount;
    }
}
