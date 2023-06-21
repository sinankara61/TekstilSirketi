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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QAGQ69M\\SQLEXPRESS;Initial Catalog=Odev;Integrated Security=True");


        private void Form7_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'odevDataSet.DEPARTMANLAR' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.dEPARTMANLARTableAdapter.Fill(this.odevDataSet.DEPARTMANLAR);

        }
        void Temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.dEPARTMANLARTableAdapter.Fill(this.odevDataSet.DEPARTMANLAR);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into DEPARTMANLAR (Dep_ad) values (@p1)", baglanti);

            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Departman Eklendi!");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from DEPARTMANLAR Where Dep_ID=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", textBox1.Text);
            komutsil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("DEPARTMAN Silinmiştir!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update DEPARTMANLAR Set Dep_ad=@t1, where Dep_ID=@T2", baglanti);
            komutguncelle.Parameters.AddWithValue("@t1", textBox2.Text);
            komutguncelle.Parameters.AddWithValue("@t2", textBox1.Text);
            komutguncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("GÜNCELLENDİ!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
