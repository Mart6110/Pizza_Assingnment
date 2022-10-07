using Pizza_Assingnment.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Models
{
    public class DrinkDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        // Get all Drink
        public IEnumerable<Drink> GetAllDrink()
        {
            List<Drink> lstDrink = new List<Drink>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllDrink", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Drink drink = new Drink();
                    drink.Id = Convert.ToInt32(rdr["Drink_id"]);
                    drink.Name = rdr["Name"].ToString();
                    drink.Size = Convert.ToInt32(rdr["Size"]);
                    drink.Price_id = Convert.ToInt32(rdr["Price_id"]);

                    lstDrink.Add(drink);
                }
                con.Close();
            }
            return lstDrink;
        }

        // Add Drink
        public void AddDrink(Drink drink)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddDrink", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", drink.Name);
                cmd.Parameters.AddWithValue("@Size", drink.Size);
                cmd.Parameters.AddWithValue("@Price_id", drink.Price_id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Update Drink
        public void UpdateDrink(Drink drink)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateDrink", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Drink_id", drink.Id);
                cmd.Parameters.AddWithValue("@Name", drink.Name);
                cmd.Parameters.AddWithValue("@Size", drink.Size);
                cmd.Parameters.AddWithValue("@Price_id", drink.Price_id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Get a specific Pizza
        public Drink GetDrinkData(int? id)
        {
            Drink drink = new Drink();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Drink WHERE Drink_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    drink.Id = Convert.ToInt32(rdr["Drink_id"]);
                    drink.Name = rdr["Name"].ToString();
                    drink.Size = Convert.ToInt32(rdr["Size"]);
                    drink.Price_id = Convert.ToInt32(rdr["Price_id"]);
                }
            }
            return drink;
        }

        // Delete Drink
        public void DeleteDrink(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteDrink", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Drink_id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
