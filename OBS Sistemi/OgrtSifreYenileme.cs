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
    public partial class OgrtSifreYenileme : Form
    {
        public OgrtSifreYenileme()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgrtGiris ana = new OgrtGiris();
            ana.Show();
            this.Hide();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void OgrtSifreYenileme_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            bgl.baglanti();
            SqlCommand k2 = new SqlCommand("Select OgrtNUMARA from tbl_ogretmen where OgrtNUMARA = @p2", bgl.baglanti());
            k2.Parameters.AddWithValue("@p2", maskedTextBox1.Text);

            SqlDataReader dr = k2.ExecuteReader();
            if (dr.Read())
            {


                SqlCommand k1 = new SqlCommand("Update tbl_ogretmen set OgrtSifre =@k1 where OgrtNUMARA =@p2", bgl.baglanti());
                if (textBox1.Text == textBox2.Text)
                {
                    k1.Parameters.AddWithValue("@k1", textBox1.Text);
                    k1.Parameters.AddWithValue("@p2", maskedTextBox1.Text);
                    k1.ExecuteNonQuery();
                    MessageBox.Show("Şifre Değiştirildi");


                }
                else
                {
                    MessageBox.Show("Şifreleri Kontrol Ediniz.");
                }
            }
            else
            {
                MessageBox.Show("Hatalı Numara Girdiniz. ");
            }
            bgl.baglanti().Close();

        }
    }
}
