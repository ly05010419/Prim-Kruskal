using namespaceStuktur;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace namespaceUtility
{
    class Parse
    {
        public static Graph getGraphByFile(string path)
        {
           
            List<Node> nodeList = new List<Node>();
            List<Edge> edgeList = new List<Edge>();

            StreamReader sr = new StreamReader(path, Encoding.Default);
            String lineStr;

            int nodeCount = 0;
            while ((lineStr = sr.ReadLine()) != null)
            {
                if (nodeCount == 0)
                {
                    initNode(int.Parse(lineStr), nodeList);
                }
                else
                {
                    string[] word = Regex.Split(lineStr, "\t");

                    createEdge(int.Parse(word[0]), int.Parse(word[1]), float.Parse(word[2]), nodeList, edgeList);

                    createNode(int.Parse(word[0]), int.Parse(word[1]), float.Parse(word[2]), nodeList);
                   
                }

                nodeCount++;
            }

            Graph g = new Graph(nodeList, edgeList);

            return g;
        }

        static void initNode(int nodeCount,List<Node> nodeList) {
            for (int i = 0; i < nodeCount; i++)
            {
                Node node = new Node(i);
                nodeList.Add(node);
            }
        }
     
       

        static void createNode(int vaterIndex, int sonIndex,float weight, List<Node> nodeList)
        {
            Node vater1 = nodeList[vaterIndex];
            Node son1 = nodeList[sonIndex];
            Edge edge1 = new Edge(vater1,son1, weight);
            vater1.edgeList.Add(edge1);


            Node vater2 = nodeList[sonIndex];
            Node son2 = nodeList[vaterIndex];
            Edge edge2 = new Edge(vater2,son2, weight);
            vater2.edgeList.Add(edge2);

        }


        static void createEdge(int vaterIndex, int sonIndex, float weight, List<Node> nodeList, List<Edge> edgeList)
        {
            Node vater = nodeList[vaterIndex];
            Node son = nodeList[sonIndex];
            Edge edge = new Edge(vater,son, weight);
            edgeList.Add(edge);
        }

    }
}