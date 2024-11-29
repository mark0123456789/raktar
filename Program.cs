using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace raktar
{
    internal class Program
    {
        public static Connect conn = new Connect();
        public static void Eszkozok()
        {
            conn.Connection.Open();
            string sql = "SELECT * FROM `eszkozok`";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();

            do
            {
                var eszkozok = new
                {
                    Id = dr.GetInt32(0),
                    AlkatreszNev = dr.GetString(1),
                    AlkatreszAr = dr.GetInt32(2),
                    AlkatreszGyarto = dr.GetString(3),
                    AlkatreszTipus = dr.GetString(4),
                    Felveve = dr.GetDateTime(5)
                };

                Console.WriteLine($"A raktárban elérhető termékek: {eszkozok.AlkatreszNev}, {eszkozok.AlkatreszAr}Ft, {eszkozok.AlkatreszGyarto}, {eszkozok.AlkatreszTipus}, Adatbázisba véve: {eszkozok.Felveve}");
            }
            while (dr.Read());



            dr.Close();



            conn.Connection.Close();
        }


        static void Main(string[] args)
        {
            Eszkozok();
            Console.ReadKey();
        }
    }
}