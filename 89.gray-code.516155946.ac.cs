public class Solution{
     struct NumData
            {
                public long Number { get; set; }
                public int DigitCount { get; set; }
                public NumData(long number, int digitCount)
                {
                    Number = number;
                    DigitCount = digitCount;
                }
            }
            public IList<int> GrayCode(int n)
            {
                var res = Recursion(n);
                List<int> numbs = new List<int>();

                foreach (var num in res)
                {
                    numbs.Add((int)Convert.ToInt64(num.Number.ToString(), 2));
                }
                return numbs;
            }

            NumData[] Recursion(int n)
            {

                if (n == 1)
                {
                    return new NumData[] { new NumData(0, 1), new NumData(1, 1) }; ;
                }

                var previous = Recursion(n - 1);
                var reflected = Reverse(previous);

                NumData[] concat = new NumData[previous.Length * 2];
                for (int i = 0; i < previous.Length; i++)
                {
                    previous[i].DigitCount++;

                    reflected[i].Number += (long)Math.Pow(10, reflected[i].DigitCount);
                    reflected[i].DigitCount++;
                
                    concat[i] = previous[i];
                    concat[i + previous.Length] = reflected[i];
                }

                return concat;
            }

            NumData[] Reverse(NumData[] current)
            {
                NumData[] copy = new NumData[current.Length];

                for (int i = 0; i < current.Length; i++)
                {
                    copy[i] = current[current.Length - 1 - i];
                }
                return copy;
            }
}
