class Solution:
    def orangesRotting(self, grid: List[List[int]]) -> int:
        directions = [(-1,0), (0,-1), (0,1), (1,0)]
        queue = deque()
        fresh_counter = 0

        for r in range(len(grid)):
            for c in range(len(grid[0])):
                if grid[r][c] == 2:
                    queue.append((r,c))
                elif grid[r][c] == 1:
                    fresh_counter += 1

        counter = 0
        while queue and fresh_counter > 0:
            q_size = len(queue)
            for _ in range(q_size):
                (r, c) = queue.popleft()
                for (dr, dc) in directions:
                    nr = r + dr
                    nc = c + dc
                    if nr < 0 or nc < 0 or nr >= len(grid) or nc >= len(grid[0]) or grid[nr][nc] in (0,2):
                        continue
                    grid[nr][nc] = 2
                    fresh_counter -= 1
                    queue.append((nr, nc))
            counter += 1

        return counter if fresh_counter == 0 else -1 
        