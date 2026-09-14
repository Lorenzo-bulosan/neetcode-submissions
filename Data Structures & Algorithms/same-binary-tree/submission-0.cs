/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */

public class Solution {

    

    public bool IsSameTree(TreeNode p, TreeNode q) {
        
        // base case
        if(p == null && q == null) return true;

        if(p != null && q == null) return false;
        if(p == null && q != null) return false;

        // compare the head of each
        var headIsSame = p.val == q.val; // if you return true here then we never get to check children

        // traverse same children
        return headIsSame && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
