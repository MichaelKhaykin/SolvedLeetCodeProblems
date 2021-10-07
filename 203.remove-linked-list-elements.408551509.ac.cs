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
    public ListNode RemoveElements(ListNode head, int val) {
        if (head == null) return null;

            bool changeMade;
            do
            {
                changeMade = false;

                var temp = head;
                var prev = head;
                while (temp.val != val)
                {
                    prev = temp;
                    temp = temp.next;

                    if(temp == null)
                    {
                        break;
                    }
                }

                if (temp != null)
                { 
                    if(prev == temp)
                    {
                        head = head.next;
                        if (head == null) return null;
                        changeMade = true;
                        continue;
                    }
                    
                    changeMade = true;
                    prev.next = temp.next;
                }

            } while (changeMade == true);

        return head;
    }
}
