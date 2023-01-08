using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Günlük
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "faruk123")
            {
                //Parola başarılıysa
                label3.ForeColor = Color.DarkGreen;
                label3.Text = "Giriş başarılı..";

                //Mesaj kutusu
                MessageBox.Show("Giriş başarılı. Yönlendiriliyor..", "Bildirim;", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Form1 Gizle
                this.Hide();

                //Form2 Aç
                Form2 frm2 = new Form2();
                frm2.Show();

            }else{
                //Parola başarısızsa
                label3.ForeColor = Color.DarkRed;
                label3.Text = "Giriş başarısız..";
            }
        }
    }
}
