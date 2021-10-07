public class Solution
{
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
{
	bool[] result = new bool[l.Length];

	for (int i = 0; i < l.Length; i++)
	{
		int start = l[i];
		int end = r[i];

		if (end - start + 1 < 2)
		{
			result[i] = false;
			continue;
		}

		int firstSmall = int.MaxValue;
		int secondSmall = int.MaxValue;
		int largest = int.MinValue;

		for (int j = start; j <= end; j++)
		{
			if (nums[j] < firstSmall)
			{
				secondSmall = firstSmall;
				firstSmall = nums[j];
			}

			else if (nums[j] < secondSmall)
			{
				secondSmall = nums[j];
			}

			largest = Math.Max(largest, nums[j]);
		}

		HashSet<int> set = new HashSet<int>();
		for (int j = start; j <= end; j++)
		{
			set.Add(nums[j]);
		}

		// All elements have equal value
		if(firstSmall == secondSmall && set.Count != 1)
		{
			result[i] = false;
			continue;   
		}

		// check if there are any duplicates
		if(firstSmall != secondSmall && set.Count != (end - start + 1))
		{
			result[i] = false;
			continue;                       
		}

		int diff = secondSmall - firstSmall;
		bool isValid = true;
		for (int j = start; j <= end; j++)
		{
			if (nums[j] != largest && !set.Contains(nums[j] + diff))
			{
				isValid = false;
				break;
			}
		}

		result[i] = isValid;
	}

	return result;
}
}
