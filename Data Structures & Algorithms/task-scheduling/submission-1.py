class Solution:
    def leastInterval(self, tasks: List[str], n: int) -> int:
        count = Counter(tasks)
        heap = list(-cnt for cnt in count.values())
        heapq.heapify(heap)

        t = 0
        q = deque() # Pairs of -task, offCdTime
        while heap or q:
            t += 1
            if not heap:
                t = q[0][1]
            if heap:
                curr = heapq.heappop(heap)
                curr += 1 # Because of maxHeap having negative values
                if curr < 0:
                    q.append((curr, t + n))
            while q and q[0][1] <= t:
                heapq.heappush(heap, q.popleft()[0])
        return t