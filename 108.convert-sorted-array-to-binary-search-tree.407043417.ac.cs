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
    
    public TreeNode BuildTree(int low, int high, int[] nums)
        {
            if (high < low) return null;

            int mid = (low + high) / 2;
            TreeNode curr = new TreeNode(nums[mid], null, null);

            curr.left = BuildTree(low, mid - 1, nums);
            curr.right = BuildTree(mid + 1, high, nums);
            return curr;
        }

        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0) return null;

            var root = BuildTree(0, nums.Length - 1, nums);
            return root;
        }
}
