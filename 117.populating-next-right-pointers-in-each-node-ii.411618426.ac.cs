/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;
    public Node next;

    public Node() {}

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val, Node _left, Node _right, Node _next) {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
    }
}
*/

public class Solution {
      
    public Node Connect(Node root) {
        if(root == null) return null;
       
        Node parent = root;
        Node child = null;
        Node childHead = null;
        
        while(parent != null)
        {
            while(parent != null)
            {
                if(parent.left != null)
                {
                    if(childHead == null) childHead = parent.left;
                    else child.next = parent.left;
                    child = parent.left;
                }
                if(parent.right != null)
                {
                    if(childHead == null) childHead = parent.right;
                    else child.next = parent.right;
                    child = parent.right;
                }   
                parent = parent.next;
            }
            
            parent = childHead;
            child = null;
            childHead = null;
        }
        
        return root;
    }
}
