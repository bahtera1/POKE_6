using System;
using System.Data;
using System.Data.SqlClient;

namespace POKE_6
{
    class program
    {
        static void Main(string[] args)
        {
            program pr = new program();
            while (true)
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
                    Console.Write("\n Ketik A untuk tergubung ke database: ");
                    char chr = Convert.ToChar(Console.ReadLine());
                    switch (chr)
                    {
                        case 'A':
                            {
                                SqlConnection conn = null;
                                string strKoneksi = "Data source= LAPTOP-NAUFALAS\\NAUFALAS;" +
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
                                                    string NIK = Console.ReadLine();
                                                    Console.WriteLine("INPUT NAMA PENGGUNA");
                                                    string nama = Console.ReadLine();
                                                    Console.WriteLine("Masukan Alamat Pengguna : ");
                                                    string almt = Console.ReadLine();
                                                    Console.WriteLine("Masukan Tanggal Lahir : ");
                                                    string tanggallahir = Console.ReadLine();
                                                    Console.WriteLine("Masukan Jenis Kelamin (L/P):");
                                                    string jk = Console.ReadLine();
                                                    Console.WriteLine("Masukan No Telepon : ");
                                                    string notlpn = Console.ReadLine();

                                                    try
                                                    {
                                                        pr.insert(NIK, nama, almt, tanggallahir, jk, notlpn, conn);
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("\n Anda tidak memiliki" + "akses untuk menambah data");
                                                    }

                                                }
                                                break;

                                            case '3':
                                                conn.Close();
                                                return;
                                            default:
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("\n Invalid Option");
                                                }
                                                break;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("\n Check for the value entered");
                                    }
                                }
                            }
                        default:
                            {
                                Console.WriteLine("\n Invalid Option");
                            }
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Tidak sDsssapat errngasskssasaea saDatxxsasaabase Menggunakan User Tersebut\n");
                    Console.WriteLine("Tidak sDapasaa3tassa  Drata Tersebut\n");
                    Console.ResetColor();
                }
            }
        }

        public void baca(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand("Select * from pengguna", con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                for (int i = 0; i < r.FieldCount; i++)
                {
                    Console.WriteLine(r.GetValue(i));
                }
                Console.WriteLine();
            }
        }

        public void insert(string NIK, string nama, string Almt, string jk, string tanggallahir, string notlpn, SqlConnection con)
        {
            string str = "";
            str = "insert into pengguna (nama_pengguna,Alamat_pengguna,Jenis_kelamin,Tanggal_lahir,no_telp,NIK"
                + "values(@nama_pengguna,@Alamat_pengguna,@Jenis_kelamin,@Tanggal_lahir,@no_telp,@NIK";
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add(new SqlParameter("NIK", NIK));
            cmd.Parameters.Add(new SqlParameter("nma", nama));
            cmd.Parameters.Add(new SqlParameter("alamat", Almt));
            cmd.Parameters.Add(new SqlParameter("tanggal lahir", tanggallahir));
            cmd.Parameters.Add(new SqlParameter("JK", jk));
            cmd.Parameters.Add(new SqlParameter("Phn", notlpn));
            cmd.ExecuteNonQuery();
            Console.WriteLine("Data Berhasil Ditambahkan");
        }



    }


}
