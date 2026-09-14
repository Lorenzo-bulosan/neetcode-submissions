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

    public int _heigth = 0;

    public int MaxDepth(TreeNode root) {
        
        if(root == null) return 0;

        // helper dfs
        Dfs(root);

        return _heigth;
    }

    public int Dfs(TreeNode node){
        
        // base case
        if(node == null) return 0;

        // traverse
        var hl = Dfs(node.left);
        var hr = Dfs(node.right);

        // track tallest
        _heigth = Math.Max(hl, hr) + 1;
        return _heigth;
    }
}
