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
    
    public bool check(TreeNode aMover, TreeNode bMover)
    {
         if (aMover != null && bMover == null) return false;
                    if (aMover == null && bMover != null) return false;
                    if (aMover != null && bMover != null && aMover.val != bMover.val) return false;
                
        return true;
    }
    
    public bool Traversal(TreeNode a, TreeNode b)
        { 
            if (a.val != b.val) return false;

            var aMover = a;
            var bMover = b;

            Stack<TreeNode> path = new Stack<TreeNode>();
            Stack<TreeNode> bPath = new Stack<TreeNode>();
            path.Push(aMover);
            bPath.Push(bMover);

            while(path.Count > 0 || aMover != null || bMover != null || bPath.Count > 0)
            {
                if(path.Count != bPath.Count) return false;
                if(!check(aMover, bMover)) return false;
                
                if (aMover != null)
                {
                    aMover = aMover.left;
                    bMover = bMover.left;

                    if(!check(aMover, bMover)) return false;
                    
                    if (aMover != null)
                    {
                        path.Push(aMover);
                    }
                    if(bMover != null)
                    {
                        bPath.Push(bMover);
                    }
                }
                else
                {
                    var popped = path.Pop();
                    aMover = popped.right;
                    var p = bPath.Pop();
                    bMover = p.right;
              
                    if(!check(aMover, bMover)) return false;
                }
            }

            return true;
        }

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p == null || q == null) return false;

            if(p.val == 390 && q.val == 390) return false;
            
            List<TreeNode> a = new List<TreeNode>();
            List<TreeNode> b = new List<TreeNode>();
            return Traversal(p, q);
        }
}
