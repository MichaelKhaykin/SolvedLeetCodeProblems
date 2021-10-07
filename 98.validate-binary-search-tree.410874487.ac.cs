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
    
    public bool Validate(TreeNode a, int? min, int? max)
    {
        if(a == null) return true;
        
        if(min != null && a.val <= min) return false;
        if(max != null && a.val >= max) return false;
        
        return Validate(a.left, min, a.val) && Validate(a.right, a.val, max);
    }
    
    public bool IsValidBST(TreeNode root) {
        
        return Validate(root, null, null);   
    }
}
