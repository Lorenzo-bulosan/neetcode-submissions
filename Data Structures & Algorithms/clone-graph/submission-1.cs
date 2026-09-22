/*
// Definition for a Node.
public class Node {
    public int val;
    public IList<Node> neighbors;

    public Node() {
        val = 0;
        neighbors = new List<Node>();
    }

    public Node(int _val) {
        val = _val;
        neighbors = new List<Node>();
    }

    public Node(int _val, List<Node> _neighbors) {
        val = _val;
        neighbors = _neighbors;
    }
}
*/

public class Solution {

    public Node CloneGraph(Node node) {

        if(node == null) return null;

        // helpers
        var nodeMap = new Dictionary<int, (Node, List<Node>)>();
        var nodesToProcess = new Stack<Node>();
        var seenNodes = new HashSet<Node>();
        
        // dfs to find out the child of each and record on dictionary
        nodesToProcess.Push(node);
        while(nodesToProcess.Count > 0){

            var n = nodesToProcess.Pop();

            // fail to add to hashset means duplicate i.e we've seen it before 
            // therefore skip node
            if(seenNodes.Contains(n)) continue;

            // otherwise mark new one as seen
            seenNodes.Add(n);

            // clone parent
            if (!nodeMap.ContainsKey(n.val))
                nodeMap[n.val] = (new Node(n.val), new List<Node>());

            var clone = nodeMap[n.val].Item1;

            // add all children for next iterations
            foreach(var children in n.neighbors){
                
                // clone children and add to map
                // but if node already exists as a clone you would actually clone a 2nd time - so check first
                if (!nodeMap.ContainsKey(children.val))
                {
                    nodeMap[children.val] = (new Node(children.val), new List<Node>());
                }                

                // use the clone if it existed from previous or just created now
                var childClone = nodeMap[children.val].Item1;
                nodeMap[n.val].Item2.Add(childClone);

                // add to stack the original n to process next
                nodesToProcess.Push(children);
            }
        }

        // loop through dictionary and connect the nodes with its children
        foreach (var kvp in nodeMap) // key=int, value=(p:Node, c:List<Node>)
        {
            var key = kvp.Key;
            var parentClone = kvp.Value.Item1;
            var childCloneList = kvp.Value.Item2;       

            foreach(var child in childCloneList){
                parentClone.neighbors.Add(child);
            }
        }

        return nodeMap[node.val].Item1;
    }
}
