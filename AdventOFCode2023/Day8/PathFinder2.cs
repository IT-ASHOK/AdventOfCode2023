/* -------------------------------------------------------------------------------------------------
   Restricted. Copyright (C) Siemens Healthcare GmbH, 2023. All rights reserved.
   ------------------------------------------------------------------------------------------------- */
   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Day8
{
    internal static class PathFinder2
    {
        internal static int GetAllPaths(char[] directions, List<Node> nodes)
        {
            var startingNodes = GetAllNodesEndingWithA(nodes);
            var endingNodes = GetAllNodesEndingWithZ(nodes);

            List<int> allPaths = new List<int>();

            foreach (var node in startingNodes)
            {
                Node currentNode = node;
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
                    if (nextNode.Name.EndsWith("Z"))
                    {
                        allPaths.Add(pathCounter);
                        break;
                    }
                    currentNode = nextNode;
                }
            }

            return CalculateLCM(allPaths);
        }

        static Node GetNode(List<Node> nodes, string nodeName)
        {
            return nodes.First(n => n.Name.Equals(nodeName));
        }


        static List<Node> GetAllNodesEndingWithA(List<Node> nodes)
        {
            return nodes.Where(n => n.Name.EndsWith("A")).ToList();
        }
        static List<Node> GetAllNodesEndingWithZ(List<Node> nodes)
        {
            return nodes.Where(n => n.Name.EndsWith("Z")).ToList();
        }

        static int CalculateLCM(List<int> numbers)
        {
            int lcm = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                lcm = CalculateLCM(lcm, numbers[i]);
            }

            return lcm;
        }

        static int CalculateLCM(int a, int b)
        {
            return Math.Abs(a * b) / CalculateGCD(a, b);
        }

        static int CalculateGCD(int a, int b)
        {
            return (int)BigInteger.GreatestCommonDivisor(a, b);
        }
    }
}
