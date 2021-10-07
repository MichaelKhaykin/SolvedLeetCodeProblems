public class MaxHeap<T>
{
    List<T> data = new List<T>();

    Comparer<T> Comparer { get; set; }

    public MaxHeap(Comparer<T> x)
    {
        Comparer = x;
    }

    public void Insert(T val)
    {
        data.Add(val);
        HeapifyUp(data.Count - 1);
    }

    public T Pop()
    {
        var rootval = data[0];
        data[0] = data[data.Count - 1];
        data.RemoveAt(data.Count - 1);
        HeapifyDown(0);

        return rootval;
    }

    private void HeapifyUp(int index)
    {
        int parent = (index - 1) / 2;

        if (index <= 0) return;

        if(Comparer.Compare(data[index], data[parent]) > 0)
        {
            var temp = data[parent];
            data[parent] = data[index];
            data[index] = temp;

            HeapifyUp(parent);
        }
    }

    private void HeapifyDown(int index)
    {
        int left = index * 2 + 1;

        if (left >= data.Count) return;

        int right = index * 2 + 2;

        if (right >= data.Count)
        {
            if (Comparer.Compare(data[left], data[index]) > 0)
            {
                var temp = data[index];
                data[index] = data[left];
                data[left] = temp;
            }
            return;
        }

        if (Comparer.Compare(data[left], data[right]) > 0 && 
            Comparer.Compare(data[left], data[index]) > 0)
        {
            var temp = data[index];
            data[index] = data[left];
            data[left] = temp;

            HeapifyDown(left);
        }
        else if (Comparer.Compare(data[right], data[index]) > 0)
        {
            var temp = data[index];
            data[index] = data[right];
            data[right] = temp;

            HeapifyDown(right);
        }
    }
}

public class Data
{
    public int Key;
    public int Occurence;
    
    public Data(int key, int occurence)
    {
        Key = key;
        Occurence = occurence;
    }
    
    public int CompareTo(Data other)
    {
        return Occurence.CompareTo(other.Occurence);
    }
}

public class Solution {
    public int[] RearrangeBarcodes(int[] barcodes) {
        
        if(barcodes.Length <= 2) return barcodes;
        
        Dictionary<int, int> occurences = new Dictionary<int, int>();
        for(int i = 0; i < barcodes.Length; i++)
        {
            if(occurences.ContainsKey(barcodes[i]))
            {
                occurences[barcodes[i]]++;
            }
            else
            {
                occurences.Add(barcodes[i], 1);
            }
        }
        
        Comparer<Data> x = Comparer<Data>.Create(new Comparison<Data>((x, y) => x.CompareTo(y)));
        
        MaxHeap<Data> heap = new MaxHeap<Data>(x);
        foreach(var item in occurences)
        {
            heap.Insert(new Data(item.Key, item.Value));
        }
        
        
        int prev = -1;
        int[] newCode = new int[barcodes.Length];
        for(int i = 0; i < newCode.Length; i++)
        {
            var head = heap.Pop();
            var second = heap.Pop();

            if(prev == head.Key)
            {
                newCode[i] = second.Key;
                second.Occurence--;
            }
            else
            {
                newCode[i] = head.Key;    
                head.Occurence--;
            }
            
            prev = newCode[i];
            heap.Insert(second);
            heap.Insert(head);
        }
        
        return newCode;
    }
}
