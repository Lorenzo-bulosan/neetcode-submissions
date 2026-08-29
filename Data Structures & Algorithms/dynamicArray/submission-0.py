
class DynamicArray:

    def __init__(self, capacity: int):
        self.capacity = capacity
        self.count = 0
        self.array = [None] * capacity

    def get(self, i: int) -> int:
        # if i >= self.count:
        #     raise Exception("No elements inside array")
        return self.array[i]

    def set(self, i: int, n: int) -> None:
        self.array[i] = n

    def pushback(self, n: int) -> None:        
        if self.count == self.capacity : self.resize()

        self.array[self.count] = n #count is last element + 1 as starts with 0
        self.count += 1

    def popback(self) -> int:
        if self.count == 0: return

        result = self.array[self.count-1]
        self.array[self.count-1] = None
        self.count -= 1

        return result

    def resize(self) -> None:
        self.capacity *= 2
        biggerArray = [None]*self.capacity

        for i in range(self.count): # range starts from 0 to count-1
            biggerArray[i] = self.array[i]

        self.array = biggerArray

    def getSize(self) -> int:
        return self.count
    
    def getCapacity(self) -> int:
        return self.capacity