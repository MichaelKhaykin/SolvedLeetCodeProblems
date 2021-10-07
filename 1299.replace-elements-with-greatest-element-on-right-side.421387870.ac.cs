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
    public int[] ReplaceElements(int[] arr) {
        
        var max = -1;
        
        for (var i = arr.Length - 1; i >= 0 ; i--)
        {
            var t = arr[i];
            arr[i] = max;
            
            max = Math.Max(t, max);
        }
        
        return arr;
    }
}
