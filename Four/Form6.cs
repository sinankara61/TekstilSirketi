using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Four
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QAGQ69M\\SQLEXPRESS;Initial Catalog=Odev;Integrated Security=True");
        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'odevDataSet.PERSONEL' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.pERSONELTableAdapter.Fill(this.odevDataSet.PERSONEL);

        }
        void Temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox8.Text = "";
            textBox1.Focus();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            Temizle(); 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into PERSONEL (P_ad,P_soyad,P_cinsiyet,p_adres,Dep_ID,Sube_ID) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);

            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.Parameters.AddWithValue("@p2", textBox3.Text);
            komut.Parameters.AddWithValue("@p3", textBox6.Text);
            komut.Parameters.AddWithValue("@p4", textBox5.Text);
            komut.Parameters.AddWithValue("@p5", textBox4.Text);
            komut.Parameters.AddWithValue("@p6", textBox8.Text);

            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel Eklendi!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.pERSONELTableAdapter.Fill(this.odevDataSet.PERSONEL);
        }


        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textBox8.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from PERSONEL Where P_ID=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", textBox1.Text);
            komutsil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel Silinmiştir!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update PERSONEL Set P_ad=@t1, P_soyad=@t2, P_cinsiyet=@t3,p_adres=@t4,Dep_ID=@t5,Sube_ID=@t6 where P_ID=@t7", baglanti);
            komutguncelle.Parameters.AddWithValue("@t1", textBox2.Text);
            komutguncelle.Parameters.AddWithValue("@t2", textBox3.Text);
            komutguncelle.Parameters.AddWithValue("@t3", textBox6.Text);
            komutguncelle.Parameters.AddWithValue("@t4", textBox5.Text);
            komutguncelle.Parameters.AddWithValue("@t5", textBox4.Text);
            komutguncelle.Parameters.AddWithValue("@t6", textBox8.Text);
            komutguncelle.Parameters.AddWithValue("@t7", textBox1.Text);
            komutguncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("GÜNCELLENDİ!");
        }
    }
}
