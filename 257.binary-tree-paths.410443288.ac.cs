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
    
      public void DFS(TreeNode current, List<string> currentStrings, string currentString)
        {
            if (current.left == null && current.right == null)
            {
                currentStrings.Add(currentString + current.val);
                return;
            }
            
            if(current.left != null) DFS(current.left, currentStrings, currentString + $"{current.val}->"); 
            if(current.right != null) DFS(current.right, currentStrings, currentString + $"{current.val}->");
        }

        public IList<string> BinaryTreePaths(TreeNode root)
        {
            if(root == null) return new List<string>();
            
            List<string> currentStrings = new List<string>();
            string current = "";
            DFS(root, currentStrings, current);
            return currentStrings;
        }
}
