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

    /*
    Path a, save nodes to dictionary
    Path b, compare if we've seen in dictionary
        if we did then keep the largest node, as we want the closest to them
    
    2logn => log n - time
    space is n where n is num of nodes

    this is BST, assume both exist, all values unique

    ---------------------

    Another plan is simple
    both exists and as we seen both will follow a similar path until they diverge
    The shorter path is where they stop at
    5->8->7
    5->8

    So traverse both at the same time i.e p&q < root etc
    And then when that stops then one of them diverged so we stop there
    */

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q){

        while(root != null){

            // check if both are less than root
            if( p.val < root.val && q.val < root.val){
                root = root.left;
            }
            // check if both are to the right than root
            else if( p.val > root.val && q.val > root.val){
                root = root.right;
            }
            else
            {
                // found disparity, p and q don't agree anymore
                // this is the LCA
                return root;
            }
        }

        // we are guaranted to have both existing in tree so this will never happen
        return null;
    }

    
}
