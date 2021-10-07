public class Solution {
    
    public int[][] MatrixBlockSum(int[][] mat, int k) {
        int[][] ans = new int[mat.Length][];
        
        for(int i = 0; i < ans.Length; i++)
        {
            ans[i] = new int[mat[i].Length];
            for(int j = 0; j < ans[i].Length; j++)
            {
                for(int r = i - k; r <= i + k; r++)
                {
                    for(int c = j - k; c <= j + k; c++)
                    {
                        if(r >= 0 && c >= 0 && r < mat.Length && c < mat[i].Length)
                        {
                            ans[i][j] += mat[r][c];
                        }
                        
                    }
                }
            }
        }
        
        return ans;
    }
}
