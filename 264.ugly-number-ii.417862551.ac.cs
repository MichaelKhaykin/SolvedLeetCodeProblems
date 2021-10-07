public class Solution {
   
    public int NthUglyNumber(int n)
    {
        List<int> all = new List<int>();
        all.Add(1);
        
        int i = 0;
        int j = 0;
        int k = 0;
        
        while(all.Count < n)
        {
            int temp = all[i] * 2;
            int temp1 = all[j] * 3;
            int temp2 = all[k] * 5;
            
            var num = Math.Min(Math.Min(temp, temp1), temp2);
            all.Add(num);
            
            if(num == temp) i++;
            if(num == temp1) j++;
            if(num == temp2) k++;
        }
        
        return all[n - 1];
    }
}
