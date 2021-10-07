public class Solution {
    
    IList<int> Generate(int n)
    {
        if(n == 1)
        {
            return new int[] { 0, 1 };
        }

        var append = (1 << (n - 1));//(int)Math.Pow(2, n - 1);
        var l = Generate(n - 1);
        var reversed = l.Reverse().Select((x) => (x | append));

        return l.Concat(reversed).ToList();
    }

    public IList<int> CircularPermutation(int n, int start)
    {
        var perm = Generate(n);
        var len = perm.Count;

        var index = perm.IndexOf(start);
        var circular = new int[len];

        for(int i = 0; i < len; i++)
        {
            circular[i] = perm[index % len];
            index++;
        }

        return circular;
    }
}
