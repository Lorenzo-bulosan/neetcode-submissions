# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right

class Solution:
    def isBalanced(self, root: Optional[TreeNode]) -> bool:
        
        def height(root, h):

            # leaf node, is balance + 0 height
            if root is None:
                return (True, 0)

            leftSide = height(root.left, h)
            rightSide = height(root.right, h)

            leftBalance, leftHeight = leftSide
            rightBalance, rightHeight = rightSide

            # get tallest from each branch + current level
            currentHeight = 1 + max(leftHeight, rightHeight)
            
            # check at each current level if balance 
            isWithinOne = abs(leftHeight-rightHeight) <= 1
            isBalance = leftBalance and rightBalance and isWithinOne

            return (isBalance, currentHeight)

        # main program
        treeBalance, treeHeight = height(root, 0)
        return treeBalance
        

