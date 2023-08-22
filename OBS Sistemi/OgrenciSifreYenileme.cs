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
    public partial class OgrenciSifreYenileme : Form
    {
        public OgrenciSifreYenileme()
        {
            InitializeComponent();
        }
  
        sqlbaglantisi sqlbaglantisi = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            sqlbaglantisi.baglanti();

            SqlCommand komut = new SqlCommand("Select OgrNUMARA from tbl_ogrbilgi where OgrNUMARA = @p1", sqlbaglantisi.baglanti());
            komut.Parameters.AddWithValue("@p1", maskedTextBox1.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                if (textBox1.Text == textBox2.Text)
                {
                    SqlCommand komutguncelle = new SqlCommand("Update tbl_ogrbilgi set OgrSifre=@p1 where OgrNumara=@p2", sqlbaglantisi.baglanti());
                    komutguncelle.Parameters.AddWithValue("@p1", textBox1.Text);
                    komutguncelle.Parameters.AddWithValue("@p2", dr[0]);
                    komutguncelle.ExecuteNonQuery();
                    MessageBox.Show("Şifre Değiştirildi.");
                }
                else
                {
                    MessageBox.Show("Şifreleri Kontrol Ediniz.");
                }
            }
            else
            {
                MessageBox.Show("Hatalı Öğrenci Numarası Girdiniz.");
            }
            sqlbaglantisi.baglanti().Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            OgrGiris adm = new OgrGiris();
            adm.Show();
        }
    }
}
