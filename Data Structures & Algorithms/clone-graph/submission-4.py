class Solution:
    def cloneGraph(self, node: Optional['Node']) -> Optional['Node']:
        if not node:
            return None

        old_to_new = {}
        def dfs(node: 'Node') -> 'Node':
            if node in old_to_new:
                return old_to_new[node]
            res = Node(node.val)
            old_to_new[node] = res

            for nei in node.neighbors:
                res.neighbors.append(dfs(nei))
            
            return res

        return dfs(node)


