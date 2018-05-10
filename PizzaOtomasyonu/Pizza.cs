using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonu
{
    class Pizza : IEnumerable
    {

        public Pizza(){
            this.Malzemeler = new List<string>();
            }
        public string Adi { get; set; }
        public decimal Fiyat { get; set; }

        public Ebat Ebatii { get; set; }
        public KenarTip KenarTipi { get; set; }
        public List<string> Malzemeler { get; set; }

        public decimal Tutar
        {
            get
            {
                decimal tutar = 0;
                tutar = Fiyat * (decimal)Ebatii.Carpan;
                tutar += KenarTipi.EkFiyat;
                return tutar;
            }
        }


        public override string ToString()
        {
            return this.Adi;
        }
        public IEnumerator GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
