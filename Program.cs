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
                                            case '1':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("DATA TIKET KERETA\n");
                                                    Console.WriteLine();
                                                    pr.baca(conn);
                                                    conn.Close();
                                                }
                                                break;
                                            case '2':
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("INPUT DATA PENGGUNA\n");
                                                    Console.WriteLine("MASUKAN NIK:");
                                                    string NIM = Console.ReadLine();
                                                    Console.WriteLine("INPUT NAMA PENGGUNA");
                                                    string NmaMhs = Console.ReadLine();
                                                    Console.WriteLine("Masukan Alamat Pengguna : ");
                                                    string almt = Console.ReadLine();
                                                    Console.WriteLine("Masukan Jenis Kelamin (L/P):");
                                                    string jk = Console.ReadLine();
                                                    Console.WriteLine("Masukan No Telepon : ");
                                                    string notlpn = Console.ReadLine();
                                                    Console.WriteLine("Masukan ID Pesanan");
                                                    string idpesanan = Console.ReadLine();

                                                    try
                                                    {
                                                        pr.insert(NIM, NmaMhs, almt, jk, notlpn, conn);
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\n Anda tidak memiliki" + "akses untuk menambah data");
                                                    }

                                                }
                                                break;

                                        }
                                }
                            }
                    }
                }
            }
        }

    }


}
 