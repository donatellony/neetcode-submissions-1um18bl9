# Definition for a binary tree node.
# class TreeNode:
#     def __init__(self, val=0, left=None, right=None):
#         self.val = val
#         self.left = left
#         self.right = right

class Solution:   
    def isSubtree(self, root: Optional[TreeNode], subRoot: Optional[TreeNode]) -> bool:
        if root is None:
            return subRoot is None
        if subRoot is None:
            return root is None

        q = deque()
        q.append(root)
        while(q):
            r = q.popleft()
            if r.val == subRoot.val and self.bfs(r, subRoot):
                return True
            if r.left is not None:
                q.append(r.left)
            if r.right is not None:
                q.append(r.right)
        return False
    
    def bfs(self, root: Optional[TreeNode], subRoot: Optional[TreeNode]) -> bool:
        q = deque()
        subQ = deque()
        q.append(root)
        subQ.append(subRoot)
        while q and subQ:
            if len(q) != len(subQ):
                return False
            r = q.popleft()
            sR = subQ.popleft()
            if r is None and sR is None:
                continue
            if r is None or sR is None:
                return False
            if r.val != sR.val:
                return False
            
            q.append(r.left)
            q.append(r.right)
            subQ.append(sR.left)
            subQ.append(sR.right)
            
        return len(q) == len(subQ) == 0
