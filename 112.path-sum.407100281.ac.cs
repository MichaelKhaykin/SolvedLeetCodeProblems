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
    
    public bool DepthFirst(TreeNode current, int currentSum, int target)
    {
        if(current.left == null && current.right == null) 
        {
            return currentSum == target;
        }
        if(current.left == null) return DepthFirst(current.right, current.right.val + currentSum, target);
        if(current.right == null) return DepthFirst(current.left, current.left.val + currentSum, target);
        
        return DepthFirst(current.left, current.left.val + currentSum, target) || 
               DepthFirst(current.right, current.right.val + currentSum, target);
    }
    
    public bool HasPathSum(TreeNode root, int sum) {
        if(root == null) return false;
        return DepthFirst(root, root.val, sum);
    }
}
