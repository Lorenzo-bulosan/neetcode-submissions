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
    just do level order traversal returning nodes at each level i.e
    [1]
    [2,3]
    [4]
    [5]
    And pick the last of each as thats the first node in the right hiding all other nodes to its left
    */
    public List<int> RightSideView(TreeNode root) {
        
        if (root == null) return new List<int>();

        // Queue for BFS, Stack for DFS
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        // BFS
        var level = new List<int>();
        var allLevels = new List<List<int>>();
        var node = new TreeNode();
        var levelCount = 0;
        while(queue.Count > 0){
            
            // reset level, and process all nodes in level
            level = new List<int>();
            levelCount = queue.Count;   
            for(int i=0; i<levelCount; i++){

                node = queue.Dequeue();

                // group nodes into current level
                level.Add(node.val);

                // add all children to queue if exists
                if (node.left!=null) queue.Enqueue(node.left);
                if (node.right!=null) queue.Enqueue(node.right);
            }

            allLevels.Add(level);
        }

        // Get the last of all levels
        var result = new List<int>();
        var last = 0;
        foreach(var list in allLevels){
            last = list[list.Count-1];
            result.Add(last);
        }

        return result;
    }
}
