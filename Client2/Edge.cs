using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client2
{
    public class Edge
    {
        public int ID { get; set; }
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

        public bool compareEdge(Edge e)
        {
            if ((this.StartNode.ID == e.StartNode.ID && this.EndNode.ID == e.EndNode.ID)
                || (this.StartNode.ID == e.EndNode.ID) && (this.EndNode.ID == e.StartNode.ID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double computeLength()
        {
            Length = Math.Sqrt(Math.Pow(StartNode.Point.X - EndNode.Point.X, 2) + Math.Pow(StartNode.Point.Y - EndNode.Point.Y, 2));
            return Length;
        }
        public override string ToString()
        {
            return String.Format("\nEdge {0}({1}-{2}) has {3} length", ID, StartNode.getID(), EndNode.getID(), computeLength());
        }
    }
}
