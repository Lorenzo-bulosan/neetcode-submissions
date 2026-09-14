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
    public bool IsSubtree(TreeNode root, TreeNode subRoot) {

        // base cases
        if ( root == null ) return false;
        
        // if vals are same then check if this tree is same
        if ( root.val == subRoot.val && IsSameTree(root, subRoot)){
            return true;
        }
        else{
            // val not same so keep traversing the root
            return IsSubtree(root.left, subRoot) || IsSubtree(root.right, subRoot);
        }
    }

    public bool IsSameTree(TreeNode p, TreeNode q){

        // base cases
        if ( p == null && q == null ) return true;
        if ( p != null && q == null ) return false;
        if ( p == null && q != null ) return false;

        // main case
        // val is same so check children too
        return p.val == q.val && IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
}
