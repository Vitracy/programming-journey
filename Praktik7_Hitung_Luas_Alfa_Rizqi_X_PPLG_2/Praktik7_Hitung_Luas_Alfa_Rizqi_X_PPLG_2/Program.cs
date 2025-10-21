using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik7_Hitung_Luas_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        /*Contoh penggunaan fungsi membuat program sederhana 
        Menghitung Luas Persegi Panjang Menggunakan Fungsi 
        Deskripsi: 
        Buatlah program untuk menghitung luas persegi panjang dengan menggunakan 
        fungsi. 
        Program harus meminta input panjang dan lebar, lalu memanggil fungsi 
        HitungLuas untuk menghitung dan menampilkan hasilnya. 
        Nama file : fungsi_hitung_luas */

        static double HitungLuas(double panjang, double lebar)
        {
            double luas = panjang * lebar;
            return luas;
        }

        static void Main(string[] args)
        {
            Console.Write("Masukkan panjang persegi panjang: ");
            double p = Convert.ToDouble(Console.ReadLine());

            Console.Write("Masukkan lebar persegi panjang: ");
            double l = Convert.ToDouble(Console.ReadLine());

            double hasil = HitungLuas(p, l);
            Console.WriteLine("Luas persegi panjang adalah: " + hasil);
        }
    }
}
