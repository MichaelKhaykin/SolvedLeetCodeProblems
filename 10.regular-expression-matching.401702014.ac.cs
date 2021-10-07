using System.Text.RegularExpressions;

public class Solution {
    
    public bool IsMatch(string s, string p) {
      bool[,] dynamictable = new bool[s.Length + 1, p.Length + 1];
            dynamictable[0, 0] = true;

            #region Init
            for (int i = 1; i < dynamictable.GetLength(1); i++)
            {
                dynamictable[0, i] = p[i - 1] == '*' ? dynamictable[0, i - 2] : false;
            }
            for (int i = 1; i < dynamictable.GetLength(0); i++)
            {
                dynamictable[i, 0] = false;
            }
            #endregion

            for (int i = 1; i < dynamictable.GetLength(0); i++)
            {
                for (int j = 1; j < dynamictable.GetLength(1); j++)
                {
                    if (s[i - 1] == p[j - 1] || p[j - 1] == '.')
                    {
                        dynamictable[i, j] = dynamictable[i - 1, j - 1];
                    }
                    else if (p[j - 1] == '*')
                    {
                        if (dynamictable[i, j - 2] == true)
                        {
                            dynamictable[i, j] = dynamictable[i, j - 2];
                        }
                        else if (s[i - 1] == p[j - 2] || p[j - 2] == '.')
                        {
                            dynamictable[i, j] = dynamictable[i - 1, j];
                        }
                    }
                }
            }

            return dynamictable[s.Length, p.Length];
    }
}
