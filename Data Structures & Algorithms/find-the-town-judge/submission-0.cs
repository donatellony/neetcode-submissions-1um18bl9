
public class Solution {
    public int FindJudge(int n, int[][] trust) 
    {
        var incoming = new int[n + 1];
        var outgoing = new int[n + 1];
        foreach(var t in trust)
        {
            ++outgoing[t[0]];
            ++incoming[t[1]];
        }

        for(var i = 1; i <= n; i++)
        {
            if(outgoing[i] == 0 && incoming[i] == n-1)
                return i;
        }
        return -1;
    }
}