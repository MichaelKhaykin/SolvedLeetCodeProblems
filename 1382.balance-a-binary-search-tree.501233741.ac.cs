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
   public class Solution
    {
        public class BalancedTree
        {
            public TreeNode Root { get; set; }

            Dictionary<TreeNode, int> heightMap;

            public BalancedTree()
            {
                heightMap = new Dictionary<TreeNode, int>();
            }

            public void Add(int val)
            {
                Root = AddRecursive(Root, val);
            }

            private TreeNode AddRecursive(TreeNode parent, int val)
            {
                if (parent == null)
                {
                    var newNode = new TreeNode(val);
                    heightMap.Add(newNode, 1);
                    return newNode;
                }

                if (parent.val > val)
                {
                    parent.left = AddRecursive(parent.left, val);
                }
                else
                {
                    parent.right = AddRecursive(parent.right, val);
                }

                UpdateHeight(parent);
                return Balance(parent);
            }

            private TreeNode Balance(TreeNode node)
            {
                var leftHeight = GetHeight(node.left);
                var rightHeight = GetHeight(node.right);
                var balance = rightHeight - leftHeight;

                if (balance < -1)
                {
                    var ll = GetHeight(node.left.left);
                    var lr = GetHeight(node.left.right);
                    var leftBalance = lr - ll;

                    if (leftBalance > 0)
                    {
                        node.left = RotateLeft(node.left);
                    }

                    node = RotateRight(node);
                }
                else if (balance > 1)
                {
                    var rl = GetHeight(node.right.left);
                    var rr = GetHeight(node.right.right);
                    var rightBalance = rr - rl;

                    if (rightBalance < 0)
                    {
                        node.right = RotateRight(node.right);
                    }

                    node = RotateLeft(node);
                }

                return node;
            }

            private TreeNode RotateLeft(TreeNode current)
            {
                var pivot = current.right;
                current.right = pivot.left;
                pivot.left = current;
                UpdateHeight(current);
                return pivot;
            }

            private TreeNode RotateRight(TreeNode current)
            {
                var pivot = current.left;
                current.left = pivot.right;
                pivot.right = current;
                UpdateHeight(current);
                return pivot;
            }

            private void UpdateHeight(TreeNode node)
            {
                int leftHeight = node.left == null ? 0 : heightMap[node.left];
                int rightHeight = node.right == null ? 0 : heightMap[node.right];

                heightMap[node] = Math.Max(leftHeight, rightHeight) + 1;
            }

            private int GetHeight(TreeNode node)
            {
                if (node == null) return 0;
                return heightMap[node];
            }
        }

        public TreeNode BalanceBST(TreeNode root)
        {
            List<int> vals = new List<int>();
            GetAllNodes(root, vals);

            BalancedTree tree = new BalancedTree();
            for (int i = 0; i < vals.Count; i++)
            {
                tree.Add(vals[i]);
            }

            return tree.Root;
        }

        void GetAllNodes(TreeNode root, List<int> vals)
        {
            if (root == null) return;

            GetAllNodes(root.left, vals);
            vals.Add(root.val);
            GetAllNodes(root.right, vals);
        }
    }
