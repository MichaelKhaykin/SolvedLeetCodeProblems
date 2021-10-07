public class Solution {
    public string[] FindRelativeRanks(int[] score) {
        
        var sortedScores = score.OrderBy((x) => x).ToList();
        sortedScores.Reverse();
        
        Dictionary<int, string> mapper = new Dictionary<int, string>();
        
        string[] initial = new string[] { "Gold Medal", "Silver Medal", "Bronze Medal" };
        
        for(int i = 0; i < sortedScores.Count; i++)
        {
            if(i < 3)
            {
                mapper.Add(sortedScores[i], initial[i]);
            }
            else
            {
                mapper.Add(sortedScores[i], $"{i + 1}");
            }
        }
        
        string[] result = new string[score.Length];
        for(int i = 0; i < score.Length; i++)
        {
            result[i] = mapper[score[i]];
        }
        
        return result;
    }
}
