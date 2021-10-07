public class Solution {
    
    public int CarFleet(int target, int[] position, int[] speed)
    {
        Dictionary<int, double> times = new Dictionary<int, double>();
        List<int> poses = new List<int>();
        for(int i = 0; i < position.Length; i++)
        {
            poses.Add(position[i]);
            times.Add(position[i], (target - position[i]) / (double)speed[i]);
        }
        poses.Sort();
        
        int ans = 0;
        int t = position.Length;
        while(--t > 0)
        {
            if(times[poses[t]] < times[poses[t - 1]]) ans++;
            else 
            {
                poses[t-1] = poses[t];
            }
        }
        
        return ans + (t == 0 ? 1 : 0);
    }
}
