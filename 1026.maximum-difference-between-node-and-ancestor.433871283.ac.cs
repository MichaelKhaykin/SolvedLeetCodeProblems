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
    
    public void Traverse(int val, TreeNode current)
    {
        if(current == null) return;
        
        max = Math.Max(max, Math.Abs(val - current.val));
    
        Traverse(val, current.left);
        Traverse(val, current.right);
    }
    
    int max = int.MinValue;
    
    public int MaxAncestorDiff(TreeNode root) {
        
        Queue<TreeNode> bfs = new Queue<TreeNode>();
        bfs.Enqueue(root);
        
        while(bfs.Count > 0)
        {   
            var deq = bfs.Dequeue();
         
            if(deq == null) continue;
            
            Traverse(deq.val, deq);
            
            bfs.Enqueue(deq.left);
            bfs.Enqueue(deq.right);
        }
        
        return max;
    }
    
}
