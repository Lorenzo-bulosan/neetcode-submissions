# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right

class Solution:
    def maxDepth(self, root: Optional[TreeNode]) -> int:
        
        def height(root):

            # leaf node height is 0
            if root is None:
                return 0

            # in order traversal
            leftHeight = height(root.left)
            rightHeight = height(root.right)

            # current level height + max of the two branches
            h = 1 + max(leftHeight, rightHeight)
            return h
        
        # main program
        return height(root)