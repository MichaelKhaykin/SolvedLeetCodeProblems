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
    
    public void Traverse(TreeNode node, Dictionary<int, List<int>> levels, int currentLevel)
    {
        if(node == null) return;
        
        if(!levels.ContainsKey(currentLevel))
        {
            levels.Add(currentLevel, new List<int>() { node.val });
        }
        else
        {
            levels[currentLevel].Add(node.val);
        }
        
        Traverse(node.left, levels, currentLevel + 1);
        Traverse(node.right, levels, currentLevel + 1);
    }
    
    public IList<IList<int>> LevelOrderBottom(TreeNode root) {
        if(root == null) return new List<IList<int>>();
        
        Dictionary<int, List<int>> levels = new Dictionary<int, List<int>>();
        Traverse(root, levels, 0);
        
        int length = levels.Keys.Count;
        List<IList<int>> numbers = new List<IList<int>>(length);
        foreach(var item in levels)
        {
            numbers.Add(item.Value);
        }
        
        numbers.Reverse();
        
        return numbers;
    }
}
