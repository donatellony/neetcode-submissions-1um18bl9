public class PrefixTree {
    private bool IsWord {get;set;} = false;
    private Dictionary<char, PrefixTree> children = new();

    public PrefixTree() {
    }
    
    public void Insert(string word) {
        var curr = this;
        foreach(var c in word)
        {
            if(curr.children.TryGetValue(c, out var child))
            {
                curr = child;
                continue;
            }
            curr.children[c] = new PrefixTree();
            curr = curr.children[c];
        }
        curr.IsWord = true;
    }
    
    public bool Search(string word) {
        var curr = this;
        foreach(var c in word)
        {
            if(curr.children.TryGetValue(c, out var child))
            {
                curr = child;
                continue;
            }
            return false;
        }
        return curr.IsWord;
    }
    
    public bool StartsWith(string prefix) {
        var curr = this;
        foreach(var c in prefix)
        {
            if(curr.children.TryGetValue(c, out var child))
            {
                curr = child;
                continue;
            }
            return false;
        }
        return true;
    }
}
