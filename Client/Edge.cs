using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Graph {
    [Serializable()]
    class Edge
    {
        public Node StartNode { get; set; }
        public Node EndNode { get; set; }
        public double Length { get; set; }
        
        public Edge()
        {

        }

        public Edge(Node start, Node end)
        {
            this.StartNode = start;
            this.EndNode = end;
        }

        public double computeLength()
        {
            Length = Math.Sqrt(Math.Pow(StartNode.Point.X - EndNode.Point.X, 2) + Math.Pow(StartNode.Point.Y - EndNode.Point.Y, 2));
            return Length;
        }
        override
        public string ToString()
        {
            Length = this.computeLength();
            return String.Format("Edge {0}-{1} has {2} length", StartNode.ToString(), EndNode.ToString(), Length);
        }
    }
}
