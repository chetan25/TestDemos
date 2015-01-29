using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xml
{
    class patient
    {

        public string patientid;
        public string status;
        public string fname;
        public string lname;
        public string phne;
        public string offc;
        public string cell;



        public patient(string id, string st, string fname, string lname,string phne,string offc,string cell)
        {
            this.patientid = id;
            this.status = st;
            this.fname = fname;
            this.lname = lname;
            this.phne = phne;
            this.cell = cell;
            this.offc = offc;
        }

        public string getfname()
        {
            return fname;
        }

        public string getid()
        {
            return patientid;
        }

        public override string ToString()
        {
            return "Patientid : " + patientid + " , Status : " + status + " ,First name is  : " + fname + " , phone is : " + phne + " , email is :" + cell + " , office is :" +offc;
        }

    }
}
