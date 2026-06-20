class Solution:
    def cloneGraph(self, node: Optional['Node']) -> Optional['Node']:
        if not node:
            return None

        old_to_new = {}
        def dfs(node: 'Node') -> 'Node':
            curr_val = node.val
            if curr_val in old_to_new:
                return old_to_new[curr_val]
            res = Node(curr_val)
            old_to_new[curr_val] = res

            for nei in node.neighbors:
                res.neighbors.append(dfs(nei))
            
            return res
            
        return dfs(node)


