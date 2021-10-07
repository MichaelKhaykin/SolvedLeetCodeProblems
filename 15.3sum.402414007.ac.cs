public class Solution {
    private List<(int, int)> TwoSum(int[] nums, int lookFor, int start)
        {
            List<(int, int)> ret = new List<(int, int)>();
            HashSet<int> sums = new HashSet<int>();
            for (int i = start; i < nums.Length; i++)
            {
                if (sums.Contains(nums[i]))
                {
                    ret.Add((lookFor - nums[i], nums[i]));
                }
                sums.Add(lookFor - nums[i]);
            }
            return ret;
        }
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            nums = nums.OrderBy(t => t).ToArray();
            IList<IList<int>> returnVal = new List<IList<int>>();

            var prev = int.MinValue;
            for (int j = 0; j < nums.Length; j++)
            {
                if (prev == nums[j]) continue;

                var list = TwoSum(nums, 0 - nums[j], j + 1);
                list = list.Distinct().ToList();
                foreach(var item in list)
                {
                    returnVal.Add(new List<int>()
                    {
                        nums[j],
                        item.Item1,
                        item.Item2
                    });
                }

                prev = nums[j];
            }

            return returnVal;
        }
}
