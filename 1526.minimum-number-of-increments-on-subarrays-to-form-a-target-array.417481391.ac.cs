public class Solution {
        
    public class MinSegmentTree
    {
        private int[] SegData { get; set; }
        public int[] OgData { get; set; }
        public MinSegmentTree(int[] nums)
        {
            SegData = new int[nums.Length * 4 + 1];
            for(int i = 0; i < SegData.Length; i++)
            {
                SegData[i] = -1;
            }
            OgData = nums;
            Construct(nums, 0, 0, nums.Length - 1);
        }
        private int Construct(int[] nums, int i, int l, int r)
        {
            if (l == r)
            {
                SegData[i] = l;
                return l;
            }

            int mid = (l + r) / 2; 
            
            var left = Construct(nums, i * 2 + 1, l, mid);
            var right = Construct(nums, i * 2 + 2, mid + 1, r);
            SegData[i] = OgData[left] < OgData[right] ? left : right;

            return SegData[i];
        }

        public int GetMinIndex(int l, int r)
            => GetMinIndex(0, 0, OgData.Length - 1, l, r);

        private int GetMinIndex(int index, int leftmost, int rightmost, int l, int r)
        {
            bool full = l <= leftmost && r >= rightmost;
            bool none = (rightmost < l || leftmost > r);

            if (none) return -1;

            if (full) return SegData[index];

            int mid = (leftmost + rightmost) / 2;

            var left = GetMinIndex(index * 2 + 1, leftmost, mid, l, r);
            var right = GetMinIndex(index * 2 + 2, mid + 1, rightmost, l, r);

            if (left == -1) return right;
            if (right == -1) return left;

            return OgData[left] < OgData[right] ? left : right;
        }
    }
    
    public int UpdateAll(int subArrVal, int start, int end, int[] target, MinSegmentTree tree)
    {
        if (start <= end)
        {
            var minIndex = tree.GetMinIndex(start, end);
            int val = target[minIndex] - subArrVal;
            return val + UpdateAll(target[minIndex], start, minIndex - 1, target, tree) +
                         UpdateAll(target[minIndex], minIndex + 1, end, target, tree);
        }
        return 0;
    }
    
    public int MinNumberOperations(int[] target) {
        MinSegmentTree seg = new MinSegmentTree(target);
        return UpdateAll(0, 0, target.Length - 1, target, seg);
    }
}
