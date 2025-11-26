using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resevasi_Tiket_Pesawat
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e) // jika gambar formulir baru diklik.
        {
            FormFormulir ff = new FormFormulir();
            this.Hide(); // tutup form saat ini
            ff.Show();   // tampilkan form daftar tiket aktif
        }
        private void pictureBox2_Click_1(object sender, EventArgs e) // jika gambar daftar tiket aktif diklik.
        {
            FormTiketAktif fta = new FormTiketAktif();
            this.Hide(); // tutup form saat ini
            fta.Show();   // tampilkan form daftar tiket aktif
        }

        private void pictureBox3_Click(object sender, EventArgs e) // jika gambar daftar tiket mati diklik.
        {
            FormTiketMati fm = new FormTiketMati();
            this.Hide(); // tutup form saat ini
            fm.Show();   // tampilkan form daftar tiket mati
        }

        private void pictureBox4_Click(object sender, EventArgs e) // jika gambar verifikasi tiket diklik.
        {
            FormVerifikasi fv = new FormVerifikasi();
            this.Hide(); // tutup form saat ini
            fv.Show();   // tampilkan form verifikasi tiket
        }

        private void pictureBox5_Click(object sender, EventArgs e) // jika gambar close aplikasi diklik.
        {
            if (MessageBox.Show("Keluar dari Aplikasi?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
