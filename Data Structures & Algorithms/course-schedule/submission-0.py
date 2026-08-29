class Solution:
    def canFinish(self, numCourses: int, prerequisites: List[List[int]]) -> bool:
        
        self.visited = set()
        self.adj = {}

        # create the adj list
        for i in range(numCourses):
            self.adj[i] = []

        for [i, j] in prerequisites:
            self.adj[i].append(j)

        #print(self.adj)

        def dfs(n):
            
            # if no prerequisites then able to complete
            if len(self.adj[n]) == 0: return True
                
            # if we find a cycle then not able to complete
            if n in self.visited: return False

            self.visited.add(n)

            for nei in self.adj[n]:
                if dfs(nei) == False: return False

            # if all nei were visited then mark current node as complete - so same as end node []
            self.adj[n] = []
            
            return True

        # dfs from all nodes and put them on visited / mark complete if all their nei are complete
        for k in self.adj:
            if not k in self.visited:
                if dfs(k) == False: return False

        return True

        

