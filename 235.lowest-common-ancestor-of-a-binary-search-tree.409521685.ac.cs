/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    
    public void Traversal(TreeNode start, HashSet<TreeNode> path)
    {
        if(start == null) return;
        path.Add(start);
        Traversal(start.left, path);
        Traversal(start.right, path);
    }
    
    public TreeNode GetBestPath(TreeNode curr, TreeNode p, TreeNode q)
    {
        if(curr == null) return null;
        
        Queue<TreeNode> current = new Queue<TreeNode>();
        current.Enqueue(curr);
        
        TreeNode bes = null;
        int len = int.MaxValue;
        while(current.Count > 0)
        {
            var node = current.Dequeue();
            if(node == null) continue;
            
            var path = new HashSet<TreeNode>();
            Traversal(node, path);
         
            if(path.Contains(p) && path.Contains(q))
            {
                if(len > path.Count)
                {
                    len = path.Count;
                    bes = path.First();
                }
            }
            
            current.Enqueue(node.left);
            current.Enqueue(node.right);
        }
        
        return bes;
    }
    
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        return GetBestPath(root, p, q);
    }
}
