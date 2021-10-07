public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        
        List<string> results = new List<string>();
        
        StringBuilder current = new StringBuilder();
        
        int index = 0;
        while(index < nums.Length)
        {
            current.Append(nums[index]);    
            
            if(index + 1 < nums.Length && nums[index + 1] != nums[index] + 1)
            {
                var newSb = new StringBuilder();
                string[] splits = current.ToString().Split("->");
                
                if(splits[0] != splits[splits.Length - 1])
                {
                    newSb.Append(splits[0]);
                    newSb.Append("->");
                    newSb.Append(splits[splits.Length - 1]);
                }
                else
                {
                    newSb.Append(splits[0]);
                }

                results.Add(newSb.ToString());
                current = new StringBuilder();
            }
            else if(index + 1 < nums.Length)
            {
                current.Append("->");
            }
            
            index++;
        }
        
        if(current.ToString() != "")
        {
            var newSb = new StringBuilder();
            string[] splits = current.ToString().Split("->");

            if(splits[0] != splits[splits.Length - 1])
            {
                newSb.Append(splits[0]);
                newSb.Append("->");
                newSb.Append(splits[splits.Length - 1]);
            }
            else
            {
                newSb.Append(splits[0]);
            }

            results.Add(newSb.ToString());
            current = new StringBuilder();
        }
        return results;
    }
}
