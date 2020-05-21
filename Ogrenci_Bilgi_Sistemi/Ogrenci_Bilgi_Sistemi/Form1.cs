using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ogrenci_Bilgi_Sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
         





            ogrenci = new string[25, 10];
            //  ogrenci[0, 0] = "0";
           
        }

        string[,] ogrenci;

        string[] bolum;
         

        //ilk index bolum ikinci index ders
        string[,] dersler ;
       
        
       
        //ogrenciNotlar ilk index ogrenciId ikinci index ders 
        string[,] ogrenciNotlar = new string[10,2];




        private void yetkiliToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void notGörüntüleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ogrPanel.Enabled = true;
        }

        private void getirBtn_Click(object sender, EventArgs e)
        {
            ogrPBar.Value = 0;
            ogrPBar.Value = 100;
            if (ogrPBar.Value == 100)
            {
                MessageBox.Show("Veriler Getirildi");
            }

            //bolumPos.ToString() + ogrenciPos.ToString() + dersPos.ToString() + "V" + vize)
            string bolPos, ogrPos, dersPos;
            bolPos = ogrenciBolumCombobox.SelectedIndex.ToString();
            ogrPos = ogrAdSoyadCombo.SelectedIndex.ToString();
            dersPos = ogrDersCombo.SelectedIndex.ToString();

            foreach(string deger in ogrDers.Items)
            {
                string _bolPos = deger.Substring(0, 1);
                string _ogrPos = deger.Substring(1, 1);
                string _dersPos = deger.Substring(2, 1);
                string sinavTag = deger.Substring(3, 1);

                if (bolPos == _bolPos && ogrPos == _ogrPos && dersPos == _dersPos)
                {
                    if(sinavTag == "V")
                    {
                        vizeLbl.Text = deger.Substring(4);
                    }
                    else if (sinavTag == "F")
                    {
                        finalLbl.Text = deger.Substring(4);
                    }
                }

            }

            double vize, final;
            vize = Convert.ToDouble(vizeLbl.Text);
            final = Convert.ToDouble(finalLbl.Text);

            if (notCanRadio.Checked)
            {
                string bolum, ders;
                bolum = ogrenciBolumCombobox.SelectedIndex.ToString();
                ders = ogrDersCombo.SelectedIndex.ToString();
                double not = 0;
                int kisiSayisi = 0;

                string bolumid, dersid;
                foreach (string puan in ogrDers.Items)
                {
                    try
                    {
                        //bolumPos.ToString() + ogrenciPos.ToString() + dersPos.ToString() + "V" + vize
                        string _puan = puan.Substring(4);
                        double _not = Convert.ToDouble(_puan);
                        bolumid = puan.Substring(0, 1);
                        dersid = puan.Substring(2, 1);
                        if (bolum == bolumid && ders == dersid)
                        {

                            not = not + _not;
                            kisiSayisi++;
                        }
                    }
                    catch (Exception hata)
                    {

                    }

                }
                try
                {
                    double ogrVize = Convert.ToInt32(vizeLbl.Text) * 0.4;
                    double ogrFinal = Convert.ToInt32(finalLbl.Text) * 0.6;
                    double ogrOrt = ogrVize + ogrFinal;
                    double ortalama = not / kisiSayisi;
                    if (ogrOrt >= ortalama)
                    {
                        gectiKaldiLbl.Text = "Geçti";
                    }
                    else
                    {
                        gectiKaldiLbl.Text = "Kaldı";
                    }
                }
                catch (Exception err)
                {

                }

            }
            else if (notNormalRadio.Checked)
            {
                double ogrVize = Convert.ToInt32(vizeLbl.Text) * 0.4;
                 double ogrFinal = Convert.ToInt32(finalLbl.Text) * 0.6;
                      double ogrOrt = ogrVize + ogrFinal;
                if (ogrOrt >= 60)
                {
                    gectiKaldiLbl.Text = "Geçti";
                }
                else
                {
                    gectiKaldiLbl.Text = "Kaldı";
                }
            }


        }



        void ogrKayitEkle()
        {

            string adSoyad = ogrAdSoyadTxt.Text;
            string _bolum;
            int yas = (int)yasNUD.Value;
            string dersAdi = dersAdCombobox.Text;
            int _ogrenciPos; 
            //ad Ekleme Kısmı
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < ogrenci.Length; i++)
                {
                    var deger4 = ogrenciNotlar[i, j];
                    if (deger4 == null)
                    {
                        
                        break;
                    }
                    else
                    {


                    }

                }

            }



        }





        private void label9_Click(object sender, EventArgs e)
        {

        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (ekleOnayCheckbox.Checked)
            {
                button1.Image = imageList1.Images[0];
                button1.ImageAlign = ContentAlignment.MiddleLeft;
            }
            else
            {
                button1.Image = null;
            }

        }

        private void cikarOnay_Click(object sender, EventArgs e)
        {
           
           
        }

        private void _bolumRadio_CheckedChanged(object sender, EventArgs e)
        {
            _bolumAdLbl.Enabled = false;
            _bolumAdCombobox.Enabled = false;
        }

        private void _dersRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (_dersRadio.Checked)
            {
                _bolumAdLbl.Enabled = true;
                _bolumAdCombobox.Enabled = true;



            }


        }

        private void bölümEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bolumGroupBox.Enabled = true;
        }

        private void öğrenciEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yetkiliGroup.Enabled = true;
        }

        private void notGirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notPanel.Enabled = true;
        }

        private void bolumCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bolumCombobox_Click(object sender, EventArgs e)
        {
            bolumCombobox.Items.Clear();
            ogrDersEkleBolumCombobox.Items.Clear();
            foreach (string blm in bolumlerLst.Items)
            {
                bolumCombobox.Items.Add(blm);
                ogrDersEkleBolumCombobox.Items.Add(blm);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
           


        }

        private void dersAdCombobox_Click(object sender, EventArgs e)
        {
            int dr = 0;
            if(ogrDersEkleBolumCombobox.Text == "")
            {
                MessageBox.Show("Bölüm Seçiniz");
                dr = 1;
            }
            dersAdCombobox.Items.Clear();
           
            int pos = ogrDersEkleBolumCombobox.SelectedIndex;
            int dersPos = dersAdCombobox.SelectedIndex;

            foreach(string deger in derslerLst.Items)
            {   if (dr == 1)
                {
                    dr = 0;
                    break;
                }
                string karakter = Convert.ToString(deger.Substring(0,1));
                if (Convert.ToString(pos) == karakter)
                {
                    dersAdCombobox.Items.Add(deger.Substring(1));


                }
            }
          
              
            



        }

        private void bolumEkle_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                if (_bolumRadio.Checked)
                {
                    _dersAdCombo.Enabled = false;
                    _bolumAdCombobox.Enabled = true;
                    string yeniBolumAd = _adTxt.Text;
                    string bolumPos = _bolumAdCombobox.Text;
                    int deger = 0;
                    foreach (string value in bolumlerLst.Items)
                    {

                        if (value == bolumPos)
                        {

                            bolumlerLst.Items[deger] = yeniBolumAd;
                            MessageBox.Show("Bölüm Değiştirildi");
                            break;
                        }
                        deger++;
                    }
                }
               

                else if (_dersRadio.Checked)
                {
                     _dersAdCombo.Enabled = true;
                     string yeniDersAd = _adTxt.Text;
                     string dersPos = _dersAdCombo.SelectedIndex.ToString();
                    string dersAd = _dersAdCombo.Text;

                    int deger = 0;
                     foreach (string value in derslerLst.Items)
                     {
                         string pos = value.ToString().Substring(0, 1);
                         if (value == dersAd)
                         {
                             derslerLst.Items[deger] = deger + yeniDersAd;
                            MessageBox.Show("Ders Değiştirildi");
                             break;
                         }
                         deger++;
                     }
                }
            }
            else
            { 
            if(_bolumRadio.Checked == false && _dersRadio.Checked == false)
            {
                MessageBox.Show("Lütfen Bir İşlem Seçiniz");
            }
                if (_bolumRadio.Checked)
                {
                    if (_adTxt.Text == "")
                    {
                        MessageBox.Show("Bölüm Adı Giriniz");
                    }
                    else
                    {
                        string _bolumAd = _adTxt.Text;


                        bolumlerLst.Items.Add(_bolumAd);
                        string __bolum = _bolumAd.Substring(0);
                        MessageBox.Show(__bolum + " Adlı Bölüm Eklendi");
                        _adTxt.Text = "";
                        _bolumAdCombobox.Text = "";
                    }

                }

                else if (_dersRadio.Checked)
                {
                    int bolum = _bolumAdCombobox.SelectedIndex;

                    //for (int i = 0; i < 25; i++)
                    //{

                    if (_adTxt.Text == "" || _bolumAdCombobox.Text == "")
                    {
                        MessageBox.Show("Veri Girmeyi Unuttunuz");
                    }
                    else
                    {
                        string dersAd = bolum.ToString() + _adTxt.Text;
                        derslerLst.Items.Add(dersAd);
                        string _dersAd = dersAd.Substring(1);
                        MessageBox.Show(_dersAd + " Adlı Ders Başarı İle Eklendi");
                        _bolumAdCombobox.Text = "";
                        _adTxt.Text = "";
                    }


                }
            }    
        }

        private void _bolumAdCombobox_Click(object sender, EventArgs e)
        {
            _bolumAdCombobox.Items.Clear();
            foreach (string blm in bolumlerLst.Items)
            {
                _bolumAdCombobox.Items.Add(blm);
            }
        }

        private void yasNUD_ValueChanged(object sender, EventArgs e)
        {

        }



        int deger = 0;

        private void EkleBtn_Click(object sender, EventArgs e)
        {
            if (bolumCombobox.Text == "" || ogrAdSoyadTxt.Text == "" || yasNUD.Value == 0 )
            {
                MessageBox.Show("Lütfen Girilen Değerleri Kontrol Ediniz");
            }
            else
            {
                int ogrBolum = bolumCombobox.SelectedIndex;
                string ogrAd = ogrAdSoyadTxt.Text;

                int yas = (int)yasNUD.Value;
                int id = ogrenciLst.Items.Count;


                if (ekleOnayCheckbox.Checked == true)
                {

                    ogrenciLst.Items.Add(deger.ToString() + "B" + ogrBolum.ToString());
                    ogrenciLst.Items.Add(deger.ToString() + ogrBolum.ToString() + "A" + ogrAd.ToString());
                    ogrenciLst.Items.Add(deger.ToString() + "Y" + yas.ToString());
                    deger++;
                    bolumCombobox.Text = "";
                    ogrAdSoyadTxt.Text = "";
                    yasNUD.Value = 0;
                    MessageBox.Show("Öğrenci Başarı İle Eklendi");

                }
                else
                {
                    MessageBox.Show("Lütfen İşlemi Onaylayınız");
                }
            }
            
            

        }

        private void aldigiDersler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        string ogrChar, itemChar;
        private void ogrListboxGetir_Click(object sender, EventArgs e)
        {
            string  charKod;
            
            ogrenciAdSoyadLst.Items.Clear();
           foreach(string val in ogrenciLst.Items)
            {
                charKod = val.Substring(2, 1);
                //string value = val.Substring(3);
                if(charKod == "A")
                {
                    ogrenciAdSoyadLst.Items.Add(val);
                }
            }


        }

        private void öğrenciÇıkarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void ogrAdSoyadCombo_Click(object sender, EventArgs e)
        {
            ogrAdSoyadCombo.Items.Clear();
            string bolumPos = ogrenciBolumCombobox.SelectedIndex.ToString();
            foreach (string value in ogrenciLst.Items)
            {
                string charKontrol = value.Substring(1, 1);

                if (charKontrol == bolumPos)
                {
                    string bKontrol = value.Substring(2, 1);
                    if (bKontrol == "a" || bKontrol == "A")
                    {
                        string val = value.Substring(3);
                        ogrAdSoyadCombo.Items.Add(val);
                    }
                }
            }

        }

        private void cikarCombobox_Click(object sender, EventArgs e)
        {
            cikarCombobox.Items.Clear();
            foreach (string deger in ogrenciAdSoyadLst.Items)
            {
                cikarCombobox.Items.Add(deger);
            }
        }

        private void cikarCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
        private void sinavBtn_Click(object sender, EventArgs e)
        {
            if(notOgrenciBolumCombobox.Text == "" || notOgrenciAdCombobox.Text == "" || notDersAdCombobox.Text == ""|| notVizeTxt.Text =="" || notFinalTxt.Text == "")
            {
                MessageBox.Show("Bir Yada Birden Fazla Alan Boş");
            }
            else
            {
                string vize, final;
                vize = notVizeTxt.Text;
                final = notFinalTxt.Text;
                string bolumPos, ogrenciPos, dersPos;
                bolumPos = notOgrenciBolumCombobox.SelectedIndex.ToString();
                ogrenciPos = notOgrenciAdCombobox.SelectedIndex.ToString();
                dersPos = notDersAdCombobox.SelectedIndex.ToString();

                ogrDers.Items.Add(bolumPos.ToString() + ogrenciPos.ToString() + dersPos.ToString() + "V" + vize);
                ogrDers.Items.Add(bolumPos.ToString() + ogrenciPos.ToString() + dersPos.ToString() + "F" + final);

                MessageBox.Show("Not Girildi");
                notOgrenciBolumCombobox.Text = "";
                notOgrenciAdCombobox.Text = "";
                notDersAdCombobox.Text = "";
                notVizeTxt.Text = "";
                notFinalTxt.Text = "";
            }
           


        }
        string _silinecek;

        private void kayitSil_Click(object sender, EventArgs e)
        {
            if (cikarCombobox.Text == "")
            {
                MessageBox.Show("Listeyi Yenilemek İçin Getire Basın . Ardından Combobaxdan Verinizi Seçtikten Sonra Bu Tuşu Deneyin");
            }

            //ogrenciAdSoyadLst.Items.Clear();
            int loop = 0;
            for (int z = 0; z < 4; z++)
            {
                for (int i = 0; i < ogrenciLst.Items.Count; i++)
                {



                    string val = ogrenciLst.Items[i].ToString();

                    string ogrKod = cikarCombobox.Text;
                    ogrKod = ogrKod.Substring(0, 1).ToString();
                   
                    string valOgrKod = val.Substring(0, 1);
                        //  string charKod = val.Substring(2, 1);
                        string text = cikarCombobox.Text;
                        string lstText = ogrenciLst.Items[i].ToString();



                        if (ogrKod == valOgrKod || text == lstText)
                        {
                            //while (loop < 3)
                            //{



                            ogrenciLst.Items.Remove(val);

                            ogrenciAdSoyadLst.Items.Remove(val);

                            



                            //}
                        }

                   



                }
            }
            cikarCombobox.Text = "";









            //string value = val.Substring(3);






            //foreach (string val in ogrenciLst.Items)
            //{
            //    charKod = val.Substring(2, 1);
            //    string value = val.Substring(3);
            //    if (charKod == "A")
            //    {

            //    }
            //}
            //loop++;
            //}
            //loop = 0;

            /*
             * 
            string  charKod;
            
            ogrenciAdSoyadLst.Items.Clear();
           foreach(string val in ogrenciLst.Items)
            {
                charKod = val.Substring(2, 1);
                string value = val.Substring(3);
                if(charKod == "A")
                {
                    ogrenciAdSoyadLst.Items.Add(value);
                }
            }*/
        }

        private void bolumlerLst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void derslerLst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstListeleBtn_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void yetkiliGroup_Enter(object sender, EventArgs e)
        {

        }

        private void Ekle_Click(object sender, EventArgs e)
        {
           
            
                if (ogrenciAdDersEkleCombo.Text == "" || ogrDersEkleBolumCombobox.Text == "" || dersAdCombobox.Text == "")
                {
                    MessageBox.Show("Lütfen İşlemleri Kontrol Ediniz");
                }
                else
                {
                    string bolumTxt = ogrDersEkleBolumCombobox.SelectedIndex.ToString();
                    string yazi = ogrenciAdDersEkleCombo.SelectedIndex.ToString();
                    yazi = yazi + bolumTxt + dersAdCombobox.Text.ToString();
                    ogrenciLst.Items.Add(yazi);
                    ogrenciAdDersEkleCombo.Text = "";
                    ogrDersEkleBolumCombobox.Text = "";
                    dersAdCombobox.Text = "";
                    MessageBox.Show("Ders Eklendi ");
                }
            
           
            
        }

        private void ogrAdDersEkle_Combo(object sender, EventArgs e)
        {

            ogrenciAdDersEkleCombo.Items.Clear();
            
            string bolumPos = ogrDersEkleBolumCombobox.SelectedIndex.ToString();
            foreach (string value in ogrenciLst.Items)
            {
                string charKontrol = value.Substring(1, 1);

                if (charKontrol == bolumPos)
                {
                    string bKontrol = value.Substring(2, 1);
                    if (bKontrol == "a" || bKontrol == "A")
                    {
                        string val = value.Substring(3);
                        ogrenciAdDersEkleCombo.Items.Add(val);
                    }
                }
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void ogrDersEkleBolumCombobox_QueryAccessibilityHelp(object sender, QueryAccessibilityHelpEventArgs e)
        {

        }

        private void ogrPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ogrDersCombo_Click(object sender, EventArgs e)
        {
          
            ogrDersCombo.Items.Clear();
            string bolumPos = ogrenciBolumCombobox.SelectedIndex.ToString();
            foreach (string value in derslerLst.Items)
            {
                string charKontrol = value.Substring(0, 1);
                if (charKontrol == bolumPos)
                {
                    string bKontrol = value.Substring(1);
                    ogrDersCombo.Items.Add(bKontrol);

                }
            }


        }

        private void ogrenciBolumCombobox_Click(object sender, EventArgs e)
        {
            ogrenciBolumCombobox.Items.Clear();
            foreach (string blm in bolumlerLst.Items)
            {
                bolumCombobox.Items.Add(blm);
                ogrenciBolumCombobox.Items.Add(blm);
            }
        }

        private void notOgrenciBolumCombobox_Click(object sender, EventArgs e)
        {
            notOgrenciBolumCombobox.Items.Clear();
            foreach (string blm in bolumlerLst.Items)
            {
                notOgrenciBolumCombobox.Items.Add(blm);
               
            }
        }

        private void notOgrenciAdCombobox_Click(object sender, EventArgs e)
        {
              notOgrenciAdCombobox.Items.Clear();
            string bolumPos = notOgrenciBolumCombobox.SelectedIndex.ToString();
            foreach (string value in ogrenciLst.Items)
            {
                string charKontrol = value.Substring(1, 1);

                if (charKontrol == bolumPos)
                {
                    string bKontrol = value.Substring(2, 1);
                    if (bKontrol =="a" ||bKontrol == "A")
                    {
                        string val = value.Substring(3);
                        notOgrenciAdCombobox.Items.Add(val);
                    }
                }
            }

        }

        private void notDersAdCombobox_Click(object sender, EventArgs e)
        {
            notDersAdCombobox.Items.Clear();

            string bolumPos = notOgrenciBolumCombobox.SelectedIndex.ToString();
            string kulId = notOgrenciAdCombobox.SelectedIndex.ToString();
            
            foreach (string value in ogrenciLst.Items)
            {
                try
                {
                    string charKontrol = value.Substring(1, 1);
                    string chKontrol = value.Substring(2, 1).ToString();
                    string blKontrol = value.Substring(1, 1).ToString();
                    string lstKulId = value.Substring(0, 1);
                    if (lstKulId == kulId && charKontrol != "B" && charKontrol != "Y" && chKontrol != "A" && blKontrol == bolumPos)
                    {

                        string bKontrol = value.Substring(2);
                        notDersAdCombobox.Items.Add(bKontrol);


                    }
                }
                catch(Exception err)
                { 
}



            }

         
        }

        private void canRadio_CheckedChanged(object sender, EventArgs e)
        {
          
           
        }

        private void normalRadio_CheckedChanged(object sender, EventArgs e)
        {
           
            
        }
        
        private void notFinalTxt_TextChanged(object sender, EventArgs e)
        {
        

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                if (_bolumRadio.Checked)
                {
                    _dersAdCombo.Enabled = false;
                    _bolumAdCombobox.Items.Clear();
                    foreach (string value in bolumlerLst.Items)
                    {
                        _bolumAdCombobox.Items.Add(value);
                    }
                }
                else if (_dersRadio.Checked)
                {
                    _dersAdCombo.Enabled = true;
                    _dersAdCombo.Items.Clear();
                    string pos = _bolumAdCombobox.SelectedIndex.ToString();
                    foreach (string value in derslerLst.Items)
                    {

                        string dPos = value.ToString().Substring(0, 1);
                        if (pos == dPos)
                        {
                            _dersAdCombo.Items.Add(value);
                        }
                    }

                }
            }
            else
            {
                _dersAdCombo.Enabled = false;
            }
            //else if (checkBox1.Checked == false)
            //{
            //    if (_bolumRadio.Checked)
            //    {
            //        _bolumAdCombobox.Enabled = true;
            //        _dersAdCombo.Enabled = false;

            //    }
            //    else if (_dersRadio.Checked)
            //    {
            //        _bolumAdCombobox.Enabled = true;
            //        _dersAdCombo.Enabled = true;
            //    }
            //}
               
            
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                textBox1.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ogrAd = cikarCombobox.Text.ToString();
            string yeniOgrAd = textBox1.Text.ToString();
            int loop = 0;
            foreach (string value in ogrenciLst.Items)
            {
                string bolum = value.Substring(0, 1);
                string id = value.Substring(1, 1);
                string Ch = value.Substring(2, 1);
                if(ogrAd == value)
                {
                    ogrenciLst.Items[loop] = bolum + id + Ch +yeniOgrAd;
                    MessageBox.Show("Öğrenci Adı Değiştirildi");
                    break;
                }
                loop++;
            }
        }

        private void bolumGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void dersAdCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
