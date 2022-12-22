using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoesEcomm.Models
{
    public class Connection
    {
        public static SqlConnection ConnectDB()
        {
            string ConStringName = ConfigurationManager.ConnectionStrings["DBConnection"].ToString();
            SqlConnection con = new SqlConnection(ConStringName);
            return con;
        }

        public static SqlDataReader Reader(bool all, SqlConnection connection)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            if(all)
            {
                cmd.CommandText = "SELECT * FROM ArticoloTab";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM ArticoloTab WHERE Esposto = 1";
            }

            SqlDataReader reader = cmd.ExecuteReader();

            return reader;
        }
    }
}