using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik6._4_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Menghitung mundur dari 5 sampai 1 dan mencetak setiap angka, lalu mencetak pesan di akhir
            //1. Inisialisasi variabel penghitung(counter)
            int hitungan = 5;

            Console.WriteLine("Memulai hitungan mundur:");
            //2. Perulangan 'while'
            // Kondisi perulangan: selama nilai 'hitungan' lebih besar dari 0

            while (hitungan > 0)
            {
                // Blok kode di dalam perulangan
                Console.WriteLine($"Hitungan: {hitungan}"); // Mencetak nilai penghitung saat ini

                //3. Update variabel penghitung (decrement/pengurangan)
                //Ini PENTING agar perulangan tidak menjadi loop tak terbatas (infinite loop)

                hitungan = hitungan - 1; // Mengurangi nilai 'hitungan' sebesar 1
                // Atau bisa juga menggunakan operator decrement: hitungan--;

            }
            // Kode setelah perulangan selesai
            Console.WriteLine("Selesai! Hitungan mundur telah berakhir");

        }
    }
}
