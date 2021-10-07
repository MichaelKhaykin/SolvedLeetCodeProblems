public class Solution {
    public int LengthOfLastWord(string s) {
        var arr = s.Split(' ').Where((x) => x != "").ToArray();
        if(arr.Length - 1 < 0) return 0;
        return arr[arr.Length - 1].Length;
    }
}

