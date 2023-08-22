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
    public partial class OgrGiris : Form
    {
        public static string numara1;

        public OgrGiris()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Ana frm = new Ana();
            frm.Show();
            this.Hide();
            
           }
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            numara1 = maskedTextBox1.Text;
            sqlbaglantisi.baglanti();

            


            SqlCommand k1 = new SqlCommand("Select OgrNUMARA,OgrSifre from tbl_ogrbilgi where OgrNUMARA =@p1 and OgrSifre=@p2",sqlbaglantisi.baglanti());
            k1.Parameters.AddWithValue("@p1", maskedTextBox1.Text);
            k1.Parameters.AddWithValue("@p2", textBox1.Text);

            SqlDataReader dr = k1.ExecuteReader();
            if(dr.Read())
            {
                MessageBox.Show("Giriş Başarılı");
                OgrDetay frm = new OgrDetay();
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre");
            }
            sqlbaglantisi.baglanti().Close();
          

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OgrenciSifreYenileme sfr = new OgrenciSifreYenileme();
            sfr.Show();
            this.Hide();
        }
    }
}
