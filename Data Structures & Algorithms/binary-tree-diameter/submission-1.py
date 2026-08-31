# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right

class Solution:
    def diameterOfBinaryTree(self, root: Optional[TreeNode]) -> int:
        
        self.maxWidth = 0

        def dfs(root):

            # handle leaf
            if root is None:
                return 0

            # traverse
            leftMost = dfs(root.left)
            rightMost = dfs(root.right)

            # add left + right and check if bigger than max width
            width = leftMost+rightMost
            self.maxWidth = max(self.maxWidth, width)

            return 1 + max(leftMost, rightMost)

        # main program
        dfs(root)
        return self.maxWidth