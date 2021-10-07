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
    
    public int ans = 0;
    
    public void Traverse(TreeNode root, int val)
    {
        if(root == null) return;
        
        int n = (val << 1) | root.val;
        if(root.left == null && root.right == null) 
        {
            ans += n;
            return;
        }
        
        Traverse(root.left, n);
        Traverse(root.right, n);
    }
    
    public int SumRootToLeaf(TreeNode root) {
        Traverse(root, 0);
        
        return ans;
    }
}
