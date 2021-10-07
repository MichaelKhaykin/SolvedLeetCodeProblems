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
    public ListNode DeleteDuplicates(ListNode head) {
        
        Dictionary<int, int> map = new Dictionary<int, int>();
        var temp = head;
        while(temp != null)
        {
            if(map.ContainsKey(temp.val) == false)
            {
                map.Add(temp.val, 1);
            }
            else
            {
                map[temp.val]++;
            }
            temp = temp.next;
        }
        
        
        ListNode newHead = new ListNode();
        ListNode og = newHead;
        while(head != null)
        {
            while(head != null && map[head.val] > 1)
            {
                head = head.next;
            }
            
            if(head == null) break;
            
            newHead.next = new ListNode(head.val);
            newHead = newHead.next;
            head = head.next;
        }
        return og.next;
    }
}
