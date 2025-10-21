using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik5._1_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Membuat array dengan 5 elemen tipe data string
            string[] siswa = new string[5];

            // Mengisi elemen array dengan nama siswa
            siswa[0] = "Alfa Rizqi";
            siswa[1] = "Budi Santoso";  
            siswa[2] = "Citra Lestari";
            siswa[3] = "Dewi Anggraini";
            siswa[4] = "Eka Pratama";

            // Menampilkan isi array tanpa perulangan
            Console.WriteLine("Daftar Nama Siswa:");
            Console.WriteLine("Siswa ke-1 :" + siswa[0]);
            Console.WriteLine("Siswa ke-2 :" + siswa[1]);
            Console.WriteLine("Siswa ke-3 :" + siswa[2]);  
            Console.WriteLine("Siswa ke-4 :" + siswa[3]);
            Console.WriteLine("Siswa ke-5 :" + siswa[4]);
        }
    }
}
