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

        // guaranted to have at least 1 node so head exist always
        // next might not so stop early
        if(head.next==null) return null;

        // create a new node before head;
        var tmp = new ListNode(0, head); // save position - important when node to remove is head itself
        var prev = tmp;                  // prev will move

        // initialize fast and slow pointers
        // fast has to be n times ahead of head, leave a gap
        var slow = head;
        var fast = head;
        int gap = 0;
        while(gap<n){
            fast = fast.next;
            gap++;
        }

        // traverse both pointers normally now i.e increments of one
        // when fast reaches the end, then slow is at nth node from the end
        // this is the node to be removed, keep a track of prev
        // so you can link prev->next
        while(fast!=null){

            // traverse
            prev = prev.next;
            slow = slow.next;
            fast = fast.next;
        }

        // after exiting loop, slow is the node to delete
        prev.next = slow.next;
             
        return tmp.next;
    }
}
