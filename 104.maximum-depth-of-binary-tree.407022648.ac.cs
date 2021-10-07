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
    
    public int Recursive(TreeNode currNode, int current)
    {
        if(currNode == null) return current;
        
        return Math.Max(Recursive(currNode.left, current + 1), Recursive(currNode.right, current + 1));
    }
    
    public int MaxDepth(TreeNode root) {
        return Recursive(root, 0);
    }
}
