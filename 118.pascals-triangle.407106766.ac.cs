public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        if(numRows == 0) return new List<IList<int>>();
        
        List<IList<int>> returnValue = new List<IList<int>>();
        for(int i = 1; i <= numRows; i++)
        {
            if(i == 1)
            {
                returnValue.Add(new List<int>() { 1 });
                continue;
            }
            if(i == 2)
            {
                returnValue.Add(new List<int>() { 1, 1 });
                continue;
            }
            
            int[] newList = new int[i];
            newList[0] = 1;
            newList[newList.Length - 1] = 1;
            int current = 1;
            
            var previous = returnValue[returnValue.Count - 1];
            for(int j = 0; j < previous.Count - 1; j++)
            {
                newList[current] = previous[j] + previous[j + 1];
                current++;
            }
            
            returnValue.Add(newList);
        }
            
        return returnValue;
    }
}
