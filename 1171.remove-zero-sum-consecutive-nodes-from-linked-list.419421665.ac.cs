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
    public ListNode RemoveZeroSumSublists(ListNode head) {
        
        if(head == null) return null;
        
        List<int> sequence = new List<int>();
        while(head != null)
        {
            if(head.val != 0)
            {
                sequence.Add(head.val);
            }
            head = head.next;
        }
        
        while(true)
        {
            bool ever = false;
            for(int i = 0; i < sequence.Count; i++)
            {
                int acc = sequence[i];
                int start = i;
                int end = -1;

                for(int j = i + 1; j < sequence.Count; j++)
                {
                    acc += sequence[j];
                    if(acc == 0) {
                        end = j;
                    }
                }     

                if(end == -1) continue;

                ever = true;
                List<int> newList = new List<int>();
                for(int x = 0; x < sequence.Count; x++)
                {
                    if(x >= start && x <= end) continue;
                    newList.Add(sequence[x]);
                }

                sequence = newList;
                i = end;
            }
            
            if(ever == false) break;
        }
        
        if(sequence.Count == 0) return null;
        ListNode lol = new ListNode(sequence[0]);
        ListNode og = lol;
        for(int i = 1; i < sequence.Count; i++)
        {
            lol.next = new ListNode(sequence[i]);
            lol = lol.next;
        }
        
        return og;
    }
}
