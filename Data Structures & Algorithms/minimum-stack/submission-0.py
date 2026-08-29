class MinStack:

    def __init__(self):
        self.stack = []

    def push(self, val: int) -> None:
        self.stack.append(val)

    def pop(self) -> None:
        del self.stack[len(self.stack)-1] # del A[i] removes element by index in list A

    def top(self) -> int:
        return self.stack[-1]

    def getMin(self) -> int:
        minimum_element = float('inf')
        for element in self.stack:
            minimum_element = min(minimum_element, element)
        return minimum_element

