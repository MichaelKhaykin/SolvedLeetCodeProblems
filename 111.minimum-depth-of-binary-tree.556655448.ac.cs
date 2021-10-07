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
    
    public int MinDepth(TreeNode root) {
        if(root == null) return 0;
        return MinDepth(root, 1);
    }
    
    private int MinDepth(TreeNode root, int depth)
    {
        if(root.left == null && root.right == null) return depth;
     
        int left = int.MaxValue;
        int right = int.MaxValue;
        if(root.left != null)
        {
            left = MinDepth(root.left, depth + 1);
        }
        if(root.right != null)
        {
            right = MinDepth(root.right, depth + 1);
        }
        
        return Math.Min(left, right);
    }
}
