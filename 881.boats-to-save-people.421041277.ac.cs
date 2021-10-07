public class Solution {
    public int NumRescueBoats(int[] people, int limit) {
        
        var peopleList = people.ToList();
        peopleList.Sort();
        
        int res = 0;
        
        int i = 0;
        int j = peopleList.Count - 1;
        
        while(i <= j)
        {
            res++;
            if(peopleList[i] + peopleList[j] <= limit)
            {
                i++;
            }
            j--;
        }
        
        return res;
    }
}
