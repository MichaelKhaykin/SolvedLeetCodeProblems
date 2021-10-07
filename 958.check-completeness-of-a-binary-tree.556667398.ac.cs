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
    public bool IsCompleteTree(TreeNode root) {
        if(root == null) return true;
        return LevelOrder(root);
    }
    
    private int GetDepth(TreeNode root, int depth)
    {
        if(root.left == null && root.right == null) return depth;
        
        int left = int.MinValue;
        int right = int.MinValue;
        
        if(root.left != null){
            left = GetDepth(root.left, depth + 1);
        }
        if(root.right != null){
            right = GetDepth(root.right, depth + 1);
        }
        
        return Math.Max(left, right);
    }
    
    private bool LevelOrder(TreeNode root)
    {
        Queue<TreeNode> bfs = new Queue<TreeNode>();
        bfs.Enqueue(root);
        
        int lastLevel = GetDepth(root, 1);
        
        int level = 1;
    
        while(bfs.Count > 0)
        {
            int oldCount = bfs.Count;
            bool sawNull = false;
            bool anyNotNull = false;
            
            while(oldCount > 0)
            {
                var m = bfs.Dequeue();
                oldCount--;
                
                if(m != null && sawNull) return false;
                
                if(m == null) 
                {
                    sawNull = true;
                    continue;
                }
                else
                {
                    anyNotNull = true;
                }
                
                bfs.Enqueue(m.left);
                bfs.Enqueue(m.right);
                
            }
            
            if(anyNotNull == false) return true;
            
            if(sawNull && level != lastLevel) 
            {
                Console.WriteLine(level);
                return false;
            }
            level++;
        }
        
        return true;
    }
}
