public class Solution {
    private const string escapeStartSymbol = "[[";
    private const string escapEndSymbol = "]]";
    private const char startSymbol = '[';
    private const char endSymbol = ']';

    public string Encode(IList<string> strs) 
    {
        StringBuilder sb = new();
        foreach(var s in strs)
        {
            sb.Append(startSymbol);

            sb.Append(s.Replace(endSymbol.ToString(), escapEndSymbol));

            sb.Append(endSymbol);
        }
        return sb.ToString();
    }

    public List<string> Decode(string s) 
    {
        List<string> result = new();
        StringBuilder sb = new();
        bool isWordStarted = false;
        for(int i = 0; i < s.Length; i++)
        {
            if(s[i] == startSymbol)
            {
                if(isWordStarted)
                {
                    sb.Append(s[i]);
                    continue;
                }
                isWordStarted = true;
                continue;
            }

            if(s[i] == endSymbol)
            {
                if(i + 1 < s.Length && s[i+1] == endSymbol)
                {
                    sb.Append(s[i]);
                    continue;
                }
                isWordStarted = false;
                result.Add(sb.ToString());
                sb.Clear();
                continue;
            }

            sb.Append(s[i]);
        }
        return result;
    }
}
