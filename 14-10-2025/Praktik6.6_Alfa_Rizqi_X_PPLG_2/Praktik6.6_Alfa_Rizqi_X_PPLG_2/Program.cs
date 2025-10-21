using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik6._6_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Aplikasi ini akan meminta pengguna memasukkan angka genap. Perulangan akan 
            terus berjalan jika inputnya ganjil. */

            int angka;

            // Blok 'do' akan dieksekusi minimal satu kali
            do
            {
                Console.Write("Masukkan angka genap: ");
                // Mencoba membaca input dari pengguna

                if (!int.TryParse(Console.ReadLine(), out angka))
                {
                    Console.WriteLine("Input tidak valid. Silakan masukkan angka.");
                    // Jika input tidak valid, set angka = 1 (ganjil) agar loop berlanjut
                    angka = 1;
                    continue; // Lanjutkan ke iterasi berikutnya jika input tidak valid
                }
                // Memeriksa apakah angka yang dimasukkan ganjil
                if (angka % 2 != 0)
                {
                    Console.WriteLine("Input bukan angka genap. Silakan coba lagi.");
                }
            }
            while (angka % 2 != 0);
            Console.WriteLine("Selamat! Anda memasukkan angka genap: " + angka);
        }
    }
}
