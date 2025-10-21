using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tugas2_Alfa_Rizqi_X_PPLG_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int total = 0;
            int penambah = 1;
            Console.WriteLine("Total saat ini: " + total);
            while (total < 15)
            {
                Console.WriteLine("Total ditambahkan dengan: " + penambah);
                total = total + penambah;
                penambah = penambah + 1;
                Console.WriteLine("Total saat ini:" + total + "\n");
            }
            Console.WriteLine("\nTotal = " + total);
        }
    }
}
