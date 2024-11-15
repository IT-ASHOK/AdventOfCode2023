/* -------------------------------------------------------------------------------------------------
   Restricted. Copyright (C) Siemens Healthcare GmbH, 2023. All rights reserved.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal static class PathFinder
    {
        internal static int GetAllPaths(char[] directions,List<Node> nodes)
        {
            Node currentNode = GetNode(nodes, "AAA");
            Node nextNode = null;
            int pathCounter = 0;
            int j = 0;
            while (true)
            {
                if (directions[j] == 'L')
                {
                    nextNode = GetNode(nodes, currentNode.LeftNode);
                }
                else if (directions[j] == 'R')
                {
                    nextNode = GetNode(nodes, currentNode.RightNode);
                }

                j++;
                if (j == directions.Length)
                {
                    j = 0;
                }
                pathCounter++;
                if (nextNode.Name == "ZZZ")
                {
                    return pathCounter;
                }
                currentNode = nextNode;
            }
        }

        static Node GetNode(List<Node> nodes, string nodeName)
        {
            return nodes.First(n => n.Name.Equals(nodeName));
        }
    }
}
