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
    public ListNode RotateRight(ListNode head, int k) {
        
        if(head == null || head.next == null) return head;
        
        List<int> stupid = new List<int>();
        for(var temp = head; temp != null; temp = temp.next)
        {
            stupid.Add(temp.val);
        }
        
        k %= stupid.Count;
        
        for(int i = 0; i < k; i++)
        {
            RotateRight(stupid);
        }
        
        ListNode newHead = new ListNode();
        ListNode og = newHead;
        
        for(int i = 0; i < stupid.Count; i++)
        {
            newHead.next = new ListNode(stupid[i]);
            newHead = newHead.next;
        }
        
        return og.next;
    }
    
    public void RotateRight(List<int> sequence)
    {
        var last = sequence[sequence.Count - 1];
        for(int i = sequence.Count - 1; i > 0; i--)
        {
            sequence[i] = sequence[i - 1];
        }
        sequence[0] = last;
    }
}
