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
    
    public IList<int> PostorderTraversal(TreeNode root) {
        List<int> bread = new List<int>();
        Stack<TreeNode> dfs = new Stack<TreeNode>();
        HashSet<TreeNode> seen = new HashSet<TreeNode>();
        
        var current = root;
        
        while(dfs.Count > 0 || current != null)
        {
            if(current != null)
            {
                dfs.Push(current);
                current = current.left;
            }        
            else
            {
                var popped = dfs.Pop();
                if(seen.Contains(popped)) continue;
                
                if(popped.right == null || seen.Contains(popped.right))
                { 
                    bread.Add(popped.val);
                    seen.Add(popped);
                }
                else
                {
                    dfs.Push(popped);
                    current = popped.right;
                }
            }
        }
        
        return bread;
    }
}
