using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Eklenenler
using System.Net;
using System.IO;

namespace Günlük
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //Sistem Yol
        string yol = Application.StartupPath;

        //Tarih
        DateTime dt = DateTime.Now;


        private void Form2_Load(object sender, EventArgs e)
        {
            gunlukArsivKontrol();
        }

        #region Gunluk Arsiv Klasör Kontrolü
        void gunlukArsivKontrol()
        {
            //Klasör kontrolü
            if (!Directory.Exists(yol + @"\Gunluk Arsiv"))
            {
                Directory.CreateDirectory(yol + @"\Gunluk Arsiv\");
            }
            else
            {
               // MessageBox.Show("var");
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //Buton Aktifliği
            button1.Enabled = false;
            button2.Enabled = true;

            if (richTextBox1.TextLength > 0) 
            {
                //Metin kutusunda bişey varsa
                label3.Text = String.Format("{0:dd.MM.yyyy}", dt) + " tarihli günlük.";
                DialogResult soru = MessageBox.Show(label3.Text + " tarihli günlük için değişiklikleri kaydetmek istiyor musunuz?","Günlük",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                if (soru == DialogResult.Yes)
                {
                    MessageBox.Show("Günlük kaydedildi..");
                }
                else if (soru == DialogResult.No)
                {
                    MessageBox.Show("Günlük kaydedilmedi.");
                }
                else if (soru == DialogResult.Cancel)
                {
                    MessageBox.Show("Günlük kaydetme iptal edildi..");
                }
            }
            else 
            {
                //Metin kutusunda bişey yoksa
                label3.Text = String.Format("{0:dd.MM.yyyy}", dt) + " tarihli günlük.";
                richTextBox1.ReadOnly = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (richTextBox1.TextLength > 0)
            {
                string dosyaAdi = String.Format("{0:dd.MM.yyyy}", dt);

                if (Directory.Exists(yol + @"\Gunluk Arsiv\" + dosyaAdi))
                {
                    //Klasör varsa
                    MessageBox.Show("bu tarihli günlük var");
                }
                else
                {
                    //Klasör yoksa
                    Directory.CreateDirectory(yol + @"\Gunluk Arsiv\" + dosyaAdi);

                    //Dosyayı açmaya çalış yoksa catch kısmına geç
                    try
                    {
                        StreamReader Dosya = File.OpenText(yol + @"\Gunluk Arsiv\" + dosyaAdi + @"\" + dosyaAdi + ".txt");
                        Dosya.Close();
                        try
                        {
                            //Dosyayı appendText ile yazmak için açtık
                            StreamWriter dosyaAc = File.AppendText(yol + @"\Gunluk Arsiv\" + dosyaAdi + @"\" + dosyaAdi + ".txt");

                            // Dosya.WriteLine ile dosyaya verileri ekledik.
                            dosyaAc.WriteLine("Kayıt Tarihi = " + DateTime.Now);
                            dosyaAc.WriteLine("\n");
                            dosyaAc.WriteLine(richTextBox1.Text);

                            // Dosya yı kapattık.
                            dosyaAc.Close();
                            MessageBox.Show("Günlük başarıyla kaydedildi.", "Bilgi;", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                    }
                    catch
                    {
                        try
                        {
                            //Dosyayı appendText ile yazmak için açtık
                            StreamWriter dosyaAc = File.AppendText(yol + @"\Gunluk Arsiv\" + dosyaAdi + @"\" + dosyaAdi + ".txt");

                            // Dosya.WriteLine ile dosyaya verileri ekledik.
                            dosyaAc.WriteLine("Kayıt Tarihi = " + DateTime.Now);
                            dosyaAc.WriteLine("\n");
                            dosyaAc.WriteLine(richTextBox1.Text);

                            // Dosya yı kapattık.
                            dosyaAc.Close();
                            MessageBox.Show("Günlük başarıyla kaydedildi.", "Bilgi;", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch { }
                    }
                }
            }
            else
            {
                MessageBox.Show("Kaydedilcek bişey yok.");
            }
        }
    }
}
