public class Solution {
    public int Maximum69Number(int num)
    {
        checked
        {

            int n = num;
            int? first6 = null;
            int pos = 0;
            while (n != 0)
            {
                int digit = n % 10;
                n /= 10;
                if (digit == 6)
                {
                    first6 = pos;
                }

                pos++;
            }

            if (!first6.HasValue)
            {
                return num;
            }

            int pow = (int) Math.Pow(10, first6.Value);
            return num - 6 * pow + 9 * pow;
        }
    }
}
