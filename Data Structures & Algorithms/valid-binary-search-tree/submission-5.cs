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
    public bool IsValidBST(TreeNode root) {

        return IsValid(root, int.MinValue, int.MaxValue);

    }

    public bool IsValid(TreeNode root, int min, int max){
        
        // base case
        if (root == null) return true;

        // main condition to fail --test against previous level
        // testing right node is between parent and max int
        // testing left node is between min int and parent
        if(root.val<min || root.val>max || root.val==min || root.val==max)
            return false;

        // check children
        return IsValid(root.left, min, root.val) && IsValid(root.right, root.val, max);
    }
}
