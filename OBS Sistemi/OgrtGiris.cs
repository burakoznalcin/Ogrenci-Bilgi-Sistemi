using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace OBS_Sistemi
{
    public partial class OgrtGiris : Form
    {
        public OgrtGiris()
        {
            InitializeComponent();
        }
        public static string numara;

        private void button1_Click(object sender, EventArgs e)
        {
            numara = maskedTextBox1.Text;
            sqlbaglantisi baglanti = new sqlbaglantisi();

            SqlCommand k1 = new SqlCommand("Select OgrtNUMARA, OgrtSifre from tbl_ogretmen where OgrtNUMARA =@p1 and OgrtSifre =@p2", baglanti.baglanti());
            k1.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            k1.Parameters.AddWithValue("@p2", textBox1.Text);

            SqlDataReader dr = k1.ExecuteReader();
            if(dr.Read())
            {
                OgrtDetay og = new OgrtDetay();
                this.Hide();
                og.Show();
                MessageBox.Show("Giriş Başarılı");
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
            }
            baglanti.baglanti().Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ana sj = new Ana();
            sj.Show();
            this.Hide();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OgrtSifreYenileme og = new OgrtSifreYenileme();
            og.Show();
            this.Hide();
        }
    }
}
