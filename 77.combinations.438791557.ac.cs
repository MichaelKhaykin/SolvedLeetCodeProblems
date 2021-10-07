public class Solution {
    
        List<IList<int>> combos = new List<IList<int>>();

        public void BackTracking(int[] nums, int k, List<int> current)
        {
            if (k == 0)
            {
                combos.Add(current.ToList());
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                var newNums = new int[nums.Length - i - 1];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    newNums[j - (i + 1)] = nums[j];
                }

                if (newNums.Contains(0)) continue;

                BackTracking(newNums, k - 1, new List<int>(current) { nums[i] });
            }
        }

        public IList<IList<int>> Combine(int n, int k)
        {

            int[] nums = new int[n];
            for (int i = 1; i <= n; i++)
            {
                nums[i - 1] = i;
            }

            BackTracking(nums, k, new List<int>());
            return combos;
        }
}
