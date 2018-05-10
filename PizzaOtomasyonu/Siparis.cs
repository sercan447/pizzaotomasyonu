using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonu
{
    class Siparis
    {

       
        public  Pizza Pizzalar { get; set; }
        public int Adet { get; set; }
        public decimal ToplumTutar { get; set; }

        public override string ToString()
        {
            string spr = "";
            spr += Pizzalar.Ebatii.Adi + ",";
            spr += Pizzalar.Adi + ",";
            spr += Pizzalar.KenarTipi.Adi + ",";

            foreach(string mlz in Pizzalar.Malzemeler)
            {
                spr += string.Format("{0},",mlz); 
            }//fore
            //spr = spr.Remove(spr.Length -1,1);
            spr += string.Format("{0} x {1} = {2}",Adet,Pizzalar.Tutar,(Adet * Pizzalar.Tutar));

            return spr;
        }
    }
}
