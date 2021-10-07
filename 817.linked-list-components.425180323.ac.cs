/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution {
    
    public class DoublyNode
    {
        public int Value;
        public DoublyNode Previous;
        public DoublyNode Next;
        
        public DoublyNode(int value, DoublyNode prev, DoublyNode next)
        {
            Value = value;
            Previous = prev;
            Next = next;
        }
    }
    
       public int NumComponents(ListNode head, int[] G)
        {
            Dictionary<int, DoublyNode> map = new Dictionary<int, DoublyNode>();
            //build 
            ListNode prev = null;
            while (head != null)
            {
                if (!map.ContainsKey(head.val))
                {
                    map.Add(head.val, new DoublyNode(head.val, null, null));
                }

                if (prev != null)
                {
                    map[head.val].Previous = map[prev.val];
                }

                if (head.next != null)
                {
                    map.Add(head.next.val, new DoublyNode(head.next.val, map[head.val], null));
                    map[head.val].Next = map[head.next.val];
                }

                prev = head;
                head = head.next;
            }

            HashSet<int> fast = new HashSet<int>(G);

            HashSet<int> seen = new HashSet<int>();

            int ans = 0;

            for (int i = 0; i < G.Length; i++)
            {
                if (seen.Contains(G[i])) continue;
                seen.Add(G[i]);

                var node = map[G[i]];

                bool prevContains = (node.Previous != null && !seen.Contains(node.Previous.Value) && fast.Contains(node.Previous.Value));
                bool nextContains = (node.Next != null && !seen.Contains(node.Next.Value) && fast.Contains(node.Next.Value));

                DoublyNode og = node;

                if (!prevContains && !nextContains)
                {
                    ans++;
                    continue;
                }

                while (nextContains)
                {
                    seen.Add(node.Next.Value);
                    node = node.Next;

                    nextContains = (node.Next != null && !seen.Contains(node.Next.Value) && fast.Contains(node.Next.Value));
                }

                node = og;

                while (prevContains)
                {
                    seen.Add(node.Previous.Value);
                    node = node.Previous;

                    prevContains = (node.Previous != null && !seen.Contains(node.Previous.Value) && fast.Contains(node.Previous.Value));
                }

                ans++;
            }

            return ans;
        }
}
