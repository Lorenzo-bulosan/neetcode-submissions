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

    public int diameter = 0;

    public int DiameterOfBinaryTree(TreeNode root) {
        
        if (root == null) return 0;

        Dfs(root);

        return diameter;
    }

    // Look for height of tree - also track width
    public int Dfs(TreeNode root) {
        
        if (root == null) return 0;

        var left = Dfs(root.left);
        var right = Dfs(root.right);

        // track diameter at this level while we get the height for all
        diameter = Math.Max(diameter, left+right);

        // height of this level
        return Math.Max(left, right)+1;
    }
}
