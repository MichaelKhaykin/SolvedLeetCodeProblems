public class Solution {
    public void SetZeroes(int[][] matrix) {
        
        if(matrix.Length == 0) return;
        
        HashSet<(int, int)> realZereos = new HashSet<(int, int)>();
        for(int i = 0; i < matrix.Length; i++)
        {
            for(int j = 0; j < matrix[i].Length; j++)
            {
                if(matrix[i][j] == 0)
                {
                    realZereos.Add((i, j));
                }
            }
        }
        
        
        var height = matrix.GetLength(0);
        var width = matrix[0].Length;
        
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                if(realZereos.Contains((i, j)))
                {
                    for(int m = 0; m < matrix.Length; m++)
                    {
                        matrix[m][j] = 0;
                    }
                    for(int m = 0; m < matrix[0].Length; m++)
                    {
                        matrix[i][m] = 0;
                    }
                }
            }
        }
        
    }
}
