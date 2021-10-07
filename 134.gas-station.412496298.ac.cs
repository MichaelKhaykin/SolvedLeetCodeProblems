public class Solution {
    public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int total = 0;
            for(int i = 0; i < gas.Length; i++)
            {
                total += gas[i] - cost[i];
            }

            if (total < 0) return -1;

            int current = gas[0];
            int newStart = 0;
            for(int i = 0; i < gas.Length; i++)
            {
                current -= cost[i];
                if(current < 0)
                {
                    newStart = i + 1;
                    current = 0;
                }
                current += gas[(i + 1) % gas.Length];
            }
            return newStart;
        }
}
