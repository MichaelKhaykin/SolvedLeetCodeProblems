public class Solution {
    public int FindIntegers(int num) {
        int[] f = new int[32];
        f[0] = 1;
        f[1] = 2;
        for (int x = 2; x < f.Length; x++)
        {
            f[x] = f[x - 1] + f[x - 2];
        }
        int i = 30, sum = 0, prev_bit = 0;
        while (i >= 0) {
            if ((num & (1 << i)) != 0) {
                sum += f[i];
                if (prev_bit == 1) {
                    return sum;
                    //sum--;
                    //break;
                }
                prev_bit = 1;
            }
            else
            {
                prev_bit = 0;
            }
            i--;
        }
        return sum + 1;
    }
}
