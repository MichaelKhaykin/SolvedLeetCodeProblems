public class MinValueSegmentTree
{
    private int[] SegData { get; set; }
    
    public int[] OgData { get; set; }
    public MinValueSegmentTree(int[] nums)
    {
        SegData = new int[nums.Length * 4 + 1];
       
        OgData = nums;
        Construct(nums, 0, 0, nums.Length - 1);
    }
    private int Construct(int[] nums, int i, int l, int r)
    {
        if (l == r)
        {
            SegData[i] = nums[l];
            return nums[l];
        }

        int mid = (l + r) / 2;

        var left = Construct(nums, i * 2 + 1, l, mid);
        var right = Construct(nums, i * 2 + 2, mid + 1, r);
        SegData[i] = Math.Min(left, right);

        return SegData[i];
    }

    public int GetMin(int l, int r)
        => GetMin(0, 0, OgData.Length - 1, l, r);
    private int GetMin(int index, int leftmost, int rightmost, int l, int r)
    {
        bool full = l <= leftmost && r >= rightmost;
        bool none = (rightmost < l || leftmost > r);

        if (none) return int.MaxValue;

        if (full) return SegData[index];

        int mid = (leftmost + rightmost) / 2;

        var left = GetMin(index * 2 + 1, leftmost, mid, l, r);
        var right = GetMin(index * 2 + 2, mid + 1, rightmost, l, r);
        return Math.Min(left, right);
    }
}

public class MaxValueSegmentTree
{
    private int[] SegData { get; set; }
    
    public int[] OgData { get; set; }
    public MaxValueSegmentTree(int[] nums)
    {
        SegData = new int[nums.Length * 4 + 1];
       
        OgData = nums;
        Construct(nums, 0, 0, nums.Length - 1);
    }
    private int Construct(int[] nums, int i, int l, int r)
    {
        if (l == r)
        {
            SegData[i] = nums[l];
            return nums[l];
        }

        int mid = (l + r) / 2;

        var left = Construct(nums, i * 2 + 1, l, mid);
        var right = Construct(nums, i * 2 + 2, mid + 1, r);
        SegData[i] = Math.Max(left, right);

        return SegData[i];
    }

    public int GetMax(int l, int r)
        => GetMax(0, 0, OgData.Length - 1, l, r);
    private int GetMax(int index, int leftmost, int rightmost, int l, int r)
    {
        bool full = l <= leftmost && r >= rightmost;
        bool none = (rightmost < l || leftmost > r);

        if (none) return int.MinValue;

        if (full) return SegData[index];

        int mid = (leftmost + rightmost) / 2;

        var left = GetMax(index * 2 + 1, leftmost, mid, l, r);
        var right = GetMax(index * 2 + 2, mid + 1, rightmost, l, r);
        return Math.Max(left, right);
    }
}

public class Solution {
    public int LongestSubarray(int[] arr, int limit) {
      
        MinValueSegmentTree x = new MinValueSegmentTree(arr);
        MaxValueSegmentTree y = new MaxValueSegmentTree(arr);
        
        int left = 0;
        int right = 0;
        
        int maxval = int.MinValue;
        int minval = int.MaxValue;
        
        int sum = 0;
        
        int longest = int.MinValue;
        
        while(right < arr.Length)
        {
            maxval = Math.Max(maxval, arr[right]);
            minval = Math.Min(minval, arr[right]);
            
            var diff = maxval - minval;
            while(diff > limit)
            {
                left++;
            
                if(left > arr.Length) return longest;
                    
                maxval = y.GetMax(left, right);
                minval = x.GetMin(left, right);
             
                diff = maxval - minval;
            }
            
            longest = Math.Max(longest, right - left + 1);
       
            right++;
        }
        
        return longest;
    }
}
