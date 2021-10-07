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
    
    TreeNode first = null;
    TreeNode last = null;
    TreeNode prev = null;
    
    public void Validate(TreeNode a)
    {
        if(a == null) return;
        
        Validate(a.left);
        
        if(prev != null && prev.val > a.val)
        {
            if(first == null)
            {
                first = prev;
            }
            last = a;
        }
        
        prev = a;
        Validate(a.right);
    }
    
    public void RecoverTree(TreeNode root)
    {
        Validate(root);
        
        var temp = first.val;
        first.val = last.val;
        last.val = temp;
    }
}
