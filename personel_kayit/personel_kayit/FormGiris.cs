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

namespace personel_kayit
{
    public partial class FormGiris : Form
    {
        public FormGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LF30M9U\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from Tbl_Yonetici where KullaniciAd=@p1 and Sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",txtKullaniciAd.Text);
            komut.Parameters.AddWithValue("@p2",TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FormAna fr = new FormAna();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanici Adi ya da Şifre Hatali", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            baglanti.Close();
        }
    }
}
