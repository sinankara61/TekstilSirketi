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

namespace Four
{
    public partial class Form4 : Form
    {
        public Form4()
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
            textBox2.Text = "";
            textBox3.Text = "";
            textBox20.Focus();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.sTOKTableAdapter.Fill(this.odevDataSet.STOK);

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update STOK Set Urun_ID=@t1,Sube_ID=@t2, Kategori_ID=@t3, Ted_ID=@t4, Urun_sayisi=@t5 where Stok_ID=@t6", baglanti);
            komutguncelle.Parameters.AddWithValue("@t1", textBox19.Text);
            komutguncelle.Parameters.AddWithValue("@t2", textBox18.Text);
            komutguncelle.Parameters.AddWithValue("@t3", textBox17.Text);
            komutguncelle.Parameters.AddWithValue("@t4", textBox2.Text);
            komutguncelle.Parameters.AddWithValue("@t5", textBox3.Text);
            komutguncelle.Parameters.AddWithValue("@t6", textBox20.Text);
            komutguncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("GÜNCELLENDİ!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox20.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox19.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textBox18.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textBox17.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            this.sTOKTableAdapter.Fill(this.odevDataSet.STOK);

        }
    }
}
