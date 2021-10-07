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
    
    public void GetDepths(TreeNode root, int current, Dictionary<TreeNode, int> depths)
    {
        if (root.left != null) GetDepths(root.left, current + 1, depths);
        depths.Add(root, current);
        if (root.right != null) GetDepths(root.right, current + 1, depths);
    }
    
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        if (root == null) return new List<IList<int>>();

        Dictionary<TreeNode, int> depths = new Dictionary<TreeNode, int>();
        GetDepths(root, 0, depths);

        Queue<TreeNode> path = new Queue<TreeNode>();
        path.Enqueue(root);

        List<IList<int>> returnValue = new List<IList<int>>();
        int currentDepth = 0;

        List<int> currentList = new List<int>();

        bool didEnqueueLeft = true;
        
        while (path.Count > 0)
        {
            var current = path.Dequeue();
            if (depths[current] != currentDepth)
            {
                currentDepth++;
                
                if(!didEnqueueLeft)
                {
                    currentList.Reverse();
                }
                returnValue.Add(currentList);
                
                didEnqueueLeft = !didEnqueueLeft;
                
                currentList = new List<int>()
                {
                    current.val
                };
            }
            else
            {
                currentList.Add(current.val);
            }
            
            if (current.left != null) path.Enqueue(current.left);
            if (current.right != null) path.Enqueue(current.right);   
        }

        if(!didEnqueueLeft)
        {   
            currentList.Reverse();
        }
        returnValue.Add(currentList);
        

        return returnValue;
    }
}
