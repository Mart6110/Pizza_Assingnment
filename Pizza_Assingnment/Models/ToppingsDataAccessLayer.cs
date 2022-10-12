using Pizza_Assingnment.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Pizza_Assingnment.Models
{
    //public class named (the name of the DB table)DataAccessLayer
    public class ToppingsDataAccessLayer
    {
        //variable named connectionString, there is set equal to the ConnectionString used to make the connection to the database
        string connectionString = ConnectionString.CName;

        //eunumerable there interakts with the public class Toppings
        //this is used to get all data from the Toppings table in the database
        public IEnumerable<Toppings> GetAllTopping()
        {
            //make a list named lstToppings from the Toppings class
            List<Toppings> lstToppings = new List<Toppings>();

            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                //open the connection to the database
                //make a SQL data reader, named rdr and sets it to SQL command and execute the command
                SqlCommand cmd = new SqlCommand("spGetAllTopping", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //while loop there runs when the SQL data reader works through the database
                while (rdr.Read())
                {
                    //makes a object 
                    //asign the object name and values
                    //and add the object to the list
                    Toppings toppings = new Toppings();
                    toppings.Id = Convert.ToInt32(rdr["Id"]);
                    toppings.Name = rdr["Name"].ToString();
                    toppings.Price_Id = Convert.ToInt32(rdr["Price_Id"]);

                    lstToppings.Add(toppings);
                }
                //close the connection to the database
                con.Close();
            }
            //return the data to the list
            return lstToppings;
        }

        //method to add data to the DB table

        public void AddTopping(Toppings toppings)
        {
            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                SqlCommand cmd = new SqlCommand("spAddTopping", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //values are added to the parameters
                //first the connection to the DB is opened
                //the stored procedure is run with the parameters
                //connection is closed
                cmd.Parameters.AddWithValue("@Toppings_id", toppings.Id);
                cmd.Parameters.AddWithValue("@Name", toppings.Name);
                cmd.Parameters.AddWithValue("@Price_Id", toppings.Price_Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }


        //method to update the database table
        public void UpdateTopping(Toppings toppings)
        {
            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                SqlCommand cmd = new SqlCommand("spUpdateTopping", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //values are added to the parameters
                //first the connection to the DB is opened
                //the stored procedure is run with the parameters
                //connection is closed
                cmd.Parameters.AddWithValue("@Toppings_id", toppings.Id);
                cmd.Parameters.AddWithValue("@Name", toppings.Name);
                cmd.Parameters.AddWithValue("@Price_Id", toppings.Price_Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //public class to get data from the database
        public Toppings GetToppingsData(int? Id)
        {
            //makes a object
            Toppings toppings = new Toppings();

            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                //open the connection to the database
                //make a SQL data reader, named rdr and sets it to SQL command and execute the command
                string sqlQuery = "SELECT * FROM Toppings WHERE Toppings_id=" + Id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //while loop there runs when the SQL data reader works through the database
                while (rdr.Read())
                {
                    //asign the object name and values
                    //and add the object to the list
                    toppings.Id = Convert.ToInt32(rdr["Toppings_id"]);
                    toppings.Name = rdr["Name"].ToString();
                    toppings.Price_Id = Convert.ToInt32(rdr["Price_Id"]);
                }
            }
            //return the data to the object
            return toppings;
        }

        //method to delete data from the database table
        public void DeleteToppings(int? Id)
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
                SqlCommand cmd = new SqlCommand("spDeleteToppings", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Toppings_id", Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
