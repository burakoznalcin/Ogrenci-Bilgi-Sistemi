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
    public partial class OgrtDetay : Form
    {
        public OgrtDetay()
        {
            InitializeComponent();
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgrtGiris of = new OgrtGiris();
            of.Show();
            this.Hide();
        }
        sqlbaglantisi sql = new sqlbaglantisi();
        private void OgrtDetay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dBOgrenciBilgilendirmeDataSet.tbl_ogrbilgi' table. You can move, or remove it, as needed.
            this.tbl_ogrbilgiTableAdapter.Fill(this.dBOgrenciBilgilendirmeDataSet.tbl_ogrbilgi);
           

            sql.baglanti();
            SqlCommand ab = new SqlCommand("Select OgrtAdSoyad from tbl_ogretmen where OgrtNUMARA=@p1", sql.baglanti());
            ab.Parameters.AddWithValue("@p1", OgrtGiris.numara);
            SqlDataReader dr = ab.ExecuteReader();
            if (dr.Read())
            {
                label14.Text = ("Merhaba,  "+ dr[0].ToString()  + " Sisteme Hoşgeldin.");
            }
            sql.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            sql.baglanti();
            SqlCommand komut = new SqlCommand("Insert into tbl_ogrbilgi (OgrNUMARA, OgrAD, OgrSOYAD,OgrSifre) values (@q1,@q2,@q3,@q4)", sql.baglanti());
            komut.Parameters.AddWithValue("@q1", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@q2", ad.Text);
            komut.Parameters.AddWithValue("@q3",soyad.Text);
            komut.Parameters.AddWithValue("@q4 ", sifree.Text);
            komut.ExecuteNonQuery();
            this.tbl_ogrbilgiTableAdapter.Fill(this.dBOgrenciBilgilendirmeDataSet.tbl_ogrbilgi);
            sql.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox1.Text = " ";
            ad.Text = " ";
            soyad.Text = " ";
            sifree.Text = " ";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double e1, e2, e3, average;
            e1 = Convert.ToDouble(s1.Text);
            e2 = Convert.ToDouble(s2.Text);
            e3 = Convert.ToDouble(s3.Text);
            average = ( e1 + e2 + e3) / 3;


            sql.baglanti();
            SqlCommand komut = new SqlCommand("Update tbl_ogrbilgi set OgrS1= @p1,OgrS2 = @p2,OgrS3 = @p3, ORTALAMA = @p4,DURUM = @p5 where OgrNUMARA =@p7",sql.baglanti());
            komut.Parameters.AddWithValue("@p1", s1.Text);
            komut.Parameters.AddWithValue("@p2", s2.Text);
            komut.Parameters.AddWithValue("@p3", s3.Text);
            komut.Parameters.AddWithValue("@p4", average);
            if (average >= 50)
            {
                komut.Parameters.AddWithValue("@p5",1);
            }
            else if (average < 50 )
            {
                komut.Parameters.AddWithValue("@p5", 0);
            }
            komut.Parameters.AddWithValue("@p7", maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            this.tbl_ogrbilgiTableAdapter.Fill(this.dBOgrenciBilgilendirmeDataSet.tbl_ogrbilgi);

            sql.baglanti().Close();
            MessageBox.Show("Not Güncellendi");





        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            ad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            soyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            sifree.Text = dataGridView1.Rows[secilen].Cells[8].Value.ToString();
            s1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            s2.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            s3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            s1.Text = " ";
            s2.Text = " ";
            s3.Text = " ";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            // ogrnumara dan değer alınıp çıkartabilirdim ama böyle daha güzel oldu
            sql.baglanti();
            SqlCommand s = new SqlCommand("Select COUNT(DURUM) FROM tbl_ogrbilgi where DURUM = 0",sql.baglanti());
            SqlCommand d = new SqlCommand("Select COUNT(DURUM) FROM tbl_ogrbilgi where DURUM = 1",sql.baglanti());
           

            SqlDataReader ds = s.ExecuteReader();
            while(ds.Read())
            {
                kalan.Text = ds[0].ToString();
                
            }
            SqlDataReader dd = d.ExecuteReader();
            while (dd.Read())
            {
                gecen.Text = dd[0].ToString();

            }
            
            sql.baglanti().Close();
          
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double toplam, ortalama,gecn, kaln;
            gecn = Convert.ToDouble(gecen.Text);
            kaln = Convert.ToDouble(kalan.Text);

            sql.baglanti();
            SqlCommand w = new SqlCommand("Select SUM(ORTALAMA) FROM tbl_ogrbilgi ", sql.baglanti());
            SqlDataReader dw = w.ExecuteReader();
            while (dw.Read())
            {
                toplam = Convert.ToDouble(dw[0]);

                ortalama = toplam / ( gecn + kaln )  ;
                ort.Text = ortalama.ToString("N2");
                
            }
            sql.baglanti().Close();

        }
    }
}
