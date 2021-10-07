/*
// Definition for a Node.
public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
*/

public class Solution {
    public Node CopyRandomList(Node head) {
         if (head == null) return null;

            var start = new Node(head.val);
            var og = start;

            Dictionary<Node, Node> nodes = new Dictionary<Node, Node>();
            nodes.Add(head, start);

            
            while (head != null)
            {
                if (head.random != null && !nodes.ContainsKey(head.random))
                {
                    nodes.Add(head.random, new Node(head.random.val));
                }
                if (head.next != null && !nodes.ContainsKey(head.next))
                {
                    nodes.Add(head.next, new Node(head.next.val));
                }
                if (head.next != null) start.next = nodes[head.next];
                if (head.random != null) start.random = nodes[head.random];

                start = start.next;
                head = head.next;
            }

            return og;
    }
}
