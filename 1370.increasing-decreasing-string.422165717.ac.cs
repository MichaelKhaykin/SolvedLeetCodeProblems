public class Solution {
    
    public string SortString(string s) {
        StringBuilder result = new StringBuilder();
        
        StringBuilder given = new StringBuilder(s);
        while(given.Length > 0)
        {
            var smallestInd = -1;
            var smallestChar = '{';
        
            for(int i = 0; i < given.Length; i++)
            {
                if(given[i] < smallestChar)
                {
                    smallestChar = given[i];
                    smallestInd = i;
                }
            }
            given.Remove(smallestInd, 1);
            result.Append(smallestChar);

            if(given.Length == 0) return result.ToString();
            
            do
            {
                var secondSmallestInd = -1;
                var secondSmallestChar = '{';

                for(int i = 0; i < given.Length; i++)
                {
                    if(given[i] < secondSmallestChar && given[i] > smallestChar)
                    {
                        secondSmallestChar = given[i];
                        secondSmallestInd = i;
                    }
                }

                if(secondSmallestChar == '{')
                {
                    break;
                }
                
                given.Remove(secondSmallestInd, 1);
                
                result.Append(secondSmallestChar);
                smallestChar = secondSmallestChar; 
            }while(given.Length > 0);
            
               
            if(given.Length == 0) return result.ToString();
            
            var largestInd = -1;
            var largestChar = 'A';
            
            for(int i = 0; i < given.Length; i++)
            {
                if(given[i] > largestChar)
                {
                    largestChar = given[i];
                    largestInd = i;
                }
            }
            
            given.Remove(largestInd, 1);
            result.Append(largestChar);
            
            
            if(given.Length == 0) return result.ToString();
            
            while(true)
            {
                var secondLargestInd = -1;
                var secondLargestChar = 'A';

                for(int i = 0; i < given.Length; i++)
                {
                    if(given[i] > secondLargestChar && given[i] < largestChar)
                    {
                        secondLargestChar = given[i];
                        secondLargestInd = i;
                    }
                }

                if(secondLargestChar == 'A')
                {
                    break;
                }
                
                given.Remove(secondLargestInd, 1);
                result.Append(secondLargestChar);
                largestChar = secondLargestChar;
                
                
               
                if(given.Length == 0) return result.ToString();
            }
        }
        
        
        return result.ToString();
    }
}
