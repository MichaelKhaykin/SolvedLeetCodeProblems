public class Solution {
    public IList<int> GetRow(int numRows) {
  
        List<IList<int>> returnValue = new List<IList<int>>();
        
        returnValue.Add(new List<int>() { 1 });
        returnValue.Add(new List<int>() { 1, 1 });
        
        if(numRows == 0) return returnValue[0];
        if(numRows == 1) return returnValue[1];
        
        for(int i = 2; i <= numRows; i++)
        {
            int[] newList = new int[i + 1];
            newList[0] = 1;
            newList[newList.Length - 1] = 1;
            int current = 1;
            
            var previous = returnValue[returnValue.Count - 1];
            for(int j = 0; j < previous.Count - 1; j++)
            {
                newList[current] = previous[j] + previous[j + 1];
                current++;
            }
            
            if(i == numRows) return newList.ToList();
            returnValue.Add(newList.ToList());
            
        }
            
        return null;
    }
}
