/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
public class Codec {
    
    public StringBuilder Helper(TreeNode root, StringBuilder builder)
    {
        if(root == null){
            builder.Append("#,");
        }
        else{
            builder.Append(root.val.ToString() + ',');
            Helper(root.left, builder);
            Helper(root.right, builder);
        }
        
        return builder;
    }
    
    // Encodes a tree to a single string.
    public string serialize(TreeNode root)
    {
        return Helper(root, new StringBuilder()).ToString().Trim(',');
    }

    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data)
    {
        Queue<string> queue = new Queue<string>(data.Split(','));
        return DeBuild(queue);
    }
    
    public TreeNode DeBuild(Queue<string> queue)
    {
        if(queue.Peek() == "#"){
            queue.Dequeue();
            return null;
        }
        
        TreeNode root = new TreeNode(int.Parse(queue.Dequeue()));
        root.left = DeBuild(queue);
        root.right = DeBuild(queue);
        
        return root;
    }
}

// Your Codec object will be instantiated and called as such:
// Codec ser = new Codec();
// Codec deser = new Codec();
// TreeNode ans = deser.deserialize(ser.serialize(root));
