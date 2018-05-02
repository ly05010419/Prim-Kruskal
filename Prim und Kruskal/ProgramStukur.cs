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

    class Node
    {
        public String id;

        //public List<Node> nodeList;

        public List<Edge> edgeList;

        public bool visited = false;

        public float weight;

        public Node(String id)
        {
            this.id = id;
            //this.nodeList = new List<Node>();
            this.edgeList = new List<Edge>();
            this.weight = float.MaxValue;
        }
    }

    class Edge : IComparable<Edge>
    {
        public Node endNode;
        public Node startNode;
        public float weight;

        public Edge(Node endNode, float weight)
        {
            this.endNode = endNode;

            this.weight = weight;
        }

        public Edge(Node startNode, Node endNode, float weight)
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