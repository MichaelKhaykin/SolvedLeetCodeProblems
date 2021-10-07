public class Solution {
    public void Rotate(int[][] matrix) {
        
        for(int i = 0; i < matrix.Length; i++)
        {
            for(int j = i; j < matrix[i].Length; j++)
            {
                var temp = matrix[j][i];
                matrix[j][i] = matrix[i][j];
                matrix[i][j] = temp;
            }
        }
        
        
        for(int i = 0; i < matrix.Length; i++)
        {
            for(int j = 0; j < matrix[i].Length / 2; j++)
            {
                var temp = matrix[i][j];
                matrix[i][j] = matrix[i][matrix[i].Length - j - 1];
                matrix[i][matrix[i].Length - j - 1] = temp;
            }
        }
    }
}
