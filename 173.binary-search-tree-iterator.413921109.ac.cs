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
public class BSTIterator {
    List<TreeNode> x = new List<TreeNode>();
        int current = 0;
        public BSTIterator(TreeNode root)
        {
            if(root == null) return;
            InOrder(root, x);
        }

        private void InOrder(TreeNode root, List<TreeNode> x)
        {
            if(root.left != null)
            {
                InOrder(root.left, x);
            }
            x.Add(root);
            if(root.right != null)
            {
                InOrder(root.right, x);
            }
        }


        public int Next()
        {
            return x[current++].val;
        }

        /** @return whether we have a next smallest number */
        public bool HasNext()
        {
            return current != x.Count;
        }
}


/**
 * Your BSTIterator object will be instantiated and called as such:
 * BSTIterator obj = new BSTIterator(root);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */
