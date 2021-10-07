public class Solution {
    public int FindLength(int[] A, int[] B)
    {
        int[,] dp = new int[A.Length, B.Length];
        int max = 0;

        for (int i = 0; i < A.Length; i++)
        {
            dp[i, 0] = A[0] == B[i] ? 1 : 0;
            max = Math.Max(dp[i, 0], max);
        }
        for (int i = 0; i < B.Length; i++)
        {
            dp[0, i] = B[0] == A[i] ? 1 : 0;
            max = Math.Max(dp[0, i], max);
        }

        /*
        for(int i = 0; i < dp.GetLength(0); i++)
        {
            for(int j = 0; j < dp.GetLength(1); j++)
            {
                Console.Write($"{dp[i, j]} ");
            }
            Console.WriteLine();
        }
        */

        for (int i = 1; i < A.Length; i++)
        {
            for (int j = 1; j < B.Length; j++)
            {
                if (A[j] == B[i])
                {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                    max = Math.Max(max, dp[i, j]);
                }
            }
        }

        return max;
    }
}
