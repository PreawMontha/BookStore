using MySql.Data.MySqlClient;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace BookStore.Model
{
    public class Products
    {
        public string? ProductName { get; set; }
        public int Price { get; set; }


        public List<Products> GetProductData()
        {
            MySqlConnection conn;
            string server = "localhost";
            string database = "bookstore";
            string uid = "root";
            string password = "12345678";
            string connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";SSL Mode=None;";
            conn = new MySqlConnection(connectionString);
            conn.Open();

            string sqlCmd = "SELECT ProductName, Price FROM products LIMIT 3 ";
            MySqlCommand cmd = new MySqlCommand(sqlCmd, conn);
            MySqlDataReader dr = cmd.ExecuteReader();

            /* Products product = new Products();*/
            List<Products> productsList = new List<Products>();
            while (dr.Read())
            {
                Products productsItem = new Products();
                productsItem.ProductName = dr["ProductName"].ToString();
                productsItem.Price = Convert.ToInt32(dr["Price"].ToString());


                productsList.Add(productsItem);
            }
            conn.Close();
            return productsList;
        }
    }
}


