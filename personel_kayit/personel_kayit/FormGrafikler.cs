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
    public partial class FormGrafikler : Form
    {
        public FormGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LF30M9U\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void FormGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg = new SqlCommand("select PerSehir,count(*) from Tbl_Personel group by PerSehir",baglanti);
            SqlDataReader drg = komutg.ExecuteReader();
            while (drg.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(drg[0], drg[1]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select PerMeslek,Avg(PerMaas) from Tbl_Personel group by PerMeslek",baglanti);
            SqlDataReader drg2 = komutg2.ExecuteReader();
            while (drg2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(drg2[0], drg2[1]);
            }
            baglanti.Close();
        }
    }
}
