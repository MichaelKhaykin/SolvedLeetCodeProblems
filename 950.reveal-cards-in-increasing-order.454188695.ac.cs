public class Solution {
    public int[] DeckRevealedIncreasing(int[] deck) {
        
        var deckList = deck.ToList();
        deckList.Sort();
        
        
        Queue<int> reorder = new Queue<int>();
       for(int i = 0; i < deckList.Count; i++)
        {
            reorder.Enqueue(i);
        }
         
        int[] indicies = new int[deckList.Count];
        int ind = 0;
        while(reorder.Count > 0)
        {
            var pop = reorder.Dequeue();
            indicies[ind++] = pop;
            
            if(reorder.Count > 0)
            {
                reorder.Enqueue(reorder.Dequeue());
            }
        }
        
        int[] res = new int[deckList.Count];
        for(int i = 0; i < deck.Length; i++)
        {
           res[indicies[i]] = deckList[i];
        }
        return res;
    }
}
