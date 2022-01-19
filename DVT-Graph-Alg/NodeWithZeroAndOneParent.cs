using System;
using System.Collections.Generic;
using System.Text;

namespace DVT_Graph_Alg
{
    public class NodeWithZeroAndOneParent
    {
        public HashSet<int> noParentNodes;
        public HashSet<int> oneParentNodes;

        public NodeWithZeroAndOneParent(HashSet<int> noParentNodes, HashSet<int> oneParentNodes)
        {
            this.noParentNodes = noParentNodes;
            this.oneParentNodes = oneParentNodes;
        }
    }
}
