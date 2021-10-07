public class Solution {
     public int CompareVersion(string version1, string version2)
        {
            int v1Index = 0;
            int v2Index = 0;
            while (true)
            {
                string v = "";
                if (v1Index < version1.Length)
                {
                    while (v1Index < version1.Length && version1[v1Index] != '.')
                    {
                        v += version1[v1Index];
                        v1Index++;
                    }
                    v1Index++;
                }
                int num = int.Parse(v == "" ? "0" : v);

                string v2 = "";
                if (v2Index < version2.Length)
                {
                    while (v2Index < version2.Length && version2[v2Index] != '.')
                    {
                        v2 += version2[v2Index];
                        v2Index++;
                    }
                    v2Index++;
                }
                int othernum = int.Parse(v2 == "" ? "0" : v2);

                if (num < othernum) return -1;
                else if (num > othernum) return 1;
                else if (v == "" && v2 == "") return 0;
            }

            return 0;
        }
       
}
