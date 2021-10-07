public class Solution {
    public string Convert(string s, int r) {
        
        if(r == 1) return s;
        
        char[,] arr = new char[r, s.Length];
            int x = 0;
            int y = 0;
            for(int i = 0; i < s.Length; i++)
            {
                arr[y, x] = s[i];
                y++;

                if(y >= r)
                {
                    if (i + 1 >= s.Length) break;

                    int moverY = y - 1;
                    int moverX = x;
                    int curr = i + 1;

                    while(moverY > 0)
                    {
                        moverY--;
                        moverX++;

                        if (curr >= s.Length) break;
                        arr[moverY, moverX] = s[curr];
                        curr++;
                    }

                    i = curr - 1;

                    y = moverY + 1;
                    x = moverX;
                }
            }

            string append = "";
            for(int i = 0; i < arr.GetLength(0); i++)
            {
                for(int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == '\0') continue;
                    append += arr[i, j];   
                }
            }

            return append;
    }
}
