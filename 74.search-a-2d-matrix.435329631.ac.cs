public class Solution {
     public bool SearchMatrix(int[][] matrix, int target)
        {

            //binary search on height first

            int low = 0;
            int high = matrix.Length - 1;

            int search = -1;

            while (high >= low)
            {
                int mid = (low + high) / 2;

                if (matrix[mid][0] <= target && matrix[mid][matrix[mid].Length - 1] >= target)
                {
                    search = mid;
                    break;
                }

                if (matrix[mid][matrix[mid].Length - 1] < target)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            if (search == -1) return false;

            low = 0;
            high = matrix[search].Length - 1;

            while (high >= low)
            {
                int mid = (low + high) / 2;

                if (matrix[search][mid] == target) return true;

                if (matrix[search][mid] > target)
                {
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }
            return false;
        }
}
