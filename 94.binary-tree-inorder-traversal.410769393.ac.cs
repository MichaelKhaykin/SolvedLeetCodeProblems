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
    
    public void Traverse(List<int> path, TreeNode current)
    {
        if(current == null) return;
        
        Traverse(path, current.left);
        path.Add(current.val);
        Traverse(path, current.right);
    }
    
    public IList<int> InorderTraversal(TreeNode root) {
        List<int> path = new List<int>();
        Traverse(path, root);
        return path;
    }
}
