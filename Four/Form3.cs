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


namespace Four
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
            
        }

        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QAGQ69M\\SQLEXPRESS;Initial Catalog=Odev;Integrated Security=True");
        
        void Temizle()
        {
            textBox19.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox20.Text = "";
            textBox19.Focus();

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'odevDataSet.URUNLER' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.uRUNLERTableAdapter.Fill(this.odevDataSet.URUNLER);

            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into URUNLER (Urun_ad,Fiyat) values (@p1,@p2)", baglanti);
            
            komut.Parameters.AddWithValue("@p1", textBox19.Text);
            komut.Parameters.AddWithValue("@p2", textBox17.Text);
            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Ürününüz Eklendi!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.uRUNLERTableAdapter.Fill(this.odevDataSet.URUNLER);
        }

        private void button3_Click(object sender, EventArgs e)
        {
              Temizle();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox20.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox19.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox18.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox17.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from URUNLER Where Urun_ID=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", textBox20.Text);
            komutsil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Ürün Silinmiştir!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update URUNLER Set Urun_ad=@t1, Kategori_ID=@t2, Fiyat=@t3 where Urun_ID=@T4", baglanti);
            komutguncelle.Parameters.AddWithValue("@t1", textBox19.Text);
            komutguncelle.Parameters.AddWithValue("@t2", textBox18.Text);
            komutguncelle.Parameters.AddWithValue("@t3", textBox17.Text);
            komutguncelle.Parameters.AddWithValue("@t4", textBox20.Text);
            komutguncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("GÜNCELLENDİ!");
        }
    }
}
