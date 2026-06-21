class Solution:
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:
        intervals.sort(key=lambda pair: pair[0])
        res = []

        l, r = intervals[0]
        for i in range(1, len(intervals)):
            start, end = intervals[i]
            if start > r:
                res.append([l,r])
                l = start
            r = max(r, end)
        
        res.append([l, r])
        return res
