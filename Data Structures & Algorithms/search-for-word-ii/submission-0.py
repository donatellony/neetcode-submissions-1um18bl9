class TrieNode:
    def __init__(self) -> None:
        self.children = {}
        self.is_word = False

class Solution:
    def findWords(self, board: List[List[str]], words: List[str]) -> List[str]:
        trie_root = TrieNode()
        for word in words:
            curr = trie_root
            for c in word:
                if c not in curr.children: curr.children[c] = TrieNode()
                curr = curr.children[c]
            curr.is_word = True

        res = set()
        rows, cols = len(board), len(board[0])
        visited = set()

        def dfs(r, c, node, word):
            if node.is_word:
                res.add(word)
                # Optimization: do not return, word could be a prefix of another

            visited.add((r, c))
            for dr, dc in [(1, 0), (0, 1), (-1, 0), (0, -1)]:
                nr, nc = r + dr, c + dc
                if 0 <= nr < rows and 0 <= nc < cols and (nr, nc) not in visited:
                    char = board[nr][nc]
                    if char in node.children:
                        dfs(nr, nc, node.children[char], word + char)
            visited.remove((r, c))

        for r in range(rows):
            for c in range(cols):
                char = board[r][c]
                if char in trie_root.children:
                    dfs(r, c, trie_root.children[char], char)

        return list(res)