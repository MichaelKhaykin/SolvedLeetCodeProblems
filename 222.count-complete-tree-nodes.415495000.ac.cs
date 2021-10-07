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
    
    public void Beep(TreeNode x, List<int> vals)
    {
        if(x == null) return;
        
        Beep(x.left, vals);
        vals.Add(x.val);
        Beep(x.right, vals);
    }
    
    public int CountNodes(TreeNode root) {
        List<int> vals = new List<int>();
        Beep(root, vals);
        return vals.Count;
    }
}
