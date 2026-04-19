public class Solution {
    public int CharacterReplacement(string s, int k) 
    {
        var counter = new int[26];
        int l = 0, max = 0, currLen = 0;
        for(int r = 0; r < s.Length; r++)
        {
            var rCharId = ToInt(s[r]);
            counter[rCharId]++;
            currLen++;
            while(currLen - GetMostFrequentCount(counter) > k)
            {
                var lCharId = ToInt(s[l]);
                counter[lCharId]--;
                currLen--;
                l++;
            }
            max = Math.Max(max, currLen);
        }

        return max;
    }

    // O(26) -> O(1)
    private static int GetMostFrequentCount(int[] counter)
    {
        var maxCount = 0;
        for(int i = 0; i < counter.Length; i++)
        {
            maxCount = Math.Max(maxCount, counter[i]);
        }
        return maxCount;
    }

    private static int ToInt(char c) => c - 'A';
}