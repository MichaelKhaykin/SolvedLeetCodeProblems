public class Solution {
    
    static Dictionary<int, int> solutions = new Dictionary<int, int>();
    
    public int ClimbStairs(int n) {
    
        int count = 0;
        
        Queue<int> wtf = new Queue<int>();
        wtf.Enqueue(n);
        
        while(wtf.Count > 0)
        {
            var num = wtf.Dequeue();
            
            if(solutions.ContainsKey(num))
            {
                count += solutions[num];
                continue;
            }
            
            if(num == 0)
            {
                count++;
                continue;
            }
            
            if(num - 1 >= 0)
            {
                wtf.Enqueue(num - 1);
            }
            if(num - 2>= 0)
            {
                wtf.Enqueue(num - 2);
            }
        }
        
        if(solutions.ContainsKey(n) == false)
        {
            solutions.Add(n, count);
        }
        
        return count;
    }
}
