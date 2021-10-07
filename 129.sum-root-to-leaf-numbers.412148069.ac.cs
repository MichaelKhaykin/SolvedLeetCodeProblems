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
    
    public void Traverse(TreeNode current, List<List<int>> paths, List<int> currentList)
    {
        var newList = new List<int>(currentList);
        newList.Add(current.val);
        
        if(current.left == null && current.right == null)
        {
            paths.Add(newList);
            return;
        }
        
        if(current.left != null) Traverse(current.left, paths, newList);
        if(current.right != null) Traverse(current.right, paths, newList);
    }
    
    public int SumNumbers(TreeNode root) {
        
        if(root == null) return 0;
        
        var returnval = new List<List<int>>();
        Traverse(root, returnval, new List<int>());
        
        int acc = 0;
        foreach(var x in returnval)
        {
            string v = "";
            foreach(var item in x)
            {
                v += item;
            }
            acc += int.Parse(v);
        }
        return acc;
    }
}
