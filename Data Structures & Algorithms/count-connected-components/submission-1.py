class Solution:
    def countComponents(self, n: int, edges: List[List[int]]) -> int:
        
        # edge case: no nodes or 1 node
        if n == 0 or n==1: return n

        self.adj = {}
        connected_components = 0
        self.visited = set()

        # build an adj list
        for node in range(n):
            self.adj[node] = []
        
        # undirected graph so reflect connection in both nodes
        for n1, n2 in edges:
            self.adj[n1].append(n2)
            self.adj[n2].append(n1)

        # helper function to explore node and its connected neighbors
        def traverse(k):

            if len(self.adj[k]) == 0: return
            
            for nei in self.adj[k]:
                if nei not in self.visited:
                    self.visited.add(nei)
                    traverse(nei)

        # try traverse all nodes and track how many are connected
        for k in range(n):
            if k not in self.visited:
                self.visited.add(k)
                traverse(k)
                connected_components += 1

        return connected_components