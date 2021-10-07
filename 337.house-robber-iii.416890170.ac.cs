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
    
    int[] Traverse(TreeNode root)
    {
        if(root == null) return new int[] { 0, 0};
        
        var left = Traverse(root.left);
        var right = Traverse(root.right);
        
        int rob = root.val + left[1] + right[1];
        int notRob = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
        
        return new int[] { rob, notRob };
    }
    
    public int Rob(TreeNode root) {
        var ans = Traverse(root);
        return Math.Max(ans[0], ans[1]);
    }
}
