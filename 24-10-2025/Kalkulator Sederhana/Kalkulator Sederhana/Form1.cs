namespace Kalkulator_Sederhana
{
    public partial class Form1 : Form
    {
        string operation = "kali";

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_samadengan_Click(object sender, EventArgs e)
        {
            if (operation == "null")
            {
                label2.Text = "Mohon pilih operasi terlebih dahulu sebelum menekan tomnol sama dengan";
                return;
            }
            double bil1;
            double bil2;
            if (double.TryParse(textBox1.Text, out bil1) && double.TryParse(textBox2.Text, out bil2))
            {
                if(operation == "tambah")
                {
                    label2.Text = $"Hasil: {bil1 + bil2}";
                }
                if (operation == "kurang")
                {
                    label2.Text = $"Hasil: {bil1 - bil2}";
                }
                if (operation == "kali")
                {
                    label2.Text = $"Hasil: {bil1 * bil2}";
                }
                if (operation == "bagi")
                {
                    label2.Text = $"Hasil: {bil1 / bil2}";
                }
                if (operation == "modulus")
                {
                    label2.Text = $"Hasil: {bil1 % bil2}";
                }
            }
            else
            {
                label2.Text = "Mohon masukkan angka yang valid";
                return;
            }


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn_tambah_Click(object sender, EventArgs e)
        {
            operation = "tambah";
            lbl_operasi.Text = "+";
        }

        private void btn_kali_Click(object sender, EventArgs e)
        {
            operation = "kali";
            lbl_operasi.Text = "×";
        }

        private void btn_modulus_Click(object sender, EventArgs e)
        {
            operation = "modulus";
            lbl_operasi.Text = "%";
        }

        private void btn_kurang_Click(object sender, EventArgs e)
        {
            operation = "kurang";
            lbl_operasi.Text = "-";
        }

        private void btn_bagi_Click(object sender, EventArgs e)
        {
            operation = "bagi";
            lbl_operasi.Text = "÷";
        }

        private void lbl_operasi_Click(object sender, EventArgs e)
        {

        }
    }
}
