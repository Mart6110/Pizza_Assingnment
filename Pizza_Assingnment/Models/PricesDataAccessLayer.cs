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
    public class PricesDataAccessLayer
    {
        //variable named connectionString, there is set equal to the ConnectionString used to make the connection to the database
        string connectionString = ConnectionString.CName;

        //eunumerable there interakts with the public class Prices
        //this is used to get all data from the table in the database
        public IEnumerable<Prices> GetAllPrices()
        {
            //make a list named lstPrices from the Prices class
            List<Prices> lstPrices = new List<Prices>();

            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                //open the connection to the database
                //make a SQL data reader, named rdr and sets it to SQL command and execute the command
                SqlCommand cmd = new SqlCommand("spGetAllPrice", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //while loop there runs when the SQL data reader works through the database
                while (rdr.Read())
                {
                    //makes a object 
                    //asign the object name and values
                    //and add the object to the list
                    Prices prices = new Prices();
                    prices.Id = Convert.ToInt32(rdr["Price_id"]);
                    prices.Price = Convert.ToInt32(rdr["Price"]);

                    lstPrices.Add(prices);
                }
                //close the connection to the database
                con.Close();
            }
            //return the data to the list
            return lstPrices;
        }

        //method to add data to the DB table
        public void AddPrice(Prices prices)
        {
            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                SqlCommand cmd = new SqlCommand("spAddPrice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //values are added to the parameters
                //first the connection to the DB is opened
                //the stored procedure is run with the parameters
                //connection is closed
                cmd.Parameters.AddWithValue("@Price", prices.Price);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //method to update the database table
        public void UpdatePrice(Prices prices)
        {
            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                SqlCommand cmd = new SqlCommand("spUpdatePrice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                //values are added to the parameters
                //first the connection to the DB is opened
                //the stored procedure is run with the parameters
                //connection is closed
                cmd.Parameters.AddWithValue("@Price_id", prices.Id);
                cmd.Parameters.AddWithValue("@Price", prices.Price);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //public class to get data from the database
        public Prices GetPricesData(int? id)
        {
            //makes a object
            Prices prices = new Prices();

            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                //open the connection to the database
                //make a SQL data reader, named rdr and sets it to SQL command and execute the command
                string sqlQuery = "SELECT * FROM Price WHERE Price_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //while loop there runs when the SQL data reader works through the database
                while (rdr.Read())
                {
                    //asign the object name and values
                    //and add the object to the list
                    prices.Id = Convert.ToInt32(rdr["Price_id"]);
                    prices.Price = Convert.ToInt32(rdr["Price"]);
                }
            }
            //return the data to the object
            return prices;
        }

        //method to delete data from the database table
        public void DeletePrice(int? id)
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
