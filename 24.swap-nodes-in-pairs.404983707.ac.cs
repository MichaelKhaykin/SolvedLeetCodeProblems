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
    public ListNode SwapPairs(ListNode head) {
        if (head == null || head.next == null) return head;

            var old = head.next;
            head.next = head.next.next;
            old.next = head;
            head = old;

            ListNode current = head.next;
            
            ListNode previous = head;
            ListNode previousPrevious = head;

            int counter = 0;

            while (current != null)
            {
                if (counter % 2 == 0 && counter != 0)
                {
                    var o = current.next;
                    
                    previous.next = current.next;
                    current.next = previous;
                    previousPrevious.next = current;

                    current = o;
                    previousPrevious = previousPrevious.next;
                    counter++;
                    continue;
                }

                previousPrevious = previous;
                previous = current;
                current = current.next;

                counter++;
            }

            return head;
    }
}
