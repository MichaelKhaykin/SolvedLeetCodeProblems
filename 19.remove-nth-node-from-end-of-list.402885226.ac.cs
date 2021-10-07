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
    public ListNode RemoveNthFromEnd(ListNode head, int n) {
            if (head.next == null) return null;

            List<ListNode> second = new List<ListNode>();
            var temp = head;
            
            while(temp.next != null)
            {
                second.Add(temp);
                temp = temp.next;
            }
     
            second.Add(temp);
            //three cases
            var index = second.Count - n;
            if(index == 0)
            {
                return head.next;
            }
            else if(index == second.Count - 1)
            {
                second[second.Count - 2].next = null;
                return head;
            }
            else
            {
                second[index - 1].next = second[index + 1];
            }

            return head;
    }
}
