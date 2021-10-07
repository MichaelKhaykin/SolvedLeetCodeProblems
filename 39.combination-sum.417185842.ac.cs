public class Solution {
    
    List<IList<int>> returnVal = new List<IList<int>>();
    
    public void Recursive(int[] possibilites, int remain, List<int> build, int start)
    {
        if (remain < 0) return;
        if (remain == 0)
        {
            returnVal.Add(build);
        }

        for (int i = start; i < possibilites.Length; i++)
        {
            var n = new List<int>(build);
            n.Add(possibilites[i]);
            Recursive(possibilites, remain - possibilites[i], n, i);
        }
    }
    
    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        Recursive(candidates, target, new List<int>(), 0);
        return returnVal;
    }
}
