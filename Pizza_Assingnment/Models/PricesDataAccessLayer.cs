using Pizza_Assingnment.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Models
{
    public class PricesDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        // Getting all the prices
        public IEnumerable<Prices> GetAllPrices()
        {
            List<Prices> lstPrices = new List<Prices>();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllPrice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    Prices prices = new Prices();
                    prices.Id = Convert.ToInt32(rdr["Price_id"]);
                    prices.Price = Convert.ToInt32(rdr["Price"]);

                    lstPrices.Add(prices);
                }
                con.Close();
            }
            return lstPrices;
        }

        // Add Price
        public void AddPrice(Prices prices)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddPrice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Price", prices.Price);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Update Price
        public void UpdatePrice(Prices prices)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdatePrice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Price_id", prices.Id);
                cmd.Parameters.AddWithValue("@Price", prices.Price);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Get a specific price
        public Prices GetPricesData(int? id)
        {
            Prices prices = new Prices();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Price WHERE Price_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    prices.Id = Convert.ToInt32(rdr["Price_id"]);
                    prices.Price = Convert.ToInt32(rdr["Price"]);
                }
            }
            return prices;
        }

        public void DeletePrice(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeletePrice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Price_id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
