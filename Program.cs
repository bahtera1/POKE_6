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
                    switch (chr)
                    {
                        case 'K':
                            {
                                SqlConnection conn = null;
                                string strKoneksi = "Data source= LAPTOP-NAUFALAS\\NAUFALAS;"+
                                     "initial catalog = {0};" +
                                    "user ID = {1}; password = {2}";
                                conn = new SqlConnection(string.Format(strKoneksi, db, user, pass));
                                conn.Open();
                                Console.Clear();
                                while (true)
                                {
                                    try
                                    {
                                        Console.WriteLine("\nMenu");
                                        Console.WriteLine("1. Melihat seluruh data");
                                        Console.WriteLine("2. Tambah Data");
                                        Console.WriteLine("3. Keluar");
                                        Console.WriteLine("\nEnter your choice (1-3) : ");
                                        char ch = Convert.ToChar(Console.ReadLine());
                                        switch (ch)
                                        {

                                        }
                                }
                            }
                    }
                }
            }
        }

    }


}
 