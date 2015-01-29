using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace localdatabaseapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'emplocalDataSet1.employee' table. You can move, or remove it, as needed.
            this.employeeTableAdapter.Fill(this.emplocalDataSet1.employee);

        }

        private void employeeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.emplocalDataSet1);

        }

        private void add_Click(object sender, EventArgs e)
        {
            this.employeeBindingSource.AddNew();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.employeeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.emplocalDataSet1);
        }

        private void remove_Click(object sender, EventArgs e)
        {
            this.employeeBindingSource.RemoveCurrent();
        }
    }
}
