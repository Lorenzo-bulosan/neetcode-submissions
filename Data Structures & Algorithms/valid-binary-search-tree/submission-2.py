# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right

class Solution:
    def isValidBST(self, root: Optional[TreeNode]) -> bool:
        

        def compare(node, left, right):

            if not node:
                return True

            if not (left < node.val and node.val < right):
                return False

            return compare(node.left, left, node.val) and compare(node.right, node.val, right)
        
        return compare(root, -1001, 1001)
