using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OBS_Sistemi
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-EKQK6BH\\SQLEXPRESS;Initial Catalog=DBOgrenciBilgilendirme;Integrated Security=True");
            bgl.Open();
            return bgl;
        }
    }
}
