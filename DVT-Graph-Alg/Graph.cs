using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DVT_Graph_Alg
{
    class Graph
    {
        public class Node
        {
            public int Value { get; private set; }
            public Node(int value)
            {
                Value = value;
            }

            public override bool Equals(object obj)
            {
                return Value == ((Node)obj).Value;
            }

            public override int GetHashCode()
            {
                return Value.GetHashCode() + Value.GetHashCode();
            }
        }

        private Dictionary<int, Node> Nodes = new Dictionary<int, Node>();
        private Dictionary<Node, List<Node>> AdjacencyList = new Dictionary<Node, List<Node>>();

        private void AddNode(int value)
        {
            var node = new Node(value);
            if (!Nodes.ContainsKey(value))
            {
                Nodes.Add(value, node);
            }

            if (!AdjacencyList.ContainsKey(node))
            {
                AdjacencyList.Add(node, new List<Node>());
            }
        }

        private void AddEdge(int parent, int child)
        {
            var parentNode = Nodes[parent];
            var childNode = Nodes[child];

            AdjacencyList[childNode].Add(parentNode);
        }

        public IList<int[]> FindNodesWithZeroAndOneParents(List<int[]> parentChildPairs)
        {
            // O(n)
            foreach (var parentChild in parentChildPairs)
            {
                int parent = parentChild[0];
                int child = parentChild[1];
                AddNode(parent);
                AddNode(child);

                AddEdge(parent, child);
            }

            var childrenWithZeroParents = new HashSet<int>();
            var childrenWithOneParents = new HashSet<int>();

            // O(n)
            foreach (var childParentKvp in AdjacencyList)
            {
                if (childParentKvp.Value.Count == 0)
                {
                    childrenWithZeroParents.Add(childParentKvp.Key.Value);
                }
                else if (childParentKvp.Value.Count == 1)
                {
                    childrenWithOneParents.Add(childParentKvp.Key.Value);
                }
            }

            return new List<int[]>
            {
                childrenWithZeroParents.ToArray(),
                childrenWithOneParents.ToArray()
            };
        }
    }
}
