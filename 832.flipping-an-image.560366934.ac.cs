public class Solution {
    public int[][] FlipAndInvertImage(int[][] image) {
        
        for(int i = 0; i < image.Length; i++)
        {
            for(int j = 0; j < image.Length / 2; j++)
            {
                var temp = image[i][j];
                image[i][j] = image[i][image.Length - 1 - j];
                image[i][image.Length - 1 - j] = temp;
                
                if(image[i][j] == 0)
                {
                    image[i][j] = 1;
                }
                else
                {
                    image[i][j] = 0;
                }
                
                if(image[i][image.Length - 1 - j] == 0)
                {
                    image[i][image.Length - 1 - j] = 1;
                }
                else
                {
                    image[i][image.Length - 1 - j] = 0;
                }
            }
            
            if(image.Length % 2 != 0)
            {
                if(image[i][image.Length / 2] == 0)
                {
                    image[i][image.Length / 2] = 1;
                }
                else
                {
                    image[i][image.Length / 2] = 0;
                }
            }
        }
     
        return image;
    }
}
