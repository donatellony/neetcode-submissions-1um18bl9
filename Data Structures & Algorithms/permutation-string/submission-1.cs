public class Solution {
    public bool CheckInclusion(string s1, string s2) 
    {
        if(s1.Length > s2.Length)
            return false;

        var initCounter = new int[26];
        foreach(var c in s1)
        {
            ++initCounter[ToIndex(c)];
        }

        var counter = new int[26];
        for(int r = 0; r < s2.Length; r++)
        {
            counter[ToIndex(s2[r])]++;
            
            if (r >= s1.Length) 
            {
                counter[ToIndex(s2[r - s1.Length])]--;
            }

            bool match = true;
            for (int i = 0; i < 26; i++) 
            {
                if (counter[i] != initCounter[i]) 
                {
                    match = false;
                    break;
                }
            }
            if (match) return true;
        }

        return false;
    }

    private static int ToIndex(char c) => c - 'a';
}
