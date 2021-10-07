public class Solution {
    public int[] PrisonAfterNDays(int[] cells, int n) {
     
        n %= 14;
        if(n == 0)
        {
            n = 14;
        }
        
        for(int i = 0; i < n; i++)
        {
            int[] newArray = new int[cells.Length];
            
            for(int j = 1; j < cells.Length - 1; j++)
            {
                if(cells[j - 1] == cells[j + 1]){
                    newArray[j] = 1;
                }
                else{
                    newArray[j] = 0;
                }
            }
            
            cells = newArray;
        }
        
        return cells;
    }
}
