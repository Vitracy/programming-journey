using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas2_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        // Buat fungsi RataRata yang menerima tiga nilai dan mengembalikan hasil rata-ratanya! 
        static double rataRata(double a, double b, double c)
        {
            double hasil = (a + b + c) / 3;
            return hasil;
        }
        static void Main(string[] args)
        {
            double nilai1, nilai2, nilai3;
            Console.WriteLine("Program Menghitung Rata-Rata dari Tiga Nilai");

            Console.Write("Masukkan nilai pertama: ");
            nilai1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Masukkan nilai kedua: ");
            nilai2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Masukkan nilai ketiga: ");
            nilai3 = Convert.ToDouble(Console.ReadLine());

            double hasilRataRata = rataRata(nilai1, nilai2, nilai3);
            Console.WriteLine("Rata-rata dari ketiga nilai tersebut adalah: " + hasilRataRata);
        }
    }
}
