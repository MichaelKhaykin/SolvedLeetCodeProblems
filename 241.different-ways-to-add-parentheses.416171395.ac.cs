public class Solution {
    public List<int> Helper(string input)
        {
            List<int> res = new List<int>();

            if (int.TryParse(input, out int x))
            {
                res.Add(x);
                return res;
            }


            var span = input.AsSpan();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '+' || input[i] == '-' || input[i] == '*')
                {
                    var left = Helper(span.Slice(0, i).ToString());
                    var right = Helper(span.Slice(i + 1, input.Length - (i + 1)).ToString());

                    foreach(var l in left)
                    {
                        foreach(var r in right)
                        {
                            res.Add(input[i] == '+' ? l + r : input[i] == '-' ? l - r : input[i] == '*' ? l * r : 0);
                        }
                    }
                }
            }

            return res;
        }

        public IList<int> DiffWaysToCompute(string input)
        {
            return Helper(input);
        }
}
