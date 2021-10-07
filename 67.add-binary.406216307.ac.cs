public class Solution {
    public string AddBinary(string a, string b) {
        string newA = a;
            string newB = b;

            if (a.Length > b.Length)
            {
                newB = b.PadLeft(a.Length, '0');
            }
            else if (b.Length > a.Length)
            {
                newA = a.PadLeft(b.Length, '0');
            }

            Stack<char> lmao = new Stack<char>();
            char carry = '0';

            for (int i = newA.Length - 1; i >= 0; i--)
            {
                if (newA[i] == '1' && newB[i] == '1')
                {
                    lmao.Push(carry == '1' ? '1' : '0');
                    carry = '1';
                }
                else if (newA[i] == '1' && newB[i] == '0')
                {
                    lmao.Push(carry == '0' ? '1' : '0');
                }
                else if (newA[i] == '0' && newB[i] == '1')
                {
                    lmao.Push(carry == '0' ? '1' : '0');
                }
                else
                {
                    lmao.Push(carry == '0' ? '0' : '1');
                    carry = '0';
                }
            }
            if(carry == '1')
            {
                lmao.Push(carry);
            }

            string newS = "";
            while (lmao.Count > 0)
            {
                newS += lmao.Pop();
            }

            return newS;
    }
}
