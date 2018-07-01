using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client2
{
   public class Node
    {
        public Point Point { get; set; }
        public int ID { get; set; }

        public Node()
        {

        }

        public string getID()
        {
            return Convert.ToString(ID);
        }
        public override string ToString()
        {
            return String.Format("{0}: ({1}, {2})", ID, Point.X, Point.Y);
        }
    }
}
