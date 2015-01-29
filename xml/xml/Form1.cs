using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using Db4objects.Db4o;
using System.IO;
namespace xml
{
    public partial class Form1 : Form
    {
        //Declaring the List object of patient type, Db4object container 
         List<patient> pat;
         const string filename = "MyData";
        
         IObjectContainer db = null;
        public Form1()
        {
            InitializeComponent();

            db = Db4oFactory.OpenFile(filename);
            this.StartPosition = FormStartPosition.CenterScreen;
            
            //defining the XDocument to load the xml file

            XDocument document = XDocument.Load("data.xml");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            //xml process to read file attributes and invoking the patient class

            XDocument document = XDocument.Load("data1.xml");
           

            pat = new List<patient>();

            string inp =(string)iptextBox.Text;

            //checking if the input is valid or not 
            if (inp == "Patient.Save")
            {

                //reading the data from xml file 
                var selectedBook = from r in document.Descendants("patient")
                                   select new
                                   {

                                       id = r.Attribute("id"),
                                       fname = r.Element("first").Value,
                                       lname = r.Element("last").Value,
                                       contact = r.Element("contacts").Value,


                                   };
                foreach (var r in selectedBook)
                {
                    string[] newid = r.id.Value.Split(',');
                    string[] cont = r.contact.Split('|');

                    //listBox1.Items.Add(newid[0]);

                    pat.Add(new patient(newid[0], newid[2], r.fname, r.lname, cont[0], cont[1], cont[2]));
                    
                    
                }

                db.Store(pat);

                //end

                listBox1.Items.Clear();
                foreach (var v in pat)
                {
                    //writing to the file 
                    try
                    {

                        using (StreamWriter writer = new StreamWriter("Example.txt", true))
                        {
                            writer.WriteLine(v);
                        }

                        MessageBox.Show("Data stored in Db and written to file");
                    }
                    catch
                    {

                        MessageBox.Show("Error writing file"); 
                    }
                }



            }
            else
            {
                MessageBox.Show("invalid input");
             
            }


        }

        ~Form1()
        {
            if (db != null)
                db.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //displaying the stored result

            IObjectSet result = db.QueryByExample(typeof(patient));

            listBox1.Items.Clear();
            listBox1.Items.Add("# of records : " + result.Count);
            foreach (object v in result)
                listBox1.Items.Add(v);
        }
    }
}
