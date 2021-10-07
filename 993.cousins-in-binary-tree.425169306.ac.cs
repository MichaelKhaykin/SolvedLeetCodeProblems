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
    public bool IsCousins(TreeNode root, int x, int y) {
        
        Queue<TreeNode> easy = new Queue<TreeNode>();
        easy.Enqueue(root);
        
        bool foundX = false;
        bool foundY = false;
        
        TreeNode xParent = null;
        TreeNode yParent = null;
        
        while(easy.Count > 0)
        {
            var size = easy.Count;
            while(size > 0)
            {
                var node = easy.Dequeue();
                
                if(node.val == x) 
                {
                    foundX = true;
                }
                else if(node.val == y)
                {
                    foundY = true;
                }
                
                if(node.left != null)
                {
                    if(node.left.val == x)
                    {
                        xParent = node;
                    }
                    if(node.left.val == y)
                    {
                        yParent = node;
                    }
                    easy.Enqueue(node.left);
                }
                if(node.right != null)
                {   
                    if(node.right.val == x)
                    {
                        xParent = node;
                    }
                    if(node.right.val == y)
                    {
                        yParent = node;
                    }
                    easy.Enqueue(node.right);
                }
                size--;
            }
            
            if(foundX && !foundY) return false;
            if(foundY && !foundX) return false;
            if(foundX && foundY)
            {
                if(xParent == yParent) return false;
                return true;
            }
        }
        
        return false;
    }
}
