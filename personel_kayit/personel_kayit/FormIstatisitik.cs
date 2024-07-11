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
    public partial class FormIstatisitik : Form
    {
        public FormIstatisitik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LF30M9U\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void FormIstatisitik_Load(object sender, EventArgs e)
        {
            //Toplam Personel
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count(*) from Tbl_Personel",baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamPer.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //Evli Personel
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count(*) from Tbl_Personel where PerDurum=1",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblEvli.Text = dr2[0].ToString();
            }
            baglanti.Close();
            //Bekar Personel
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from Tbl_Personel where PerDurum=0",baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekar.Text = dr3[0].ToString();
            }
            baglanti.Close();
            //Sehir Sayisi
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(PerSehir)) from Tbl_Personel",baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblSehir.Text = dr4[0].ToString();
            }
            baglanti.Close();
            //Toplam Maas
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum(PerMaas) from Tbl_Personel",baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblToplamMaas.Text= dr5[0].ToString();
            }

            baglanti.Close();
            //Ortalama Maas 
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg(PerMaas) from Tbl_Personel",baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtMaas.Text=dr6[0].ToString();
            }

            baglanti.Close();
        }
    }
}
