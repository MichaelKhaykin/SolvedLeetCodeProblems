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
    
    int len = 0;
    public void Traverse(TreeNode root, TreeNode parent, int target)
    {
        if(root == null) return;
        
        len++;
        if(root.left == null && root.right == null && root.val == target)
        {
            if(parent.left == root)
            {
                parent.left = null;
            }
            else 
            {
                parent.right = null;
            }
        }
        
        Traverse(root.left, root, target);
        Traverse(root.right, root, target);
    }
    
    public TreeNode RemoveLeafNodes(TreeNode root, int target) {
        
        int og = len;
        do
        {
            og = len;
            if(root.left == null && root.right == null)
            {
                return root.val == target ? null : root;
            }
            len = 0;
            Traverse(root, null, target);     
        }while(len != og);
            
        return root;
    }
}
