using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ShoesEcomm.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string PrimaryImg { get; set; }

        public string Gallery1Img { get; set;}

        public string Gallery2Img { get; set;}

        public bool Hidden { get; set; }

        public static List<Product> GetProducts(bool all)
        {
            SqlConnection con = Connection.ConnectDB();
            List<Product> products = new List<Product>();


            try
            {
                con.Open();

                SqlDataReader reader = Connection.Reader(all, con);

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Product p = new Product()
                        {
                            Id = Convert.ToInt32(reader["Idarticolo"]),
                            Name = reader["NomeArticolo"].ToString(),
                            Price = Convert.ToDecimal(reader["Prezzo"]),
                            Description = reader["Descrizione"].ToString(),
                            PrimaryImg = reader["URLImgFront"].ToString(),
                            Gallery1Img = reader["URLGallery1"].ToString(),
                            Gallery2Img = reader["URLGallery2"].ToString(),
                            Hidden = Convert.ToBoolean(reader["Esposto"])
                        };

                        products.Add(p);
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            con.Close();
            return products;
        }

        


    }
}