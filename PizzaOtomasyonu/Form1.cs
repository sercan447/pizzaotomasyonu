using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // EBAT ADINDA BIR SINIF OLUŞTURDUK VE BURAYA YAPILAN PIZALARIN TÜRLERINI YAZDIK 
           /*
                BU SINIFIN AMACI TURLERINE GORE FIYAT FARKLILIKLARINI ALMAK VE ONA GORE FIYAT BELİRLEMEKTİR
                AŞAĞIDA ISE OLUŞTURMUŞ OLDUGUMUZ  "EBAT" SINIFINA PIZZA TURLERINI GIRIYORUZ  BU VERILERI COMBOBOX 'DA GOSTERMEK ICIN

             */
            Ebat kucuk = new Ebat() { Adi = "Küçük",Carpan = 1};
            Ebat orta = new Ebat { Adi = "Orta" , Carpan = 1.25};
            Ebat buyuk = new Ebat { Adi = "Büyük", Carpan =1.75 };
            Ebat mix = new Ebat() { Adi = "Mix",Carpan = 2};

            //BURDA ISE YUKARIDA GIRILEN VERILERI AŞAĞIDA COMBOBOX'A EKLENIYOR.
            cmbo_ebat.Items.Add(kucuk);
            cmbo_ebat.Items.Add(orta);
            cmbo_ebat.Items.Add(buyuk);
            cmbo_ebat.Items.Add(mix);
            
            //PIZZA ADINDA BIR SINIF OLUŞTURDUM VE BUNUN ICINE IKI TANE OZELLIGIMIZ VAR BUNLAR "PİZZA ADI" VE "FIYAT" 
            // SECILEN PIZZAYA GORE FIYATI ALINIYOR

            Pizza klasik = new Pizza() { Adi="Klasik",Fiyat=14};
            Pizza karisik = new Pizza { Adi="Karışık",Fiyat=17};
            Pizza turkish = new Pizza { Adi="Turkish",Fiyat=20};
            Pizza tuna = new Pizza() { Adi="Tuna",Fiyat=21};
            Pizza akdeniz = new Pizza { Adi="Akdeniz",Fiyat=19};
            Pizza karadneiz = new Pizza() { Adi = "Karadeniz", Fiyat = 22 };


            //AŞAĞIDA ISE YUKARIDAKI PIZZA TURLERINI LISTBOX EKLİYORUZ
            list_pizzalar.Items.Add(klasik);
            list_pizzalar.Items.Add(karisik);
            list_pizzalar.Items.Add(turkish);
            list_pizzalar.Items.Add(tuna);
            list_pizzalar.Items.Add(akdeniz);
            list_pizzalar.Items.Add(karadneiz);

            ///KEnarTip adında bir SINIF OLUŞTURDUK VE BUNUN IKITANE OZELLIGI VAR.
            //PIZZA DA EK OZELLIK DIYEBILIRIZ. BURAD PİZZANIN EKSTRA EKLENECEK OZELLIGINE GORE FIYAT FARKINI BELIRLEMEKTIR
            //ORNEGIN : ALICAGINIZ PIZZANIN İNCE KENARLI OLMASINI İSTERSENIZ BUNA EK FİYAT FARKININ OLUP OLMAMASI ICIN  GOSTERIYORSUN

   
            KenarTip ince = new KenarTip() { Adi="İnce Kenar",EkFiyat=0};
            KenarTip kalin = new KenarTip { Adi="Kalın",EkFiyat=2};

            rdb_ince.Tag = ince;
            rdb_kalin.Tag = kalin;

            
        }

        Siparis siparis;


        //HESAPLA BUTONUNA BASILDIGINDA SEÇİLEN PİZZANIN TURUNE OZELLIGINE GORE FIYATIN BELİRLENMESİ İŞLEVİNİ YERİNE GETİRİR.

        private void btn_hesapla_Click(object sender, EventArgs e)
        {
            //LISTBOXDAN SECILEN PIZZAYI AŞAGIDA CAST EDIYORUZ.
            Pizza p = (Pizza)list_pizzalar.SelectedItem;

            //  AŞAĞIDA PIZZAYA EKLENECEK BIR OZELLIK VAR ISE ONU SECIYORUZ

            p.KenarTipi =  rdb_ince.Checked ? (KenarTip)rdb_ince.Tag :(KenarTip) rdb_kalin.Tag;
            //PIZZA BOYUTUNU SECIYORUZ (KUCUK,ORTA VB.)
            p.Ebatii = (Ebat) cmbo_ebat.SelectedItem;

            //BURada ise oluşturmuş olduğumuz gruopbox içindeki checkboxlardan hangileri seçilmiş ise onları alıyoruz.
            //Malzeme seçiyoruz
            foreach(CheckBox ctrl in groupBox1.Controls)
            {
                //seçili malzemmeleri burada "Malzemeler" ismindeki Listeye ekliyoruz.
                if(ctrl.Checked)
                {
                   // MessageBox.Show(ctrl.Text);
                    p.Malzemeler.Add(ctrl.Text);
                }
            }//for

            decimal tutar = nmrc_adet.Value * p.Tutar;
            txt_tutar.Text = tutar.ToString();


            //burada ise her verilen pizza yı siparişimiz olarak görüp hesaplıyoruz.
            siparis = new Siparis();
            siparis.Pizzalar = p;
            siparis.Adet = (int) nmrc_adet.Value;
            siparis.ToplumTutar = tutar;
          
        }

        //SİPARIS OLARAK HESAPLADIGIMIZ PIZZAYI SEPETE EKLIYORUZ AŞAĞIDAKI BUTON ILE
        private void btn_sepetekle_Click(object sender, EventArgs e)
        {
            if (siparis != null)
            {
                list_siparisler.Items.Add(siparis);
            }
        }
        
        //SIPARIS ONAYLA BUTONU ISE, SIPARIS ONAYLANDIGINDA ARTIK YAPILMAYA BAŞALNICAK DEMEK OLUYOR.
        private void btn_sprs_onay_Click(object sender, EventArgs e)
        {
            decimal toplamTutar = 0;
            int adet = 0;

            foreach(Siparis sip in list_siparisler.Items)
            {
                toplamTutar += sip.Adet * sip.Pizzalar.Tutar;
                adet++;

            }

            string msj = string.Format("Toplam Siparis Adeti {0} \n Toplam Tutarınız : {1}",adet,toplamTutar);
            MessageBox.Show(msj);
        }
    }
}
