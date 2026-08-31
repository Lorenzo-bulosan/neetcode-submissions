class MinStack:

    def __init__(self):
        self.stack = []
        self.minStack = []

    def push(self, val: int) -> None:

        # add to our main stack to preserve order inserted
        self.stack.append(val)
        
        # if nothing in stack we add as its the smallest
        # if smaller than current min then add to min stack
        # tracks the min of every iteration
        if len(self.minStack) == 0:
            self.minStack.append(val)
        elif (val <= self.minStack[-1]):
            self.minStack.append(val)
            
    def pop(self) -> None:
        # remove from main stack
        val = self.stack.pop()

        # if we have pop multiple times then minStack maybe empty
        if len(self.minStack) == 0:
            return None        

        # if what we pop is one of the mins then remove from min stack
        if val == self.minStack[-1]:
            self.minStack.pop()        

    def top(self) -> int:
        return self.stack[-1]

    def getMin(self) -> int:
        if len(self.minStack) == 0:
            return 0
        return self.minStack[-1]
