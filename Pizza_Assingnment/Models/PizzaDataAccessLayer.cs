using Pizza_Assingnment.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Models
{
    //public class named (the name of the DB table)DataAccessLayer
    public class PizzaDataAccessLayer
    {
        //variable named connectionString, there is set equal to the ConnectionString used to make the connection to the database
        string connectionString = ConnectionString.CName;

        //eunumerable there interakts with the public class Pizza
        //this is used to get all data from the table in the database
        public IEnumerable<Pizza> GetAllPizza()
        {
            //make a list named lstPizza from the Pizza class
            List<Pizza> lstPizza = new List<Pizza>();

            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                //open the connection to the database
                //make a SQL data reader, named rdr and sets it to SQL command and execute the command
                SqlCommand cmd = new SqlCommand("spGetAllPizza", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //while loop there runs when the SQL data reader works through the database
                while (rdr.Read())
                {
                    //makes a object 
                    //asign the object name and values
                    //and add the object to the list
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
                //close the connection to the database
                con.Close();
            }
            //return the data to the list
            return lstPizza;
        }

        //method to add data to the DB table
        public void AddPizza(Pizza pizza)
        {
            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                SqlCommand cmd = new SqlCommand("spAddPizza", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //values are added to the parameters
                //first the connection to the DB is opened
                //the stored procedure is run with the parameters
                //connection is closed
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
            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                SqlCommand cmd = new SqlCommand("spUpdatePizza", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //values are added to the parameters
                //first the connection to the DB is opened
                //the stored procedure is run with the parameters
                //connection is closed
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
            //makes a object
            Pizza pizza = new Pizza();

            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                //open the connection to the database
                //make a SQL data reader, named rdr and sets it to SQL command and execute the command'
                string sqlQuery = "SELECT * FROM Pizza WHERE Pizza_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //while loop there runs when the SQL data reader works through the database
                while (rdr.Read())
                {
                    //asign the object name and values
                    //and add the object to the list
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
            //return the data to the object
            return pizza;
        }

        // Delete Pizza
        public void DeletePizza(int? id)
        {
            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                //values are added to the parameters
                //first the connection to the DB is opened
                //the stored procedure is run with the parameters
                //connection is closed
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
