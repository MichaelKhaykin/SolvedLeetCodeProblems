/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 */
public class Solution {
     public ListNode DetectCycle(ListNode head)
        {
            if (head == null) return null;
            if (head.next == null) return null;

            ListNode tort = head;
            ListNode prev = head;

            var positions = new Dictionary<ListNode, int>();
           
            int count = 0;
            while (tort != null)
            {
                if (positions.ContainsKey(tort))
                {
                    return tort;
                }
                positions.Add(tort, count);

                prev = tort;
                tort = tort.next;

                count++;
            }

            return null;
        }
}
