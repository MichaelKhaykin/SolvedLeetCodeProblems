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
    
    public TreeNode FindBottom(TreeNode a)
    {
        var curr = a;
        while(curr.right != null)
        {
            curr = curr.right;
        }
        return curr;
    }
    
    public void FlattenHelper(TreeNode root)
    {
        if(root == null) return;
        
        if(root.left != null)
        {
            var curr = root.right;
            var og = root.left;
            root.right = root.left;
            var a = FindBottom(root.left);
            a.right = curr;
            
            root.left = null;
            
            Flatten(og);
        }
        else
        {
            Flatten(root.right);
        }
    }
    
    public void Flatten(TreeNode root) {
        FlattenHelper(root);
    }
}
