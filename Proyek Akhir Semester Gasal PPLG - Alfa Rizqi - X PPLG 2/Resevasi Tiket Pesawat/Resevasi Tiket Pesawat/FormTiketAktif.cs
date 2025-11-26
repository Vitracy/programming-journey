using MySql.Data.MySqlClient; // tambahan NuGet Packages, untuk include MySQL
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Resevasi_Tiket_Pesawat
{
    public partial class FormTiketAktif : Form
    {
        public FormTiketAktif()
        {
            InitializeComponent();
        }

        private void FormTiketAktif_Load(object sender, EventArgs e)
        {
            TampilkanData(); // refresh datagrid
        }

        private void TampilkanData()
        {
            string koneksi = "server=localhost;user id=root;password=;database=katasi;"; // menulis database mysql yang akan dihubungkan
            MySqlConnection conn = new MySqlConnection(koneksi); // hubungkan mysql
            conn.Open(); // buka mysql

            // 1. Hitung total baris dulu
            MySqlCommand countCmd = new MySqlCommand("SELECT COUNT(*) FROM tiket", conn);
            int total = Convert.ToInt32(countCmd.ExecuteScalar());

            // Set progress bar
            progressBar1.Value = 0;
            progressBar1.Maximum = total;
            progressBar1.Visible = true;

            // 2. Ambil data

            string query = "SELECT * FROM tiket"; // perintah untuk memilih baris di tabel tiket
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader rd = cmd.ExecuteReader();

            dataGrid_active_ticket.Rows.Clear(); // menghapus isi lama
            while (rd.Read())
            {
                // Tambahkan row baru
                dataGrid_active_ticket.Rows.Add(
                    rd["id"].ToString(),
                    rd["nama_kontak"].ToString(),
                    rd["tanggal_lahir"].ToString(),
                    rd["email"].ToString(),
                    rd["no_telp"].ToString(),
                    rd["negara_keberangkatan"].ToString(),
                    rd["negara_tujuan"].ToString(),
                    rd["tanggal_waktu_keberangkatan"].ToString(),
                    rd["kelas_layanan"].ToString(),
                    rd["layanan_lainnya"].ToString(),
                    rd["hotel_pilihan"].ToString(),
                    rd["penerbangan_pilihan"].ToString(),
                    rd["informasi_tambahan"].ToString(),
                    rd["harga_tiket"].ToString()
                );

               
                if (progressBar1.Value < progressBar1.Maximum)
                    progressBar1.Value++; // ambahkan value progress bar setiap memuat baris
            }

            rd.Close();
            conn.Close();

            // 4. Sembunyikan progress bar setelah selesai
            progressBar1.Visible = false;
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            TampilkanData();
        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            if (dataGrid_active_ticket.CurrentRow == null) // jika dataGrid_active_ticket tida ada baris yang dipilih
            {
                MessageBox.Show("Tidak ada baris yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // messagebox error ditampilkan
                return; // program dihentikan
            }

            string id = dataGrid_active_ticket.CurrentRow.Cells["Column_ID"].Value.ToString(); // var id di set ke nilai pada kolom Column_ID pada dataGrid_active_ticket.CurrentRow.Cells

            if (MessageBox.Show("Yakin hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) // show dialog messagebox warning lalu jika direspon yes
            {
                HapusData(id); // hapus tiket sesuai var id
                TampilkanData(); // Refresh datagrid
                lbl_informasi.Text = ""; // clear informasi selengkapnya
            }
        }

        private void HapusData(string id) // fungsi hapus tiket sesuai id
        {
            string koneksi = "server=localhost;user id=root;password=;database=katasi;"; // menulis database mysql yang akan dihubungkan
            using (MySqlConnection conn = new MySqlConnection(koneksi)) // hubungkan mysql
            {
                conn.Open(); // buka mysql
                string query = "DELETE FROM tiket WHERE id = @id"; // perintah querry untuk hapus pada baris sesuai id
                MySqlCommand cmd = new MySqlCommand(query, conn); // membuat cmd menjadi perintah
                cmd.Parameters.AddWithValue("@id", id); // tambah parimeter ID ke perintah
                cmd.ExecuteNonQuery(); // di perintah di eksekusi
            }
        }
        private void PindahkanBaris(string id) // fungsi untuk pindahkan baris ke tabel mati
        {
            string koneksi = "server=localhost;user id=root;password=;database=katasi;"; // menulis database mysql yang akan dihubungkan
            using (MySqlConnection conn = new MySqlConnection(koneksi)) // hubungkan mysql
            {
                conn.Open(); // buka mysql

                // 1) Insert ke tabel tujuan
                string insertQuery = "INSERT INTO tiket_mati SELECT * FROM tiket WHERE id = @id"; // perintah querry sql, INSERT untuk menambah baris baru ke tabel_mati yang sama seperti baris yang ada di tabel tiket
                MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn); // membuat cmdinsert dari querry
                cmdInsert.Parameters.AddWithValue("@id", id); // penambahan parimeter id baris
                cmdInsert.ExecuteNonQuery(); // perintah di eksekusi

                // 2) Hapus dari tabel asal
                string deleteQuery = "DELETE FROM tiket WHERE id = @id"; // perintah querry dihapus baris sebelumnya dari tabel tiket
                MySqlCommand cmdDelete = new MySqlCommand(deleteQuery, conn); // cmddelete dibuat dari querry
                cmdDelete.Parameters.AddWithValue("@id", id); // parimeter id ditambahkan ke cmd querry
                cmdDelete.ExecuteNonQuery(); // eksesuki cmd
            }
        }

        private void button_nonaktifkan_Click(object sender, EventArgs e) // fungsi untuk memindahkan tiket ke tiket mati
        {
            if (dataGrid_active_ticket.CurrentRow == null) // jika dataGrid_active_ticket tidak ada baris yang dipilih
            {
                MessageBox.Show("Tidak ada baris yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // program diberhentikan
            }

            string id = dataGrid_active_ticket.CurrentRow.Cells["Column_ID"].Value.ToString(); // definisikan var id sesuai dengan kolom Column_ID pada dataGrid_active_ticket.CurrentRow.Cells

            if (MessageBox.Show("Pindahkan data ini ke Daftar Tiket Mati?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes) // messagebox dialog warning, result jika yes
            {
                PindahkanBaris(id); // jalankan fungsi pindahkan baris
                TampilkanData(); // refresh datagrid
                lbl_informasi.Text = ""; // clear informasi selengkapnya
            }
        }

        private void button_back_to_form_Click(object sender, EventArgs e)
        {
            FormFormulir ff = new FormFormulir();
            this.Hide(); // tutup form saat ini
            ff.Show();   // tampilkan form buat tiket
        }

        private void button_informasi_tambahan_Click(object sender, EventArgs e)
        {
            
        }

        private void button_to_tiket_mati_Click(object sender, EventArgs e)
        {
            FormTiketMati fm = new FormTiketMati();
            this.Hide(); // tutup form saat ini
            fm.Show();   // tampilkan form daftar tiket mati
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            

            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e) // saat printDocument1 dibuka halamannya
        {
            if (dataGrid_active_ticket.CurrentRow != null) // jika dataGrid_active_ticket tidak ada baris yang dipilih
            {
               
                Graphics g = e.Graphics; // membuat graphics baru
                Font headerFont = new Font("Arial", 18, FontStyle.Bold); // membuat headerFont
                Font labelFont = new Font("Arial", 10, FontStyle.Bold); // membuat label font
                Font valueFont = new Font("Arial", 10); // membuat nilai font
                Brush blueBrush = new SolidBrush(Color.FromArgb(0, 102, 204)); // membuat brush biru
                Brush blackBrush = Brushes.Black; // membuat brush hitam

                int startX = 50; // set nilai x awal ke 50
                int startY = 60; // set nilai y awal ke 60
                int width = 750; // set panjang graphic ke 750
                int height = 250; // set lebar graphic ke 250

                // --- Background garis biru atas ---
                g.FillRectangle(blueBrush, startX, startY, width, 40); // buat persegi panjangan biru
                g.DrawString("TIKET PESAWAT - KAPAL ATAS INDONESIA", headerFont, Brushes.White, startX + 15, startY + 5); // tulis teks


                // --- Garis border tiket ---
                g.DrawRectangle(Pens.Black, startX, startY, width, height); // garis lurus untuk border dengan warna hitam

                int leftColX = startX + 20; // align left
                int midColX = startX + 195; // align mid
                int rightColX = startX + 500; // align right
                int lineY = startY + 70; // garis ketinggian

                // --- Info penumpang ---
                g.DrawString("NAMA", labelFont, blueBrush, leftColX, lineY);  // tulis teks
                g.DrawString(dataGrid_active_ticket.CurrentRow.Cells["Column_Nama_Kontak"].Value?.ToString(), valueFont, blackBrush, leftColX, lineY + 18); // ambil data dari kolom datagridview pada current row

                g.DrawString("E-MAIL", labelFont, blueBrush, leftColX, lineY + 50);  // tulis teks
                string email = dataGrid_active_ticket.CurrentRow.Cells["Column_Email"].Value?.ToString();
                int max = 20;
                if (email.Length > max)
                {
                    for (int i = max; i < email.Length; i += max + 1)
                    {
                        email = email.Insert(i, "\n");
                    }
                }
                g.DrawString(email, valueFont, blackBrush, leftColX, lineY + 68); // ambil data dari kolom datagridview pada current row


                // --- Info keberangkatan ---
                g.DrawString("WAKTU MENGUDARA", labelFont, blueBrush, midColX, lineY);  // tulis teks
                g.DrawString(dataGrid_active_ticket.CurrentRow.Cells["Column_Tanggal_Waktu_Berangkat"].Value?.ToString(), valueFont, blackBrush, midColX, lineY + 18); // ambil data dari kolom datagridview pada current row

                g.DrawString("DARI", labelFont, blueBrush, midColX, lineY + 50);  // tulis teks
                g.DrawString(dataGrid_active_ticket.CurrentRow.Cells["Column_Negara_Keberangkatan"].Value?.ToString(), valueFont, blackBrush, midColX, lineY + 68); // ambil data dari kolom datagridview pada current row

                g.DrawString("MENUJU", labelFont, blueBrush, midColX, lineY + 100);  // tulis teks
                g.DrawString(dataGrid_active_ticket.CurrentRow.Cells["Column_Negara_Tujuan"].Value?.ToString(), valueFont, blackBrush, midColX, lineY + 118); // ambil data dari kolom datagridview pada current row

                // --- Info penerbangan ---
                g.DrawString("PENERBANGAN", labelFont, blueBrush, rightColX, lineY);  // tulis teks
                g.DrawString(dataGrid_active_ticket.CurrentRow.Cells["Column_Penerbangan"].Value?.ToString(), valueFont, blackBrush, rightColX, lineY + 18); // ambil data dari kolom datagridview pada current row

                g.DrawString("TIKET ID", labelFont, blueBrush, rightColX, lineY + 50);  // tulis teks
                g.DrawString(dataGrid_active_ticket.CurrentRow.Cells["Column_ID"].Value?.ToString(), valueFont, blackBrush, rightColX, lineY + 68); // ambil data dari kolom datagridview pada current row

                g.DrawString("KELAS", labelFont, blueBrush, rightColX, lineY + 100);  // tulis teks
                g.DrawString(dataGrid_active_ticket.CurrentRow.Cells["Column_Kelas_Layanan"].Value?.ToString(), valueFont, blackBrush, rightColX, lineY + 118); // ambil data dari kolom datagridview pada current row
            }
            else
            {
                MessageBox.Show("Pilih baris tiket yang ingin anda cetak", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // messagebox error ditampilkan
            }

            
        }

        private void lbl_informasi_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e) // ketika gambar print di klik
        {
            if (dataGrid_active_ticket.CurrentRow != null) // jika dataGrid_active_ticket.CurrentRow dipilih
            {
                PrintPreviewDialog preview = new PrintPreviewDialog(); // membuat var preview
                preview.Document = printDocument1; // set ke preview dari printDocument1
                preview.ShowDialog(); // menunjukka preview
            }
            else // jika tidak ada row/baris yang dipilih.
            {
                MessageBox.Show("Pilih baris tiket yang ingin anda cetak", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); //messagebox error
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (dataGrid_active_ticket.CurrentRow != null)
            {
                lbl_informasi.Text = "";
                lbl_informasi.Text += "# Tiket ID: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_ID"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n\n# Informasi Pribadi";
                lbl_informasi.Text += "\n • Nama Kontak: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Nama_Kontak"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Tanggal lahir: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_TTL"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • E-mail: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Email"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • No. Telp: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Nomor_Telp"].Value?.ToString() ?? "";

                lbl_informasi.Text += "\n\n# Detail Perjalanan";
                lbl_informasi.Text += "\n • Negara Keberangkatan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Negara_Keberangkatan"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Negara Tujuan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Negara_Tujuan"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Tanggal dan Waktu Keberangkatan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Tanggal_Waktu_Berangkat"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Kelas Layanan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Kelas_Layanan"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Layanan Lainnya: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Layanan"].Value?.ToString() ?? "";

                lbl_informasi.Text += "\n\n# Rincian Perjalanan";
                if (!string.IsNullOrEmpty(dataGrid_active_ticket.CurrentRow.Cells["Column_Nama_Hotel"].Value?.ToString()))
                {
                    lbl_informasi.Text += "\n • Hotel Pilihan: ";
                    lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Nama_Hotel"].Value?.ToString() ?? "";
                }
                lbl_informasi.Text += "\n • Penerbangan Pilihan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Penerbangan"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Informasi Tambahan: ";
                lbl_informasi.Text += dataGrid_active_ticket.CurrentRow.Cells["Column_Informasi_Tambahan"].Value?.ToString() ?? "";
                lbl_informasi.Text += "\n • Harga Tiket: ";
                lbl_informasi.Text += "Rp. " + FormatMoney(Convert.ToInt32(dataGrid_active_ticket.CurrentRow.Cells["Total_Harga"].Value));
            }
            else
            {
                MessageBox.Show("Pilih baris tiket yang ingin anda lihat informasi tambahannya", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string FormatMoney(int angka)
        {
            return angka.ToString("#,0").Replace(",", ".");
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            TampilkanData(); //refresh
        }

        private void pictureBox3_Click(object sender, EventArgs e) // pindahkan ke daftar mati
        {
            if (dataGrid_active_ticket.CurrentRow == null)
            {
                MessageBox.Show("Tidak ada baris yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string id = dataGrid_active_ticket.CurrentRow.Cells["Column_ID"].Value.ToString();

            if (MessageBox.Show("Pindahkan data ini ke Daftar Tiket Mati?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                PindahkanBaris(id);
                TampilkanData(); // refresh datagrid
                lbl_informasi.Text = ""; // clear informasi selengkapnya
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e) // hapus tiket
        {
            if (dataGrid_active_ticket.CurrentRow == null)
            {
                MessageBox.Show("Tidak ada baris yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string id = dataGrid_active_ticket.CurrentRow.Cells["Column_ID"].Value.ToString();

            if (MessageBox.Show("Yakin hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                HapusData(id);
                TampilkanData(); // Refresh datagrid
                lbl_informasi.Text = ""; // clear informasi selengkapnya
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            FormTiketMati fm = new FormTiketMati();
            this.Hide(); // tutup form saat ini
            fm.Show();   // tampilkan form daftar tiket mati
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FormFormulir ff = new FormFormulir();
            this.Hide(); // tutup form saat ini
            ff.Show();   // tampilkan form buat tiket
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            FormMenu fm = new FormMenu();
            this.Hide(); // tutup form saat ini
            fm.Show();   // tampilkan form menu
        }
    }
}
