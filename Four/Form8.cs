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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Four
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-QAGQ69M\\SQLEXPRESS;Initial Catalog=Odev;Integrated Security=True");

        void Temizle()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox1.Focus();
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'odevDataSet.MAAS' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.mAASTableAdapter.Fill(this.odevDataSet.MAAS);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into MAAS (Maas) values (@p1)", baglanti);

            komut.Parameters.AddWithValue("@p1", textBox2.Text);
            komut.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Maas Eklendi!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.mAASTableAdapter.Fill(this.odevDataSet.MAAS);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update MAAS Set Maas=@t1, where Dep_ID=@T2", baglanti);
            komutguncelle.Parameters.AddWithValue("@t1", textBox2.Text);
            komutguncelle.Parameters.AddWithValue("@t2", textBox1.Text);
            komutguncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("GÜNCELLENDİ!");
        }
    }
}
