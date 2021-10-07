public class Solution {
      
    public IList<string> FullJustify(string[] words, int maxWidth)
        {

            List<string> final = new List<string>();
            StringBuilder currentLine = new StringBuilder();
            currentLine.Append(words[0]);

            int index = 1;
            while (index < words.Length)
            {
                if (currentLine.Length + 1 + words[index].Length <= maxWidth)
                {
                    currentLine.Append(" " + words[index]);
                }
                else
                {
                    var trimmed = currentLine.ToString().Trim();
                    if (trimmed == words[index - 1])
                    {
                        while (currentLine.Length < maxWidth)
                        {
                            currentLine.Append(" ");
                        }
                        final.Add(currentLine.ToString());
                    }
                    else
                    {
                        final.Add(Justify2(currentLine.ToString(), maxWidth).ToString());
                    }
                    currentLine = new StringBuilder();
                    currentLine.Append(words[index]);
                }
                index++;
            }

            while(currentLine.Length < maxWidth)
            {
                currentLine.Append(" ");
            }
            final.Add(currentLine.ToString());

            return final;
        }

        public StringBuilder Justify(string og, int maxWidth)
        {
            var allWords = og.Split(' ');
            int index = 0;

            int totalWordLength = allWords.Select((x) => x.Length).Sum();
            int difference = maxWidth - totalWordLength;
            int spacing = (int)Math.Ceiling(difference / (float)(allWords.Length - 1));

            StringBuilder justified = new StringBuilder();
            while (index < allWords.Length)
            {
                justified.Append(allWords[index]);
                index++;

                if (index == allWords.Length) return justified;

                for (int i = 0; i < spacing && difference > 0; i++)
                {
                    if (difference < allWords.Length - index) break;

                    justified.Append(" ");
                    difference -= 1;
                }

            }

            return justified;
        }
    
    public StringBuilder Justify2(string og, int maxWidth)
        {
           var insertionsNeeded = maxWidth - og.Length;

            StringBuilder res = new StringBuilder(og);

            while (insertionsNeeded > 0)
            {
                for (int i = 0; i < res.Length; i++)
                {
                    if (res[i] == ' ')
                    {
                        res.Insert(i, ' ');
                        insertionsNeeded--;

                        if (insertionsNeeded == 0) return res;
                        
                        while (res[i] == ' ') i++;
                    }
                }
            }

            return res;
        }
}
