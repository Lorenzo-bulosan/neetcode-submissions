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

    private int _goodNodesCount = 0;

    public int GoodNodes(TreeNode root) {
        
        if (root == null) return _goodNodesCount;

        int prevVal = int.MinValue;
        Dfs(root, prevVal);

        return _goodNodesCount;
    }

    public void Dfs(TreeNode node, int prevVal){

        // base condition
        if (node == null) return;

        // main check
        if (node.val >= prevVal){
            _goodNodesCount++;
        }

        // traverse
        // value to compare is not only parent
        // as next node might be larger e.g 10->4->6 - this 6 should be a good node 
        // but if only against parent then it will be 6>=4, but thats wrong as 6 is no bigger than 10
        // so check agaist the max val of path, because if larger than max
        // then is also larger than all of the path nodes so it counts.
        Dfs(node.left, Math.Max(node.val, prevVal));
        Dfs(node.right, Math.Max(node.val, prevVal));
        return;
    }
}
