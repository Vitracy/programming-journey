using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praktik1._5_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input Nama Siswa");
            Console.Write("Nama Siswa : ");
            string nama = Console.ReadLine();
            Console.Write("Jenis Kelamin : ");
            string jk = Console.ReadLine();
            Console.Write("Kelas : ");
            string kelas = Console.ReadLine();
            Console.Write("Jurusan : ");
            string jurusan = Console.ReadLine();
            Console.WriteLine("********************");
            Console.WriteLine("     DATA SISWA"     );
            Console.WriteLine("********************");
            Console.WriteLine("Nama Siswa       :" + nama);
            Console.WriteLine("Jenis Kelamin    :" + jk);
            Console.WriteLine("Kelas            :" + kelas);
            Console.WriteLine("Jurusan          :" + jurusan);
        }
    }
}
