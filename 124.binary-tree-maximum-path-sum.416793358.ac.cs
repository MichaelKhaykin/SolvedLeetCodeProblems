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
    
    private int max = Int32.MinValue;
    
    List<int> maxes = new List<int>();
    
     public int MaxPathSum(TreeNode root)
    {
        if (root != null)
            DFS(root);

        return max;
    }

    private int Sum(TreeNode root)
    {
        if (root == null) return 0;

        return root.val + Sum(root.left) + Sum(root.right);
    }

    private void OtherDFS(TreeNode root)
    {
        if (root == null) return;

        var left = root.left == null ? int.MinValue : Sum(root.left);
        var right = root.right == null ? int.MinValue : Sum(root.right);

        maxes.Add(root.val);
        if(left != int.MinValue)
        {
            maxes.Add(left);
            maxes.Add(left + root.val);
        }
        if (right != int.MinValue)
        {
            maxes.Add(right);
            maxes.Add(right + root.val);
        }
        if (left != int.MinValue && right != int.MinValue)
        {
            maxes.Add(left + right + root.val);
        }
        
        OtherDFS(root.left);
        OtherDFS(root.right);
    }
    
    private int DFS(TreeNode node)
    {
        if (node == null)
            return 0;
        
        int left = DFS(node.left);
        int right = DFS(node.right);
        int lpath = node.val + left;
        int rpath = node.val + right;
        int path = lpath >= rpath ? lpath : rpath;
                    
        max = Math.Max(max, Math.Max(Math.Max(lpath + rpath - node.val, path), node.val));
            
        return node.val >= path ? node.val : path;
    }
}
