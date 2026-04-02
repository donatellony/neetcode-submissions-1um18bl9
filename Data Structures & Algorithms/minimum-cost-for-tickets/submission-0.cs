

/*

Input: days = [1,4,6,7,8,20], costs = [2,7,15]
Output: 11

At day 1 we can MINIMALLY take costs[0]
And then we may take costs[0] until current cost < costs[1]

*/


public class Solution {
    int n;
    public int MincostTickets(int[] days, int[] costs) {
        n = days.Length;

        /* Boundaries:
        i: 0 -> n (INCLUDING)

        Order:
        To know i:
        We require i+1 && i+X
        We have to know BIG before small
        */
        
        var dp = new int[n+1];
        for(int i = n - 1; i >= 0; i--)
        {
            var min = costs[0] + dp[i+1];// Take costs[0]

            int j = i; // Take costs[1]
            while (j < n && days[j] < days[i] + 7)
                j++;
            min = Math.Min(min, costs[1] + dp[j]);

            j = i; // Take costs[2]
            while (j < n && days[j] < days[i] + 30)
                j++;
            dp[i] = Math.Min(min, costs[2] + dp[j]);
        }

        return dp[0];
    }
}