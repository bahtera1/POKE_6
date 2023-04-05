using System;
using System.Data;
using System.Data.SqlClient;

namespace POKE_6
{
    class program
    {
        static void Main(string[] args)
        {
            program pr=new program();
            while(true)
            {
                try
                {
                    Console.WriteLine("Koneksi Ke Database\n");
                    Console.WriteLine("Masukan User ID");
                    string user = Console.ReadLine();
                    Console.WriteLine("Masukan Password");
                    string pass = Console.ReadLine();
                    Console.WriteLine("Masukan Database Tujuan:");
                    string db = Console.ReadLine();
                    Console.Write("\n Ketik K untuk tergubung ke database: ");
                    char chr = Convert.ToChar(Console.ReadLine());
                }
            }
        }

    }


}
 