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
    
        public T[] Reverse<T>(T[] a)
        {
            for (int i = 0; i < a.Length / 2; i++)
            {
                var temp = a[i];
                a[i] = a[a.Length - i - 1];
                a[a.Length - i - 1] = temp;
            }
            return a;
        }
    
        public ListNode ReverseKGroup(ListNode head, int k) {
            if (head == null || head.next == null || k == 1) return head;

            ListNode[] temp = new ListNode[5000];
            int index = 0;
            for (ListNode curr = head; curr != null; curr = curr.next)
            {
                temp[index] = curr;
                index++;
            }
            ListNode[] nodes = temp.AsSpan().Slice(0, index).ToArray();

            //logic
            int lastSpot = 0;
            for (int i = 1; i <= nodes.Length; i++)
            {
                if (i % k == 0 && i != 0)
                {
                    var slice = nodes.AsSpan(lastSpot, i - lastSpot).ToArray();
                    var newarr = Reverse(slice);

                    newarr.CopyTo(nodes, lastSpot);

                    lastSpot = i;
                }
            }

            //at the end
            for (int i = 0; i < nodes.Length; i++)
            {
                if (i + 1 >= nodes.Length)
                {
                    nodes[i].next = null;
                    break;
                }
                nodes[i].next = nodes[i + 1];
            }

            return nodes[0];     
    }
}
