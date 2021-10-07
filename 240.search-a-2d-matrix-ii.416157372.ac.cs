public class Solution {
    
    public bool SearchMatrix(int[,] matrix, int target) {
        
        if(matrix.GetLength(0) < 1 || matrix.GetLength(1) < 1) return false;
        
        int minLength = Math.Min(matrix.GetLength(0), matrix.GetLength(1));
        
        for(int i = 0; i < minLength; i++)
        {
            bool whore = bSearch(i, matrix, true, target);
            bool vert = bSearch(i, matrix, false, target);
                
            if(whore || vert) return true;
        }
        return false;
    }
    
    public bool bSearch(int pos, int[,] matrix, bool vert, int target)
    {
        int low = 0;
        
        
        int n = matrix.GetLength(0) - 1;
        int h = matrix.GetLength(1) - 1;
        
        int high = vert ? n : h;
        
        
        while(low <= high)
        {
            int mid = (high + low) /2;
            if(vert)
            {
               if(matrix[mid, pos] > target){
                    high = mid - 1;
                }
                else if(matrix[mid, pos] < target){
                    low = mid + 1;
                }
                else
                {
                    return true;
                } 
            }
            else
            {
                if(matrix[pos, mid] > target){
                    high = mid - 1;
                }
                else if(matrix[pos, mid] < target){
                    low = mid + 1;
                }
                else
                {
                    return true;
                }
            }
        }
        
        return false;
    }
}
