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
        public int FindLeftHeight(TreeNode c)
        {
            if(c == null) return 0;
            return FindHeight(c.left, 1);
        }
        public int FindRightHeight(TreeNode c)
        {
            if(c == null) return 0;
            return FindHeight(c.right, 1);
        }

        public int FindHeight(TreeNode current, int height)
        {
            if (current == null) return height;

            return Math.Max(FindHeight(current.left, height + 1), FindHeight(current.right, height + 1));
        }

        public bool IsBalancedHelper(TreeNode curr)
        {
            var lH = FindLeftHeight(curr);
            var rH = FindRightHeight(curr);

            if (Math.Abs(lH - rH) > 1) return false;
            if (curr == null) return true;

            return IsBalancedHelper(curr.left) && IsBalancedHelper(curr.right);
        }

        public bool IsBalanced(TreeNode root)
        {
            if (root == null) return true;
            return IsBalancedHelper(root);
        }
}
