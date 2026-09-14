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

    private bool _result = true;

    public bool IsBalanced(TreeNode root) {
        
        if(root == null) return true;

        Dfs(root);

        return _result;
    }

    public int Dfs(TreeNode node){

        if(node == null) return 0;

        var hl = Dfs(node.left);
        var hr = Dfs(node.right);

        // check if hl and hr differ > 1
        var heightDiff = Math.Abs(hl-hr);
        if(heightDiff>1) _result = false;

        // height at this level
        return Math.Max(hl,hr)+1;
    }
}
