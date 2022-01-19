using System;
using System.Collections.Generic;

namespace DVT_Graph_Alg
{
    class Program
    {
        static void Main(string[] args)
        {
 
            // Driver code
            var graph = new List<int[]> { new int[] { 5, 6 }, new int[] { 1, 3 }, new int[] { 2, 3 }, new int[] { 3, 6 }, new int[] { 15, 12 },
            new int [] { 5, 7 }, new int [] { 4, 5 }, new int [] { 4, 9 }, new int [] { 9, 12}, new int [] { 30, 16 }
            };

            // 1. Simple Solution Most efficient solution=> Time Complexity O(n), 2. Space Complexity O(n), n size of the List
            Console.WriteLine("Solution 1: Most efficient");
            Console.WriteLine();
            var result1 = FindNodesWithZeroAndOneParents(graph);
            Console.WriteLine($"1.a Individuals with Zero Parent:  {string.Join(",", result1.noParentNodes)}");
            Console.WriteLine($"1.b Individuals with One Parent:   {string.Join(",", result1.oneParentNodes)}");
            Console.WriteLine();
            Console.WriteLine();

            // 2. Using Graph, Abit bit more expensive than the above solution as i have to create a graph and traverse it
            Console.WriteLine("Solution 2: Using Actual Graph");
            Console.WriteLine();
            var g = new Graph();
            var result2 = g.FindNodesWithZeroAndOneParents(graph);

            Console.WriteLine($"2.a Individuals with Zero Parent:  {string.Join(",", result2[0])}");
            Console.WriteLine($"2.b Individuals with One Parent:  {string.Join(",", result2[1])}");
        }

        public static NodeWithZeroAndOneParent FindNodesWithZeroAndOneParents(List<int[]> graph)
        {
            var oneParentNode = new HashSet<int>();
            var allParents = new HashSet<int>();
            var childrenNoparent = new Dictionary<int, int>();

            foreach (var nodes in graph)
            {
                var parent = nodes[0];
                var child = nodes[1];
                // Add child and parent occurrence
                if (childrenNoparent.ContainsKey(child))
                {
                    childrenNoparent[child] += 1;
                }
                else
                {
                    childrenNoparent[child] = 1;
                }

                // Add parent
                allParents.Add(parent);
            }

            // prepare the answer
            foreach (var child in childrenNoparent)
            {
                var childNode = child.Key;
                // Individuals with zero parents
                if (child.Value == 1)
                {
                    oneParentNode.Add(childNode);
                }

                //  Individuals with exactly one parent
                // will be given by all parent which are not in children set
                if (allParents.Contains(childNode))
                {
                    allParents.Remove(childNode);
                }
            }

            return new NodeWithZeroAndOneParent(allParents, oneParentNode);
        }
    }
}
