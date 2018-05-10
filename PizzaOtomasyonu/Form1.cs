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
            

            Ebat kucuk = new Ebat() { Adi = "Küçük",Carpan = 1};
            Ebat orta = new Ebat { Adi = "Orta" , Carpan = 1.25};
            Ebat buyuk = new Ebat { Adi = "Büyük", Carpan =1.75 };
            Ebat mix = new Ebat() { Adi = "Mix",Carpan = 2};

            cmbo_ebat.Items.Add(kucuk);
            cmbo_ebat.Items.Add(orta);
            cmbo_ebat.Items.Add(buyuk);
            cmbo_ebat.Items.Add(mix);

            Pizza klasik = new Pizza() { Adi="Klasik",Fiyat=14};
            Pizza karisik = new Pizza { Adi="Karışık",Fiyat=17};
            Pizza turkish = new Pizza { Adi="Turkish",Fiyat=20};
            Pizza tuna = new Pizza() { Adi="Tuna",Fiyat=21};
            Pizza akdeniz = new Pizza { Adi="Akdeniz",Fiyat=19};
            Pizza karadneiz = new Pizza() { Adi = "Karadeniz", Fiyat = 22 };

            list_pizzalar.Items.Add(klasik);
            list_pizzalar.Items.Add(karisik);
            list_pizzalar.Items.Add(turkish);
            list_pizzalar.Items.Add(tuna);
            list_pizzalar.Items.Add(akdeniz);
            list_pizzalar.Items.Add(karadneiz);

            KenarTip ince = new KenarTip() { Adi="İnce Kenar",EkFiyat=0};
            KenarTip kalin = new KenarTip { Adi="Kalın",EkFiyat=2};

            rdb_ince.Tag = ince;
            rdb_kalin.Tag = kalin;

            
        }

        Siparis siparis;

        private void btn_hesapla_Click(object sender, EventArgs e)
        {
            Pizza p = (Pizza)list_pizzalar.SelectedItem;
            p.KenarTipi =  rdb_ince.Checked ? (KenarTip)rdb_ince.Tag :(KenarTip) rdb_kalin.Tag;
            p.Ebatii = (Ebat) cmbo_ebat.SelectedItem;

            foreach(CheckBox ctrl in groupBox1.Controls)
            {
                if(ctrl.Checked)
                {
                   // MessageBox.Show(ctrl.Text);
                    p.Malzemeler.Add(ctrl.Text);
                }
            }//for

            decimal tutar = nmrc_adet.Value * p.Tutar;
            txt_tutar.Text = tutar.ToString();

            siparis = new Siparis();
            siparis.Pizzalar = p;
            siparis.Adet = (int) nmrc_adet.Value;
            siparis.ToplumTutar = tutar;
          
        }


        private void btn_sepetekle_Click(object sender, EventArgs e)
        {
            if (siparis != null)
            {
                list_siparisler.Items.Add(siparis);
            }
        }

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
