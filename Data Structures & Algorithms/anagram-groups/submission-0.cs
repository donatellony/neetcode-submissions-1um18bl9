public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) 
    {
        var wordDic = new Dictionary<string, List<string>>();
        foreach(var str in strs)
        {
            var chars = str.ToCharArray();
            Array.Sort(chars);
            var key = new string(chars);
            if(wordDic.ContainsKey(key))
            {
                wordDic[key].Add(str);
                continue;
            }
            wordDic[key] = new List<string> { str };
        }

        return wordDic.Values.ToList();
    }
}
