namespace Radio_Button
{
    public partial class Form1 : Form
    {    
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btn_daftar_Click(object sender, EventArgs e)
        {
            bool invalid = false;
            if (string.IsNullOrWhiteSpace(txt_nama.Text))
            {
                invalid = true;
                lbl_nama_lengkap.Text = "Nama Lengkap Invalid";
            }
            else
            {
                lbl_nama_lengkap.Text = $"Nama Lengkap: {txt_nama.Text}";
            }
            if (string.IsNullOrWhiteSpace(txt_alamat.Text))
            {
                lbl_alamat.Text = "Alamat Invalid";
                invalid = true;
            }
            else
            {
                lbl_alamat.Text = $"Alamat: {txt_alamat.Text}";
            }
            if(rd_laki_laki.Checked)
            {
                lbl_jenis_kelamin.Text = "Jenis Kelamin: Laki-laki";
            }
            else if(rd_perempuan.Checked)
            {
                lbl_jenis_kelamin.Text = "Jenis Kelamin: Perempuan";
            }
            else
            {
                invalid = true;
                lbl_jenis_kelamin.Text = "Jenis Kelamin Invalid";
            }
            if(cb_hobi_makan.Checked || cb_hobi_minum.Checked || cb_hobi_tidur.Checked)
            {
                string hobi = "Hobi: ";
                if (cb_hobi_makan.Checked)
                {
                    hobi += "Makan ";
                }
                if (cb_hobi_minum.Checked)
                {
                    hobi += "Minum ";
                }
                if (cb_hobi_tidur.Checked)
                {
                    hobi += "Tidur ";
                }
                lbl_hobi.Text = hobi;
            }
            else
            {
                lbl_hobi.Text = "Hobi Tidak dipilih";
            }
            if (cb_jurusan.SelectedItem != null)
            {
                lbl_jurusan.Text = $"Jurusan: {cb_jurusan.SelectedItem.ToString()}";
            }
            else
            {
                invalid = true;
                lbl_jurusan.Text = "Jurusan Invalid";
            }

            if (invalid == true)
            {
                MessageBox.Show("Ada formulir yang belum anda isi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
       
        }
    }
}
