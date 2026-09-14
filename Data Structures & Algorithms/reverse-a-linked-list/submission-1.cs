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
    /*
    c=a
    a=b
    b=c
    */
    public ListNode ReverseList(ListNode head) {
        
        ListNode prev = null;
        ListNode curr = head;

        var tmp = new ListNode();

        // traverse linked list
        while(curr != null){

            // save node before we severe de link
            tmp = curr.next;

            // reverse logic
            curr.next = prev;

            // traverse and move both pointers to next node
            prev = curr;
            curr = tmp; //tmp is already curr.next
        }

        // as we moved both pre,curr, curr will be out of bounds and pre will be the last node
        return prev;
    }
}
