# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right

class Solution:   
    def isSubtree(self, root: Optional[TreeNode], subRoot: Optional[TreeNode]) -> bool:
        
        def is_same_tree(root, sub) -> bool:

            if root and not sub: return False
            if not root and sub: return False
            if not root and not sub: return True

            if root.val != sub.val:
                return False         

            left = is_same_tree(root.left, sub.left)
            right = is_same_tree(root.right, sub.right)
            
            return left and right


        def dfs(root, sub):

            if root and not sub: return False
            if not root and sub: return False
            if not root and not sub: return True
            
            if is_same_tree(root, sub):
                return True               

            return dfs(root.left, sub) or dfs(root.right, sub)

        return dfs(root, subRoot)




