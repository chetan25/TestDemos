using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linklab
{
    class Invoice
    {
       public  int PartNumber;
       public string PartDescription;
       public int Quantity;
         public double Price;
        public Invoice(int Pnum,string Pdesc,int Quant,double price)
        {
            this.PartNumber = Pnum;
            this.PartDescription = Pdesc;
            this.Quantity = Quant;
            this.Price = price;
        }

        public string getPartDesc()
        {
            return PartDescription;
        }

        public double getPrice()
        {
            return Price;
        }
        public int getQuantity()
        {
            return Quantity;
        }
        public override string ToString()
        {
            return "PartNumber is : " + PartNumber + " , PartDescription : " + PartDescription + " , Quantiy is : " + Quantity + ", Price is :" + Price;
        }


    }

}
