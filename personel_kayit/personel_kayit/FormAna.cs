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
    public partial class FormAna : Form
    {
        public FormAna()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-LF30M9U\\MSSQLSERVER01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");


        void temizle()
        {
            TxtPerAd.Text = "";
            TxtPerSoyad.Text = "";
            TxtPerId.Text = "";
            TxtPerMeslek.Text = "";
            CmbPerSehir.Text = "";
            MtxtPerMaas.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            TxtPerAd.Focus();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            



        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter1.Fill(this.personelVeriTabaniDataSet1.Tbl_Personel);
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (PerAd,PerSoyad,PerSehir,PerMaas,PerMeslek,PerDurum) values(@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1",TxtPerAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtPerSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbPerSehir.Text);
            komut.Parameters.AddWithValue("@p4", MtxtPerMaas.Text);
            komut.Parameters.AddWithValue("@p5",TxtPerMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
            
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtPerId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtPerAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtPerSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbPerSehir.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MtxtPerMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            TxtPerMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;

            }
            if(label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("delete from Tbl_Personel where PerId=@k1",baglanti);
            komutsil.Parameters.AddWithValue("@k1",TxtPerId.Text);
            komutsil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel silindi");
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3,PerMaas=@a4,PerDurum=@a5,PerMeslek=@a6 Where PerId=@a7",baglanti);
            komutguncelle.Parameters.AddWithValue("@a1",TxtPerAd.Text);
            komutguncelle.Parameters.AddWithValue("@a2", TxtPerSoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", CmbPerSehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4",MtxtPerMaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5",label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6",TxtPerMeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7", TxtPerId.Text);
            komutguncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel Güncellendi");
        }

        private void BtnIstatistik_Click(object sender, EventArgs e)
        {
            FormIstatisitik fr = new FormIstatisitik();
            fr.Show();
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FormGrafikler frm = new FormGrafikler();
            frm.Show();
        }
    }
}
