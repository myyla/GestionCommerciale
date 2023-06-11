using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;
namespace Projet_NET
{
    internal class Class1
    {
        private string cnxString;
        private SqlConnection cnx;
        private SqlCommand cnxCmd;
        private DataTable dt;
        private SqlDataAdapter sda;

        public Class1()
        {
            cnxString = "Data Source=DESKTOP-FJ4UE8I\\SQLEXPRESS01;Initial Catalog=GESTION;Integrated Security=True";
           
            cnxCmd = new SqlCommand();
            cnxCmd.Connection = cnx;
        }


        public DataTable recupere_data(String Req)
        {       
            dt = new DataTable();
            sda = new SqlDataAdapter(Req, cnxString);
            sda.Fill(dt);
            return dt;

        }
         public int Envoyer_donnée(String Req)
        {
            int cnt = 0;
            if (cnx.State == ConnectionState.Closed)
            {
                cnx.Open();
            }
                cnxCmd.CommandText = Req;
                cnt = cnxCmd.ExecuteNonQuery();
                return cnt;

          }
        }
    }





