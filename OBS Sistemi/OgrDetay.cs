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
    public partial class OgrDetay : Form
    {
        public OgrDetay()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
           OgrGiris ogr = new OgrGiris();
            
            ogr.Show();
        }
        sqlbaglantisi sql = new sqlbaglantisi();
        private void OgrDetay_Load(object sender, EventArgs e)
        {
            //numarayı çağırmak için ekstra değişken atamak istemedim

            numara.Text = OgrGiris.numara1.ToString();

            sql.baglanti();
            SqlCommand komut = new SqlCommand("Select * from tbl_ogrbilgi where OgrNUMARA = @p1", sql.baglanti());
            komut.Parameters.AddWithValue("@p1",numara.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                adsoyad.Text = dr[2].ToString() + " " + dr[3].ToString();
                s1.Text = dr[4].ToString();
                s2.Text = dr[5].ToString();
                s3.Text = dr[6].ToString();
                ort.Text = dr[7].ToString();
                string a = dr[8].ToString();

                if ( a == "True")
                {
                    durum.Text = "Geçti!";
                }
                else
                {
                    durum.Text = " KALDI !";
                }

            }
            sql.baglanti().Close();


        }
    }
}
