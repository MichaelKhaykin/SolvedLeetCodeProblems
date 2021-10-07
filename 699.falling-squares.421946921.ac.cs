public class MaxSegmentTree
    {
        private int[] SegData { get; set; }

        private int len = 0;
        public MaxSegmentTree(int[] nums)
        {
            SegData = new int[nums.Length * 4 + 1];
            for (int i = 0; i < SegData.Length; i++)
            {
                SegData[i] = -1;
            }
            len = nums.Length;
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
            => GetMax(0, 0, len - 1, l, r);

        private int GetMax(int index, int leftmost, int rightmost, int l, int r)
        {
            bool full = l <= leftmost && r >= rightmost;
            bool none = (rightmost < l || leftmost > r);

            if (none) return int.MinValue;

            if (full) return SegData[index];

            int mid = (leftmost + rightmost) / 2;

            var left = GetMax(index * 2 + 1, leftmost, mid, l, r);
            var right = GetMax(index * 2 + 2, mid + 1, rightmost, l, r);

            if (left == int.MinValue) return right;
            if (right == int.MinValue) return left;

            return Math.Max(left, right);
        }

        private void UpdateSeg(int index, int leftmost, int rightmost, int l, int r, int newval)
        {
            if (rightmost < l || leftmost > r) return;

            SegData[index] = Math.Max(SegData[index], newval);
            if (leftmost != rightmost)
            {
                int mid = (leftmost + rightmost) / 2;
                UpdateSeg(index * 2 + 1, leftmost, mid, l, r, newval);
                UpdateSeg(index * 2 + 2, mid + 1, rightmost, l, r, newval);
            }
        }
        public void Update(int l, int r, int newval)
        {
            UpdateSeg(0, 0, len - 1, l, r, newval);
        }
    }

public class Solution {
    public IList<int> FallingSquares(int[][] positions) {
        HashSet<int> coordinates = new HashSet<int>();
            foreach (var pos in positions)
            {
                coordinates.Add(pos[0]);
                coordinates.Add(pos[0] + pos[1] - 1);
            }

            var list = coordinates.ToList();
            list.Sort();

            Dictionary<int, int> index = new Dictionary<int, int>();
            for (int i = 0; i < list.Count; i++)
            {
                index.Add(list[i], i);
            }


            int[] maxHeights = new int[positions.Length];

            int[] a = new int[list.Count];
            MaxSegmentTree tree = new MaxSegmentTree(a);

            int best = int.MinValue;
            for (int i = 0; i < positions.Length; i++)
            {
                var left = index[positions[i][0]];
                var right = index[positions[i][0] + positions[i][1] - 1];

                var max = tree.GetMax(left, right) + positions[i][1];
                tree.Update(left, right, max);

                best = Math.Max(best, max);

                maxHeights[i] = best;
            }

            return maxHeights;
    }
}
