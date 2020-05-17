/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**		  BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**			    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**			   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2019-2020 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 1.Proje/Tasarim
**				ÖĞRENCİ ADI............: AYSUN ÇAĞ YILMAZKULAŞ
**				ÖĞRENCİ NUMARASI.......: G191210373
**              DERSİN ALINDIĞI GRUP...: B
****************************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public partial class Form1 : Form
    {
        List<Bitmap> resimListesi = new List<Bitmap>();
        Random rand = new Random();

        IAtikKutusu _organikAtikKutusu;             //---Atik kutusu arayuzunden objeler olusturuldu.---//
        IAtikKutusu _kagitKutusu;
        IAtikKutusu _camKutusu;
        IAtikKutusu _metalKutusu;

        IAtik _bardak;                              //---Atik arayuzunden objeler olusturuldu.---//
        IAtik _camSise;
        IAtik _dergi;
        IAtik _domates;
        IAtik _gazete;
        IAtik _kolaKutusu;
        IAtik _salatalik;
        IAtik _salcaKutusu;

        public int puan = 0;                        //---Puan baslangicta 0, sure 60sn degerini aldi.---//
        public int sure = 60;

        public Form1()
        {
            InitializeComponent();

            _organikAtikKutusu = new OrganikAtikKutusu();           //---Atik kutusu arayuzunden olusturulan siniflardan objeler olusturuldu.---//
            _kagitKutusu = new KagitKutusu();
            _camKutusu = new CamKutusu();
            _metalKutusu = new MetalKutusu();

            _bardak = new Bardak();                                 //---Atik arayuzunden olusturulan siniflardan objeler olusturuldu.---//
            _camSise = new CamSise();
            _dergi = new Dergi();
            _domates = new Domates();
            _gazete = new Gazete();
            _kolaKutusu = new KolaKutusu();
            _salatalik = new Salatalik();
            _salcaKutusu = new SalcaKutusu();

            resimListesi.Add(Properties.Resources.bardak);          //---Resim listesine resources klasorune aktarilan resimler eklendi.---//
            resimListesi.Add(Properties.Resources.camSise);
            resimListesi.Add(Properties.Resources.coke);
            resimListesi.Add(Properties.Resources.dergi);
            resimListesi.Add(Properties.Resources.domates);
            resimListesi.Add(Properties.Resources.gazete);
            resimListesi.Add(Properties.Resources.salatalik);
            resimListesi.Add(Properties.Resources.salcaKutusu);

            btnOrganikAtik.Enabled = false;                         //---Program baslatildiginda ekleme butonlari pasif durumda---//
            btnKagit.Enabled = false;
            btnCam.Enabled = false;
            btnMetal.Enabled = false;

            btnBosaltOrganik.Enabled = false;                       //---Program baslatildiginda bosalt butonlari pasif durumda---//
            btnBosaltKagit.Enabled = false;
            btnBosaltCam.Enabled = false;
            btnBosaltMetal.Enabled = false;

            proBarOrganik.Minimum = 0;                              //---Dolulugu gosteren barlarin minimum degerlerine 0 degeri aktarildi.---//
            proBarKagit.Minimum = 0;
            proBarCam.Minimum = 0;
            proBarMetal.Minimum=0;

            proBarOrganik.Maximum = _organikAtikKutusu.Kapasite;    //---Dolulugu gosteren barlarin maximum degerlerine kapasiteleri kadar deger aktarildi.---//
            proBarKagit.Maximum = _kagitKutusu.Kapasite;
            proBarCam.Maximum = _camKutusu.Kapasite;
            proBarMetal.Maximum = _metalKutusu.Kapasite;
        }

        public void RastgeleResimSec()                  //---Listeye aktarilan resimlerin rastgele secilmesini saglayan sinif---//
        {
            int randomIndex = rand.Next(0, resimListesi.Count);

            pictureBoxAtik.Image = resimListesi[randomIndex];
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 550;                           //Program baslangici icin form degeri belirlendi.---//
            this.Height = 660;

            pictureBoxAtik.Visible = false;             //---Program basladiginda pictureBox gorunur degildir.---//
            pictureBoxAtik.BackColor = Color.MediumTurquoise;

            labelPuan.Text = puan.ToString();           //---Puan ve sure degerleri labellara aktarildi.---//
            labelSure.Text = sure.ToString();
        }

        private void btnYeniOyun_Click(object sender, EventArgs e)      //---Yeni Oyun Butonu---//
        {
            sure = 60;                                  //---Sure 60, puan 0 degeri alarak labellara aktariliyor.---//
            puan = 0;
            labelSure.Text = sure.ToString();
            labelPuan.Text = puan.ToString();

            pictureBoxAtik.Visible = true;              //---PictureBox gorunebilir duruma getiriliyor.---//
            RastgeleResimSec();                         //---Rastgele resim seciliyor.---//

            btnYeniOyun.Enabled = false;                //---Yeni oyun butonu pasif duruma getiriliyor.---//

            btnOrganikAtik.Enabled = true;              //---Ekleme butonlari aktif duruma getiriliyor.---//
            btnKagit.Enabled = true;
            btnCam.Enabled = true;
            btnMetal.Enabled = true;

            btnBosaltOrganik.Enabled = true;            //---Bosalt butonlari aktif duruma getiriliyor.---//
            btnBosaltKagit.Enabled = true;
            btnBosaltCam.Enabled = true;
            btnBosaltMetal.Enabled = true;

            timer1.Interval = 1000;                     //---Timer degerinin 1 sn olarak ayarlanmasi saglandi.---//
            timer1.Enabled = true;

            listBoxOrganik.Items.Clear();               //---Listboxlar temizleniyor.---//
            listBoxKagit.Items.Clear();
            listBoxCam.Items.Clear();
            listBoxMetal.Items.Clear();

            labelSure.BackColor = Color.CadetBlue;      //---Sure ve puan labellarinin rengi degistiriliyor.---//
            labelSure.ForeColor = Color.MintCream;
            labelPuan.BackColor = Color.CadetBlue;
            labelPuan.ForeColor = Color.MintCream;

            proBarOrganik.Value = 0;                    //---Barlardaki doluluk degerleri sifirlaniyor.---//
            proBarKagit.Value = 0;
            proBarCam.Value = 0;
            proBarMetal.Value = 0;

            _organikAtikKutusu.DoluHacim = 0;           //---Kutularin doluluk degerleri sifirlaniyor.---//
            _kagitKutusu.DoluHacim = 0;
            _camKutusu.DoluHacim = 0;
            _metalKutusu.DoluHacim = 0;
        }

        private void btnOrganikAtik_Click(object sender, EventArgs e)   //---Organik Atik Kutusuna Ekle Butonu---//
        {
            //---Eklemek icin yeterli yer varsa ve gosterilen resim ayni ise...
            if (_organikAtikKutusu.Ekle(_domates) == true && pictureBoxAtik.Image == resimListesi[4]) 
            {
                RastgeleResimSec();     //---yeni bir rastgele resim getiriliyor.---//
                listBoxOrganik.Items.Add("Domates (" + _domates.Hacim + ')');   //---listboxa atikin adi ve hacmi yazdiriliyor.---//
                puan += _domates.Hacim;     //---puan urunun hacmi kadar arttiriliyor.---//
                labelPuan.Text = puan.ToString();       //---yeni puan degeri puan labelina yazdiriliyor.---//
                _organikAtikKutusu.DoluHacim += _domates.Hacim;     //---dolu hacim degeri atikin hacmi kadar arttiriliyor.---//
                proBarOrganik.Value += _domates.Hacim;      //---Bar cubugu atikin hacmi kadar doluyor.---//
            }

            else if (_organikAtikKutusu.Ekle(_salatalik) == true && pictureBoxAtik.Image == resimListesi[6])
            {
                RastgeleResimSec();
                listBoxOrganik.Items.Add("Salatalik (" + _salatalik.Hacim + ')');
                puan += _salatalik.Hacim;
                labelPuan.Text = puan.ToString();
                _organikAtikKutusu.DoluHacim += _salatalik.Hacim;
                proBarOrganik.Value += _salatalik.Hacim;
            }
        }

        private void btnKagit_Click(object sender, EventArgs e)             //---Kagit Kutusuna Ekle Butonu---//
        {
            if (_kagitKutusu.Ekle(_dergi) == true && pictureBoxAtik.Image == resimListesi[3])
            {
                RastgeleResimSec();
                listBoxKagit.Items.Add("Dergi (" + _dergi.Hacim + ')');
                puan += _dergi.Hacim;
                labelPuan.Text = puan.ToString();
                _kagitKutusu.DoluHacim += _dergi.Hacim;
                proBarKagit.Value += _dergi.Hacim;
            }
            else if (_kagitKutusu.Ekle(_gazete) == true && pictureBoxAtik.Image == resimListesi[5])
            {
                RastgeleResimSec();
                listBoxKagit.Items.Add("Gazete (" + _gazete.Hacim + ')');
                puan += _gazete.Hacim;
                labelPuan.Text = puan.ToString();
                _kagitKutusu.DoluHacim += _gazete.Hacim;
                proBarKagit.Value += _gazete.Hacim;
            }
        }

        private void btnCam_Click(object sender, EventArgs e)           //---Cam Kutusuna Ekle Butonu---//
        {
            if (_camKutusu.Ekle(_camSise) == true && pictureBoxAtik.Image == resimListesi[1])
            {
                RastgeleResimSec();
                listBoxCam.Items.Add("Cam Sise (" + _camSise.Hacim + ')');
                puan += _camSise.Hacim;
                labelPuan.Text = puan.ToString();
                _camKutusu.DoluHacim += _camSise.Hacim;
                proBarCam.Value+= _camSise.Hacim;
            }
            else if (_camKutusu.Ekle(_bardak) == true && pictureBoxAtik.Image == resimListesi[0])
            {
                RastgeleResimSec();
                listBoxCam.Items.Add("Bardak (" + _bardak.Hacim + ')');
                puan += _bardak.Hacim;
                labelPuan.Text = puan.ToString();
                _camKutusu.DoluHacim += _bardak.Hacim;
                proBarCam.Value += _bardak.Hacim;
            }
        }

        private void btnMetal_Click(object sender, EventArgs e)         //---Metal Kutusuna Ekle Butonu---//
        {
            if (_metalKutusu.Ekle(_kolaKutusu) == true && pictureBoxAtik.Image == resimListesi[2])
            {
                RastgeleResimSec();
                listBoxMetal.Items.Add("Kola Kutusu (" + _kolaKutusu.Hacim + ')');
                puan += _kolaKutusu.Hacim;
                labelPuan.Text = puan.ToString();
                _metalKutusu.DoluHacim += _kolaKutusu.Hacim;
                proBarMetal.Value+= _kolaKutusu.Hacim;
            }
            else if (_metalKutusu.Ekle(_salcaKutusu) == true && pictureBoxAtik.Image == resimListesi[7])
            {
                RastgeleResimSec();
                listBoxMetal.Items.Add("Salca Kutusu (" + _salcaKutusu.Hacim + ')');
                puan += _salcaKutusu.Hacim;
                labelPuan.Text = puan.ToString();
                _metalKutusu.DoluHacim += _salcaKutusu.Hacim;
                proBarMetal.Value += _salcaKutusu.Hacim;
            }
        }

        private void btnBosaltOrganik_Click(object sender, EventArgs e)     //---Organik Atik Kutusu Bosalt Butonu---//
        {
            //---Bosaltma durumu saglaniyor ise (kapasitenin %75inden fazlasi dolduysa)...
            if (_organikAtikKutusu.Bosalt() == true)
            {
                puan += _organikAtikKutusu.BosaltmaPuani;   //---puan degeri kutunun bosaltma puani kadar artiyor.---//
                sure += 3;      //---sure 3 sn artiyor.---//
                labelPuan.Text = puan.ToString();       //---yeni puan degeri labela yazdiriliyor.---//
                labelSure.Text = sure.ToString();       //---yeni sure degeri labela yazdiriliyor.---//
                listBoxOrganik.Items.Clear();           //---listbox temizleniyor.---//
                _organikAtikKutusu.DoluHacim = 0;       //---dolu hacim sifirlaniyor.---//
                proBarOrganik.Value = 0;                //---bar cubugu sifirlaniyor.---//
            }
        }

        private void btnBosaltKagit_Click(object sender, EventArgs e)       //---Kagit Kutusu Bosalt Butonu---//
        {
            if (_kagitKutusu.Bosalt() == true)
            {
                puan += _kagitKutusu.BosaltmaPuani;
                sure += 3;
                labelPuan.Text = puan.ToString();
                labelSure.Text = sure.ToString();
                listBoxKagit.Items.Clear();
                _kagitKutusu.DoluHacim = 0;
                proBarKagit.Value = 0;
            }
        }

        private void btnBosaltCam_Click(object sender, EventArgs e)     //---Cam Kutusu Bosalt Butonu---//
        {
            if (_camKutusu.Bosalt() == true)
            {
                puan += _camKutusu.BosaltmaPuani;
                sure += 3;
                labelPuan.Text = puan.ToString();
                labelSure.Text = sure.ToString();
                listBoxCam.Items.Clear();
                _camKutusu.DoluHacim = 0;
                proBarCam.Value = 0;
            }
        }

        private void btnBosaltMetal_Click(object sender, EventArgs e)       //---Metal Kutusu Bosalt Butonu---//
        {
            if (_metalKutusu.Bosalt() == true)
            {
                puan += _metalKutusu.BosaltmaPuani;
                sure += 3;
                labelPuan.Text = puan.ToString();
                labelSure.Text = sure.ToString();
                listBoxMetal.Items.Clear();
                _metalKutusu.DoluHacim = 0;
                proBarMetal.Value = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)        ///---Sure icin olusturulan timer---//
        {
            sure--;
            labelSure.Text = sure.ToString();       //---Sure 1er 1er azaltilip her saniyede label degistiriliyor.---//


            if (labelSure.Text == 0.ToString())         //---Sure 0 oldugunda...---//
            {
                timer1.Stop();                              //---Timer duruyor.---//

                btnYeniOyun.Enabled = true;                 //---Yeni oyun butonu aktif duruma getiriliyor.---//

                btnOrganikAtik.Enabled = false;             //---Ekleme butonlari pasif duruma getiriliyor.---//
                btnKagit.Enabled = false;
                btnCam.Enabled = false;
                btnMetal.Enabled = false;

                btnBosaltOrganik.Enabled = false;           //---Bosalt butonlari pasif duruma getiriliyor.---//
                btnBosaltKagit.Enabled = false;
                btnBosaltCam.Enabled = false;
                btnBosaltMetal.Enabled = false;

                labelSure.BackColor = Color.MintCream;      //---Sure ve puan labellarinin rengi degistiriliyor.---//
                labelSure.ForeColor = Color.CadetBlue;
                labelPuan.BackColor = Color.MintCream;
                labelPuan.ForeColor = Color.CadetBlue;

                listBoxOrganik.Items.Clear();               //---Listboxlar temizleniyor.---//
                listBoxKagit.Items.Clear();
                listBoxCam.Items.Clear();
                listBoxMetal.Items.Clear();

                proBarOrganik.Value = 0;                    //---Barlardaki doluluk degerleri sifirlaniyor.---//
                proBarKagit.Value = 0;
                proBarCam.Value = 0;
                proBarMetal.Value = 0;
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)         //---Cikis Butonu---//
        {
            this.Close();
        }
    }

}

