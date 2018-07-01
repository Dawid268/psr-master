using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Xml.Serialization;

namespace Graph {
    [XmlSerializerAssembly]
    public class Node
    {
        public Point Point { get; set; }
        public Node()
        {

        }
            

        override
        public string ToString()
        {
            return String.Format("({0}, {1})", Point.X, Point.Y);
        }
    }
}
