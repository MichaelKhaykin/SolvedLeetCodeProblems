/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
      public void Add(TreeNode a, int b)
        {
            var start = a;
            while(true)
            {
                if(start.val < b)
                {
                    if(start.right == null)
                    {
                        start.right = new TreeNode(b);
                        return;
                    }
                    start = start.right;
                }
                else
                {
                    if(start.left == null)
                    {
                        start.left = new TreeNode(b);
                        return;
                    }
                    start = start.left;
                }
            }
        }

        public bool IsSame(TreeNode a, TreeNode b)
        {
            if (a != null && b == null) return false;
            if (a == null && b != null) return false;
            if (a == null && b == null) return true;
            if (a.val != b.val) return false;

            return IsSame(a.left, b.left) && IsSame(a.right, b.right);
        }

        public void Build(int[] nums, List<TreeNode> nodesToReturn, string c)
        {
            if(nums.Length == 0)
            {
                TreeNode p = new TreeNode(int.Parse(c[0].ToString()));
                for(int i = 1; i < c.Length; i++)
                {
                    Add(p, int.Parse(c[i].ToString()));
                }

                foreach(var item in nodesToReturn)
                {
                    if (IsSame(item, p)) return;
                }

                nodesToReturn.Add(p);
                return;
            }

            for(int i = 0; i < nums.Length; i++)
            {
                var newArr = new int[nums.Length - 1];
                int m = 0;
                for(int j = 0; j < nums.Length; j++)
                {
                    if (j == i) continue;
                    newArr[m] = nums[j];
                    m++;
                }

                Build(newArr, nodesToReturn, c + nums[i]);
            }
        }
        public IList<TreeNode> GenerateTrees(int n)
        {
            if(n == 0) return new List<TreeNode>();
            
            int[] vals = new int[n];
            for(int i = 1; i <= n; i++)
            {
                vals[i - 1] = i;
            }

            List<TreeNode> ret = new List<TreeNode>();
            Build(vals, ret, "");

            return ret;
        }
}
