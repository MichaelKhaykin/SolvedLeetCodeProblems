public class Solution {
   private (int, int) TwoSum1Pair(int[] nums, int lookFor, int start)
    {
        HashSet<int> sums = new HashSet<int>();
        for (int i = start; i < nums.Length; i++)
        {
            if (sums.Contains(nums[i]))
            {
                return (lookFor - nums[i], nums[i]);
            }
            sums.Add(lookFor - nums[i]);
        }
        return (int.MinValue, int.MinValue);
    }
    
    private bool HasValue((int, int) p)
        {
            return p.Item1 != int.MinValue && p.Item2 != int.MinValue;
        }

    public int ThreeSumClosest(int[] nums, int target)
    {
        if (nums[0] == 0 && nums.Distinct().ToArray().Length == 1) return 0;

            int acc = 0;
            while(true)
            {
                for(int i = 0; i < nums.Length; i++)
                {
                    var p = TwoSum1Pair(nums, target - nums[i] + acc, i + 1);
                    var x = TwoSum1Pair(nums, target - nums[i] - acc, i + 1);
                    if (!HasValue(p) && HasValue(x))
                    {
                        return nums[i] + x.Item1 + x.Item2;
                    }
                    else if(!HasValue(x) && HasValue(p))
                    {
                        return nums[i] + p.Item1 + p.Item2;
                    }
                    else if(HasValue(x) && HasValue(p))
                    {
                        return nums[i] + p.Item1 + p.Item2;
                    }
                }
                acc++;
            }
    }
}
