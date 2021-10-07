public class Solution {
    public int MaximalSquare(char[][] matrix) {
        int max = 0;
        int rows = matrix.Length;
        int cols = rows == 0 ? 0 : matrix[0].Length;
        
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                if(matrix[i][j] == '1')
                {
                    int sqlen = 1;
                    bool valid = true;
                    while(sqlen + i < rows && sqlen + j < cols && valid)
                    {
                        for(int k = j; k <= sqlen + j; k++)
                        {
                            if(matrix[i + sqlen][k] == '0') 
                            {
                                valid = false;
                                break;
                            }
                        }
                        
                        if(!valid) break;
                        
                        for(int k = i; k <= sqlen + i; k++)
                        {
                            if(matrix[k][j + sqlen] == '0') 
                            {
                                valid = false;
                                break;
                            }
                        }
                        
                        if(valid)
                        {
                            sqlen++;
                        }
                    }
                    
                    max = Math.Max(max, sqlen);
                }
            }
        }
        
        return max * max;
    }
}
