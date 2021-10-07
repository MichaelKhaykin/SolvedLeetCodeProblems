public class Solution
    {
        public string FractionToDecimal(int numerator, int denominator)
        {
            checked
            {
                int sign = Math.Sign(numerator) * Math.Sign(denominator);
                if (sign == 0)
                {
                    return "0";
                }

                ulong ulNumerator = (ulong) Math.Abs((long) numerator);
                ulong ulDenominator = (ulong) Math.Abs((long) denominator);

                StringBuilder sb = new StringBuilder();

                sb.Append(ulNumerator / ulDenominator);

                if (ulNumerator % ulDenominator != 0)
                {
                    ulNumerator = ulNumerator % ulDenominator;
                    sb.Append('.');

                    IDictionary<ulong, int> mod2Index = new Dictionary<ulong, int>();

                    while (true)
                    {
                        var mod = ulNumerator % ulDenominator;
                        if (mod == 0)
                        {
                            break;
                        }

                        if (mod2Index.ContainsKey(mod))
                        {
                            sb.Insert(mod2Index[mod], '(');
                            sb.Append(')');
                            break;
                        }
                        else
                        {
                            mod2Index.Add(mod, sb.Length);
                        }

                        ulNumerator *= 10;
                        sb.Append(ulNumerator / ulDenominator);
                        ulNumerator = ulNumerator % ulDenominator;
                    }
                }

                return ((sign < 0) ? "-" : string.Empty) + sb.ToString();
            }
        }
    }
