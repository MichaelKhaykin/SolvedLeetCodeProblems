public class Solution {
    public int[] RelativeSortArray(int[] arr1, int[] arr2) {
     
        List<int> left = new List<int>();
        
        HashSet<int> arr2Set = new HashSet<int>(arr2);
        
        Dictionary<int, int> map = new Dictionary<int, int>();
        for(int i = 0; i < arr1.Length; i++){
            
            if(map.ContainsKey(arr1[i])){
                map[arr1[i]]++;
            
                
                if(arr2Set.Contains(arr1[i]) == false){
                    left.Add(arr1[i]);
                }
            }
            else{
                map.Add(arr1[i], 1);
                
                if(arr2Set.Contains(arr1[i]) == false){
                    left.Add(arr1[i]);
                }
            }
            
        }
        
        int index = 0;
        
        for(int i = 0; i < arr2.Length; i++){
            
            while(map[arr2[i]] > 0){
                
                arr1[index++] = arr2[i];
                
                map[arr2[i]]--;
                
            }
            
        }
 
        left.Sort();
        
        int temp = 0;
        
        while(index < arr1.Length){
            arr1[index++] = left[temp++];
        }
        
        return arr1;
    }
}
