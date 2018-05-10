using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaOtomasyonu
{


    // PIZZA SINIFI OLLUSTURARAK BURADA PIZZAYA AIT BUTUN OZELLIKLERI GET VE SET OZELLIKLERI ILE TUTUP VERILERI DEGERLENDIRECEĞIZ.
    class Pizza : IEnumerable
    {

        //PIZZA SINIFI NEW METHODU ILE OLUŞTURULDUGU ANDA constructur içindeki Malzemeler listesi oluşturulmuş olucak.
        public Pizza(){
            this.Malzemeler = new List<string>();
            }

        //pızzanın adı
        public string Adi { get; set; }
        //pızza fıyatının tutulacagı attribute
        public decimal Fiyat { get; set; }

        //Ebat sınıfı ise pizzanın boyutlarına gore set edilecek
        public Ebat Ebatii { get; set; }
        //pızzanın kenarı hamurunun nasıl olunacagını da aşağıdaki KenarTip İle ekliyoruz.
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
