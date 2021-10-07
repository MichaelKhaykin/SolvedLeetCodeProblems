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
    
    public IList<int> PreorderTraversal(TreeNode root) {
        List<int> result = new List<int>();
        Stack<TreeNode> path = new Stack<TreeNode>();
        path.Push(root);
        
        while(path.Count > 0)
        {
            var current = path.Pop();
            if(current == null) continue;
            result.Add(current.val);
            
            path.Push(current.right);
            path.Push(current.left);
        }
        
        return result;
    }
}
