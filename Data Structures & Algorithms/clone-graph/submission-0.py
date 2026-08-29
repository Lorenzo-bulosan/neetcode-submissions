"""
# Definition for a Node.
class Node:
    def __init__(self, val = 0, neighbors = None):
        self.val = val
        self.neighbors = neighbors if neighbors is not None else []
"""

class Solution:
    def cloneGraph(self, node: Optional['Node']) -> Optional['Node']:
        
        if not node: return None

        clones = {}
        q = deque()
        q.append(node)

        clones[node.val] = Node(node.val, [])
        
        while q:

            n = q.popleft()
            copy = clones[n.val]

            # check neighbors
            for i in n.neighbors:
                
                # create the neighbors if they don't exist
                if i.val not in clones:
                    clones[i.val] = Node(i.val, [])
                    q.append(i)

                # add neighbors to copy
                copy.neighbors.append(clones[i.val])

        return clones[node.val]
        

        