# 1 2 3
# 1 -> 3

class Solution:
    def combine(self, n: int, k: int) -> List[List[int]]:
        res = []
        arr = []
        def dfs(i: int):
            if len(arr) == k:
                res.append(arr.copy())
                return
            if i > n:
                return
            # Take
            arr.append(i)
            dfs(i+1)
            # Skip
            arr.pop()
            dfs(i+1)
        dfs(1)
        return res
        