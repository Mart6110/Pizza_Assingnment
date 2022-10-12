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
    public class DrinkDataAccessLayer
    {
        //variable named connectionString, there is set equal to the ConnectionString used to make the connection to the database
        string connectionString = ConnectionString.CName;

        //eunumerable there interakts with the public class Prices
        //this is used to get all data from the table in the database
        public IEnumerable<Drink> GetAllDrink()
        {
            //make a list named lstPrices from the Prices class
            List<Drink> lstDrink = new List<Drink>();

            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                //open the connection to the database
                //make a SQL data reader, named rdr and sets it to SQL command and execute the command
                SqlCommand cmd = new SqlCommand("spGetAllDrink", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //while loop there runs when the SQL data reader works through the database
                while (rdr.Read())
                {
                    //makes a object 
                    //asign the object name and values
                    //and add the object to the list
                    Drink drink = new Drink();
                    drink.Id = Convert.ToInt32(rdr["Drink_id"]);
                    drink.Name = rdr["Name"].ToString();
                    drink.Size = Convert.ToInt32(rdr["Size"]);
                    drink.Price_id = Convert.ToInt32(rdr["Price_id"]);

                    lstDrink.Add(drink);
                }
                //close the connection to the database
                con.Close();
            }
            //return the data to the list
            return lstDrink;
        }

        // Add Drink
        public void AddDrink(Drink drink)
        {
            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                SqlCommand cmd = new SqlCommand("spAddDrink", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //values are added to the parameters
                //first the connection to the DB is opened
                //the stored procedure is run with the parameters
                //connection is closed
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
            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                SqlCommand cmd = new SqlCommand("spUpdateDrink", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //values are added to the parameters
                //first the connection to the DB is opened
                //the stored procedure is run with the parameters
                //connection is closed
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
            //makes a object
            Drink drink = new Drink();

            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                //open the connection to the database
                //make a SQL data reader, named rdr and sets it to SQL command and execute the command
                string sqlQuery = "SELECT * FROM Drink WHERE Drink_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //while loop there runs when the SQL data reader works through the database
                while (rdr.Read())
                {
                    //asign the object name and values
                    //and add the object to the list
                    drink.Id = Convert.ToInt32(rdr["Drink_id"]);
                    drink.Name = rdr["Name"].ToString();
                    drink.Size = Convert.ToInt32(rdr["Size"]);
                    drink.Price_id = Convert.ToInt32(rdr["Price_id"]);
                }
            }
            //return the data to the object
            return drink;
        }

        // Delete Drink
        public void DeleteDrink(int? id)
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
