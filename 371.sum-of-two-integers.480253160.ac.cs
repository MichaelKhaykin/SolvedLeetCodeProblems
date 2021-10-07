public class Solution {
     public int GetSum(int a, int b)
        {
         return a + b;

            int carry = 0;
            int final = 0;

            for (int i = 0; i < 32; i++)
            {
                int mask = (1 << i);
                var abit = (a & mask) == 0 ? 0 : 1;
                var bbit = (b & mask) == 0 ? 0 : 1;

                var sum = abit + bbit;
                if (sum == 0)
                {
                    final += carry == 0 ? 0 : 1 << i;
                    carry = 0;
                }
                else if (sum == 1 && carry == 0)
                {
                    final += 1 << i;
                }
                else if (sum == 2)
                {
                    final += carry == 0 ? 0 : 1 << i;
                    if (carry == 0)
                    {
                        carry = 1;
                    }
                }
            }

            return final;
        }
}
