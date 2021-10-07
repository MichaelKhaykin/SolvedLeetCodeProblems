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
   
    static void InOrder(TreeNode curr, List<int> x)
    {
        if (curr == null) return;

        InOrder(curr.left, x);
        x.Add(curr.val);
        InOrder(curr.right, x);
    }
    
    public int KthSmallest(TreeNode root, int k) {
        
        List<int> vals = new List<int>();
        InOrder(root, vals);
        return vals[k - 1];
    }
}
