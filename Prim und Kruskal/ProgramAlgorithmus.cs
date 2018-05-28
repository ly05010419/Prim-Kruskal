using namespaceStuktur;
using namespaceUtility;
using System;
using System.Collections;
using System.Collections.Generic;

namespace namespaceAlgorithmus
{
    class Algorithmus
    {
        public void zeitOfAlgorithmus(string path, String methode)
        {
            Console.WriteLine(methode);

            Algorithmus algorithmus = new Algorithmus();

            Graph graph = Parse.getGraphByFile(path);

            DateTime befor = System.DateTime.Now;

            if (methode == "Kruskal")
            {
                algorithmus.kruskal(graph);
            }
            else
            {
                algorithmus.prim(graph);
            }

            DateTime after = System.DateTime.Now;
            TimeSpan ts = after.Subtract(befor);
            Console.WriteLine("\n\n{0}s", ts.TotalSeconds);

          
        }
       

        public void prim(Graph graph)
        {

            List<Node> result = new List<Node>();
            Node node = graph.nodeList[0];
            node.weight = 0;

            while ((node = findMinNode(graph.nodeList))!=null)
            {
                //Console.WriteLine("min:" + node.id);

                foreach (Edge e in node.edgeList)
                {
                    Node n = e.endNode;
                    if (n.visited == false)
                    {
                        if (n.weight > e.weight)
                        {
                            n.weight = e.weight;
                           
                        }
                    }
                }
                node.visited = true;

            }

            double sum = 0;

            foreach (Node n in graph.nodeList)
            {
                sum = sum + n.weight;
                //Console.WriteLine(n.id + "," + n.weight);
            }
            Console.WriteLine("sum:" + sum);
        }


        public Node findMinNode(List<Node> nodeList)
        {

            Node min = null;

            foreach (Node n in nodeList)
            {
                if (n.visited == false)
                {
                    if (min == null)
                    {
                        min = n;
                    }
                    else if (n.weight < min.weight)
                    {
                        min = n;
                    }
                }
            }

            return min;

        }



        int[] father;
        int[] rank;

        public void MakeSet(int length)
        {
            father = new int[length];
            rank = new int[length];

            for (int i = 0; i < length; i++)
            {
                father[i] = i;
                rank[i] = 0;
            }
        }

        int Find_Set(int x)
        {
            int root = x;
            while (father[root] != root)
                root = father[root];
            return root;
        }

        public bool Union(int x, int y)
        {
            x = Find_Set(x);
            y = Find_Set(y);
            if (x == y) return false;
            if (rank[x] > rank[y])
            {
                father[y] = x;
            }
            else if (rank[x] < rank[y])
            {
                father[x] = y;
            }
            else
            {
                rank[y]++;
                father[x] = y;
            }
            return true;
        }


        public void kruskal(Graph graph)
        {
            List<Edge> result = new List<Edge>();

            graph.edgeList.Sort();

            MakeSet(graph.nodeList.Count);

            foreach (Edge edge in graph.edgeList)
            {
                //Console.WriteLine(edge.startNode.id + "-" + edge.endNode.id);
                if (Union(edge.startNode.id, edge.endNode.id))
                {
                    result.Add(edge);
                }
            }

            double sum = 0;
            foreach (Edge e in result)
            {
                sum = sum + e.weight;
                //Console.WriteLine(e.startNode.id + "-" + e.endNode.id);
            }

            Console.WriteLine("sum: " + sum);
        }

    }
}
