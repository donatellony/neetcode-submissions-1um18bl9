class Solution:
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:
        intervals.sort()
        res = []

        l, r = intervals[0]
        for start, end in intervals[1:]:
            if start > r:
                res.append([l,r])
                l = start
            r = max(r, end)
        
        res.append([l, r])
        return res
