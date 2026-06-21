class Solution:
    def mostBooked(self, n: int, meetings: List[List[int]]) -> int:
        meetings.sort(key= lambda meet: meet[0])
        busy = [] # (timeOff, room)
        counter = [0] * n
        available = [i for i in range(n)]
        heapq.heapify(available)
        
        for start, end in meetings:
            # Release rooms that have finished before or at the current meeting start time
            while busy and busy[0][0] <= start:
                heapq.heappush(available, heapq.heappop(busy)[1])
            
            if available:
                room = heapq.heappop(available)
                counter[room] += 1
                heapq.heappush(busy, (end, room))
            else:
                # No rooms available, delay the meeting
                timeOff, room = heapq.heappop(busy)
                counter[room] += 1
                new_end = timeOff + (end - start)
                heapq.heappush(busy, (new_end, room))
        
        maxCount = -1
        maxR = -1
        for i in range(n):
            if counter[i] > maxCount:
                maxCount = counter[i]
                maxR = i
        
        return maxR
