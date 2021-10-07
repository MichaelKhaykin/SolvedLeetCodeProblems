public class Solution {
    public IList<int> MajorityElement(int[] nums) {
        Dictionary<int, int> fuckfrench = new Dictionary<int, int>();
        
        int len = nums.Length / 3;
        
        HashSet<int> speed = new HashSet<int>();
        
        foreach(var num in nums)
        {
            if(!fuckfrench.ContainsKey(num))
            {
                fuckfrench.Add(num, 1);
                if(fuckfrench[num] > len)
                {
                    speed.Add(num);
                }
            }
            else
            {
                fuckfrench[num]++;
                if(fuckfrench[num] > len)
                {
                    speed.Add(num);
                }
            }
        }
        
        return speed.ToList();
    }
}

