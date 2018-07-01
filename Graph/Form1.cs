using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Graph
{
    public partial class Form1 : Form
    {
        Creator creator = new Creator();
        

        public Form1()
        {
            InitializeComponent();
    

        }
        public void Form1_Load(object sender, EventArgs e)
        {
            creator.Load();
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            creator.Paint(e);

        }


        private void button1_Click_1(object sender, EventArgs e)
        {
                creator.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            creator.Ser();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string result = creator.findShortestPath();
            MessageBox.Show("Time: " + result);
        }
    }
}
