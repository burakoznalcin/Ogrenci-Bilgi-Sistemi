using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBS_Sistemi
{
    public partial class Ana : Form
    {
        public Ana()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            OgrGiris fr = new OgrGiris();
            fr.Show();
            this.Hide();
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            OgrtGiris frm = new OgrtGiris();
            frm.Show();
            this.Hide();

        }
    }
}
