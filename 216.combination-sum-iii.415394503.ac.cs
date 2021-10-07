public class Solution {
    
    public bool IsListSame(IList<int> a, IList<int> b)
    {
        HashSet<int> x = new HashSet<int>(a);
        
        foreach(var item in b)
        {
            if(x.Add(item))
            {
                return false;
            }
        }
        
        return true;
    }
    
    bool everyNumberUsed = false;
    
    public void Helper(List<IList<int>> returnVal, int k, int n, List<int> current, int index)
    {
        if(everyNumberUsed) return;
        
        if(index == k)
        {
            if(current.Sum() != n || current.Count != k) return;
            
            foreach(var list in returnVal)
            {
                if(IsListSame(list, current))
                {
                    return;
                }
            }
            
            HashSet<int> everyNumUsed = new HashSet<int>(current);
            bool didGoIn = false;
            for(int i = 1; i <= 9; i++)
            {
                if(everyNumUsed.Add(i))
                {
                    didGoIn = true;
                    break;
                }
            }
            
            if(!didGoIn) everyNumberUsed = true;
            
            returnVal.Add(current);
            return;
        }
        
        
        for(int abe = 1; abe <= 9; abe++)
        {
            HashSet<int> newcurrent = new HashSet<int>(current);
            while(!newcurrent.Add(abe))
            {
                abe++;
            }
            
            if(abe >= 10) return;
            
            Helper(returnVal, k, n, newcurrent.ToList(), index + 1);
        }
    }
    
    
    public IList<IList<int>> CombinationSum3(int k, int n) {
        List<IList<int>> test = new List<IList<int>>();
        Helper(test, k, n, new List<int>(), 0);
        return test;
    }
}
