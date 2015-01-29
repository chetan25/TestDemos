using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace linklab
{
    public partial class Form1 : Form
    {
        List<Invoice> inv;
        public Form1()
        {
            InitializeComponent();
            createIncoice();
        }

        public void createIncoice()
        {
            inv = new List<Invoice>();
            inv.Add(new Invoice(83,"Electric Sand",7,57.98));
            inv.Add(new Invoice(24, "Power Saw", 18, 99.98));
            inv.Add(new Invoice(7, "Sleep Hammer", 11, 21.08));
            inv.Add(new Invoice(77, "Hammer", 76, 11.98));
            inv.Add(new Invoice(39, "law Mover", 3, 79.58));
            inv.Add(new Invoice(68, "Screwdriver", 106, 6.98));
            inv.Add(new Invoice(56, "Jig Saw", 21, 11.00));
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (var v in inv)
                listBox1.Items.Add(v);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IEnumerable<Invoice> d = from v in inv
                                 orderby v.PartDescription descending
                                 select v;
            List<Invoice> result = d.ToList<Invoice>();
            display(result);
        }

        private void display(List<Invoice> data)
        {
            listBox1.Items.Clear();
            foreach (var v in data)
                listBox1.Items.Add(v);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            IEnumerable<Invoice> d1 = from v in inv
                                     orderby v.Price
                                     select v;
            List<Invoice> result = d1.ToList<Invoice>();
            display(result);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IEnumerable<Invoice> d2 = from v in inv
                                      orderby v.Quantity
                                      select v;
            List<Invoice> result = d2.ToList<Invoice>();
            listBox1.Items.Clear();
            foreach (var v in result)
            {
                string des = v.getPartDesc();
                int q = v.getQuantity();
                listBox1.Items.Add("PartDescription is : "+des+ " ,Quantity is :" +q);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            IEnumerable<Invoice> d3 = from v in inv
                                      
                                      select v;
            List<Invoice> result = d3.ToList<Invoice>();
            listBox1.Items.Clear();
            foreach (var v in result)
            {
                string des = v.getPartDesc();
                int q = v.getQuantity();
                double p = v.getPrice();
                double t = q * p;
                listBox1.Items.Add("PartDescription is : " + des + " ,Invoice Total is :" + t);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            IEnumerable<Invoice> d3 = from v in inv

                                      select v;
            List<Invoice> result = d3.ToList<Invoice>();
            listBox1.Items.Clear();
            foreach (var v in result)
            {
                string des = v.getPartDesc();
                int q = v.getQuantity();
                double p = v.getPrice();
                double t = q * p;
                if (t > 200 && t < 500)
                {
                    listBox1.Items.Add("PartDescription is : " + des + " ,Invoice Total is :" + t);
                }
                
                }

        }
    }
}
