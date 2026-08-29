# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right

class Solution:
    def diameterOfBinaryTree(self, root: Optional[TreeNode]) -> int:
        
        diameter = 0

        def dfs(root):
            nonlocal diameter

            if not root:
                return 0

            max_left = dfs(root.left)
            max_right = dfs(root.right)

            count_root = max_left + max_right
            diameter = max(diameter, count_root)

            return 1 + max(max_left, max_right)

        dfs(root)

        return diameter


        