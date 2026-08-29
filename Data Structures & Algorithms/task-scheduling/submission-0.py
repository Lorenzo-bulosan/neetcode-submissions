class Solution:
    def leastInterval(self, tasks: List[str], n: int) -> int:
        '''
        Count all in dictionary
        Process the one with most duplicates - so Put on a max_heap to know which is the process with most left 
        When processing one check if it has to wait bit longer if not, go for next most, if theres no next most then leave it idle and update waiting time
        '''

        # count chars
        count_char = {}
        for tsk in tasks:
            if not tsk in count_char:
                count_char[tsk] = 0
            count_char[tsk] += 1

        # add to max heap
        max_heap = []
        heapq.heapify(max_heap)
        for key in count_char:
            heapq.heappush(max_heap, (-1)*count_char[key])

        time = 0
        queue = deque() # contain pair of count, idleTime
        # as long as theres something in the heap or in queue to be processed then keep ticking time
        while max_heap or queue:
            time += 1

            # process char with most counts to be efficient
            if len(max_heap)>0:
                task_left = heapq.heappop(max_heap)
                task_left += 1 # reduce the count - we are adding not subtracting because its all negative values for the max_heap, on minheap would be -1

                # put on queue to wait unless no more left of that specific task
                if task_left != 0:
                    time_to_appear_again = time+n
                    queue.append([task_left, time_to_appear_again])

            # check queue and add back to heap when time matches current time
            if len(queue)>0 and time==queue[0][1]:
                #remove from queue and add to max_heap
                task = queue.popleft() #this is already negative as the contents of the queue came from heap no need to negate
                heapq.heappush(max_heap, task[0])

        return time