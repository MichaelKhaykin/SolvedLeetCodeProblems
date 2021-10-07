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
    
    public void FindAllPaths(List<IList<int>> final, List<int> current, TreeNode root, int sum)
    {
        List<int> newList = new List<int>();
        foreach(var item in current)
        {
            newList.Add(item);
        }
        newList.Add(root.val);
        
        if(root.left == null && root.right == null)
        {
            if(newList.Sum() == sum)
            {
                final.Add(newList);
            }
            return;
        }
        
        if(root.left != null)
        {
            FindAllPaths(final, newList, root.left, sum);
        }
        if(root.right != null)
        {
            FindAllPaths(final, newList, root.right, sum);
        }
    }
    
    public IList<IList<int>> PathSum(TreeNode root, int sum) {
        if(root == null) return new List<IList<int>>();
        
        List<IList<int>> final = new List<IList<int>>();
        FindAllPaths(final, new List<int>(), root, sum);
        
        return final;
    }
}
