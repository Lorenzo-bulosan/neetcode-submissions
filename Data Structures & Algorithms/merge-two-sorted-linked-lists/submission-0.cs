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
    create new node head
    traverse both lists with guards of null, one list might be shorter
    compare values and set as next
    continue until no nodes from either side

    h
    c
    a vs b => c->max(a,b)
    a++, b++, c++


    */
    public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
        
        // handle l1 empty
        if(list1 == null) return list2;

        // handle l2 empty
        if(list2 == null) return list1;

        // both exist - intialize first node - smallest of the two
        var curr = new ListNode();
        // smallest of the two + traverse the smallest one
        curr.next = new ListNode(Math.Min(list1.val, list2.val));
        if(list1.val <= list2.val) list1 = list1.next;
        else list2 = list2.next;

        // save the head to return
        var head = curr.next; 

        // move curr forward to the first real node
        curr = curr.next;        

        // both exist - traverse both lists 
        while(list1 != null && list2 != null){

            // traverse the smallest one
            if(list1.val <= list2.val){
                curr.next = list1;
                list1 = list1.next;
            } 
            else{
                curr.next = list2;
                list2 = list2.next;  
            }
                
            curr = curr.next;
        }

        // one list might be larger so the above loop is until the shortest one
        // so we are done sorting as the one of them doesn't have more to compare
        // the rest is just the longer list
        curr.next = list1 == null ? list2:list1;

        return head;
    }
}