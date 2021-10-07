/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Solution {
    
       public Dictionary<TreeNode, TreeNode> Traverse(TreeNode root, TreeNode p, TreeNode q)
       {
           var parents = new Dictionary<TreeNode, TreeNode>();
           
           Stack<TreeNode> trav = new Stack<TreeNode>();
           trav.Push(root);
           
           parents.Add(root, null);
           
           while(!parents.ContainsKey(p) || !parents.ContainsKey(q))
           {
               var curr = trav.Pop();
               
               if(curr.left != null && !parents.ContainsKey(curr.left)) {
                   parents.Add(curr.left, curr);
                   trav.Push(curr.left);
               }
               
               if(curr.right != null && !parents.ContainsKey(curr.right)) {
                   parents.Add(curr.right, curr);
                   trav.Push(curr.right);
               }
           }
           
           return parents;
       }
       
        public TreeNode Helper(TreeNode root, TreeNode p, TreeNode q)
        {
            var parents = Traverse(root, p, q);
            HashSet<int> pParens = new HashSet<int>();
            while(p != null)
            {
                pParens.Add(p.val);
                p = parents[p];
            }
            
            while(!pParens.Contains(q.val)) {
                q = parents[q];
            }
            
            return q;
        }

        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            return Helper(root, p, q);
        }
}
