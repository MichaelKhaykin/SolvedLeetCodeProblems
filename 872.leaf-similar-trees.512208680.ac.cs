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
    public bool LeafSimilar(TreeNode root1, TreeNode root2) {
        List<int> val1 = new List<int>();
        DFS(root1, val1);
        List<int> val2 = new List<int>();
        DFS(root2, val2);
        
        return val1.SequenceEqual(val2);
    }
    
    public void DFS(TreeNode current, List<int> vals){
        
        if(current == null) return;
        
        if(current.left == null && current.right == null){
            vals.Add(current.val);
            return;
        }
        
        DFS(current.left, vals);
        DFS(current.right, vals);
    }
}
