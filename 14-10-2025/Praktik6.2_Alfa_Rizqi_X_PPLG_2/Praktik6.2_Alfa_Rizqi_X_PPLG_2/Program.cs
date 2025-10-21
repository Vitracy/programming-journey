using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik6._2_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Menghitung jumlah angka (penjumlahan)
            int total = 0;

            Console.WriteLine("Menghitung jumlah angka dari 1 sampai 5:");

            // Perulangan for dari 1 hingga 5
            for (int i = 1; i <= 5; i++)
            {
                // Tambahkan nilai i saat ini ke variable total
                total += i; // Bisa juga ditulis total = total + i; atau total =+ i;

                // Tampilkan proses penjumlahan di setiap langkah
                Console.WriteLine($"Menambahkan {i}, total sementara: {total}");
            }

            // Tampilkan hasil akhir penjumlahan setelah perulangan selesai
            Console.WriteLine($"\nHasil akhir penjumlahan adalah: {total}");
        }
    }
}
