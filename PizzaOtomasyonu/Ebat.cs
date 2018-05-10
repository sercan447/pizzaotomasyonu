using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonu
{
    class Ebat
    {

        public string Adi { get; set; }
        public double Carpan { get; set; }

        public override string ToString()
        {
            return this.Adi + "-" + this.Carpan;
            //return String.Format("{0} - {1} ",this,Adi,this.Carpan.ToString());
        }
    }
}
