using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik7._3_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        //Fungsi dengan nilai kembali
        static int Tambah(int a, int b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            Console.Write("Masukkan angka pertama: ");
            int x = Convert.ToInt32(Console.ReadLine());

            Console.Write("Masukkan angka kedua: ");
            int y = Convert.ToInt32(Console.ReadLine());

            int hasil = Tambah(x, y);
            Console.WriteLine("Hasil penjumlahan: " + hasil);
        }
    }
}
