using Pizza_Assingnment.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Models
{
    public class PizzaDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        // Getting all the Pizza
        public IEnumerable<Pizza> GetAllPizza()
        {
            List<Pizza> lstPizza = new List<Pizza>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllPizza", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while(rdr.Read())
                {
                    Pizza pizza = new Pizza();
                    pizza.Id = Convert.ToInt32(rdr["Pizza_id"]);
                    pizza.Name = rdr["Name"].ToString();
                    pizza.Tomato_Sauce = Convert.ToByte(rdr["Tomato_Sauce"]);
                    pizza.Cheese = Convert.ToByte(rdr["Cheese"]);
                    pizza.Topping_1 = rdr["Topping_1"].ToString();
                    pizza.Topping_2 = rdr["Topping_2"].ToString();
                    pizza.Topping_3 = rdr["Topping_3"].ToString();
                    pizza.Topping_4 = rdr["Topping_4"].ToString();
                    pizza.Topping_5 = rdr["Topping_5"].ToString();
                    pizza.Price_id = Convert.ToInt32(rdr["Price_id"]);

                    lstPizza.Add(pizza);
                }
                con.Close();
            }
            return lstPizza;
        }

        // Add Pizza
        public void AddPizza(Pizza pizza)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddPizza", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", pizza.Name);
                cmd.Parameters.AddWithValue("@Tomato_Sauce", pizza.Tomato_Sauce);
                cmd.Parameters.AddWithValue("@Cheese", pizza.Cheese);
                cmd.Parameters.AddWithValue("@Topping_1", pizza.Topping_1);
                cmd.Parameters.AddWithValue("@Topping_2", pizza.Topping_2);
                cmd.Parameters.AddWithValue("@Topping_3", pizza.Topping_3);
                cmd.Parameters.AddWithValue("@Topping_4", pizza.Topping_4);
                cmd.Parameters.AddWithValue("@Topping_5", pizza.Topping_5);
                cmd.Parameters.AddWithValue("@Price_id", pizza.Price_id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Update Pizza
        public void UpdatePizza(Pizza pizza)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdatePizza", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Pizza_id", pizza.Id);
                cmd.Parameters.AddWithValue("@Name", pizza.Name);
                cmd.Parameters.AddWithValue("@Tomato_Sauce", pizza.Tomato_Sauce);
                cmd.Parameters.AddWithValue("@Cheese", pizza.Cheese);
                cmd.Parameters.AddWithValue("@Topping_1", pizza.Topping_1);
                cmd.Parameters.AddWithValue("@Topping_2", pizza.Topping_2);
                cmd.Parameters.AddWithValue("@Topping_3", pizza.Topping_3);
                cmd.Parameters.AddWithValue("@Topping_4", pizza.Topping_4);
                cmd.Parameters.AddWithValue("@Topping_5", pizza.Topping_5);
                cmd.Parameters.AddWithValue("@Price_id", pizza.Price_id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Get a specific Pizza
        public Pizza GetPizzaData(int? id)
        {
            Pizza pizza = new Pizza();
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Pizza WHERE Pizza_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    pizza.Id = Convert.ToInt32(rdr["Pizza_id"]);
                    pizza.Name = rdr["Name"].ToString();
                    pizza.Tomato_Sauce = Convert.ToByte(rdr["Tomato_Sauce"]);
                    pizza.Cheese = Convert.ToByte(rdr["Cheese"]);
                    pizza.Topping_1 = rdr["Topping_1"].ToString();
                    pizza.Topping_2 = rdr["Topping_2"].ToString();
                    pizza.Topping_3 = rdr["Topping_3"].ToString();
                    pizza.Topping_4 = rdr["Topping_4"].ToString();
                    pizza.Topping_5 = rdr["Topping_5"].ToString();
                    pizza.Price_id = Convert.ToInt32(rdr["Price_id"]);
                }
            }
            return pizza;
        }

        // Delete Pizza
        public void DeletePizza(int? id)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeletePizza", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Pizza_id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
