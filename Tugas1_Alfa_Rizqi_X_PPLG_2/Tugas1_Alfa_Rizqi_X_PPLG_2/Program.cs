using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas1_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        /*Buat fungsi bernama Kali yang menerima tiga bilangan dan menampilkan hasil 
        perkalian! */
        static double Kali(double a, double b, double c)
        {
            return a * b * c;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Perkalian dengan tiga bilangan");
            Console.Write("Masukkan bilangan pertama: ");
            double bil1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Masukkan bilangan kedua: ");
            double bil2 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Masukkan bilangan ketiga: ");
            double bil3 = Convert.ToDouble(Console.ReadLine());
            double hasil = Kali(bil1, bil2, bil3);
            Console.WriteLine("Hasil perkalian: " + hasil);
        }
    }
}
