public class Solution {
    public bool EscapeGhosts(int[][] ghosts, int[] target) {
     
        if(ghosts.Length == 0) return true;
        
        var minGhost = ghosts.Min((g) => Math.Abs(target[0] - g[0]) + Math.Abs(target[1] - g[1]));
        var me = Math.Abs(target[0]) + Math.Abs(target[1]);
        
        return me < minGhost;
    }
}
