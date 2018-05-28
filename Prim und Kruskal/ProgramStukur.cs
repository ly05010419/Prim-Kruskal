using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace namespaceStuktur
{

    class Graph
    {
        public List<Node> nodeList;

        public List<Edge> edgeList;

        public Graph(List<Node> nodeList, List<Edge> edgeList)
        {
            this.nodeList = nodeList;
            this.edgeList = edgeList;
        }

    }

    class Node : IComparable<Node>
    {
        public int id;

        public List<Edge> edgeList;

        public bool visited = false;

        public double weight;

        public Node(int id)
        {
            this.id = id;
            this.edgeList = new List<Edge>();
            this.weight = float.MaxValue;
        }

        public int CompareTo(Node other)
        {
            return this.weight.CompareTo(other.weight);
        }
    }

    class Edge : IComparable<Edge>
    {
        public Node endNode;
        public Node startNode;
        public double weight;

     

        public Edge(Node startNode, Node endNode, double weight)
        {
            this.startNode = startNode;
            this.endNode = endNode;
            this.weight = weight;
        }

        public int CompareTo(Edge other)
        {
           return this.weight.CompareTo(other.weight);
        }
    }

}