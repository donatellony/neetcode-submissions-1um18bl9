public class Solution {
    private string s;
    private List<string> wordDict;
    private bool?[] memo;
    public bool WordBreak(string s, List<string> wordDict) 
    {
        memo = new bool?[s.Length];
        this.s = s;
        this.wordDict = wordDict;
        return Dfs(0);
    }

    private bool Dfs(int i)
    {
        if(i == s.Length)
            return true;
        if(memo[i].HasValue)
            return memo[i].Value;
        
        var res = false;
        foreach(var word in wordDict)
        {
            var isWordFound = true;
            if(word.Length > s.Length - i)
                continue;
            for(int j = 0; j < word.Length; j++)
            {
                if(s[i+j] != word[j])
                {
                    isWordFound = false;
                    break;
                }
            }
            if(isWordFound)
            {
                res |= Dfs(i + word.Length);
            }
        }

        memo[i] = res;
        return res;
    }
}
