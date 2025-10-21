using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik6._5_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Perulangan do while 
            Menampilkan angka dari 1 sampai dengan 20*/

            // 1. Inisialisasi variabel penghitung (counter)
            int angka = 1;

            Console.WriteLine("Menampilkan angka dari 1 sampai dengan 20 menggunakan perulangan do while:");

            // 2. Perulangan 'do while'
            do
            {
                // Tampilkan nilai variable 'angka' saat ini
                Console.WriteLine(angka);

                // Increment nilai variable 'angka' sebesar 1
                angka++;
                // Uji kondisi: Loop berlanjut selama 'angka' kurang dari atau sama dengan 20
            } while (angka <= 20);

            Console.WriteLine("Selesai.");
        }
    }
}
