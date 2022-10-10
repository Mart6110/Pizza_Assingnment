using Pizza_Assingnment.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Pizza_Assingnment.Models
{
    public class ToppingsDataAccessLayer
    {
        string connectionString = ConnectionString.CName;

        public IEnumerable<Toppings> GetAllTopping()
        {
            List<Toppings> lstToppings = new List<Toppings>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllTopping", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Toppings toppings = new Toppings();
                    toppings.Id = Convert.ToInt32(rdr["Id"]);
                    toppings.Name = rdr["Name"].ToString();
                    toppings.Price_Id = Convert.ToInt32(rdr["Price_Id"]);

                    lstToppings.Add(toppings);
                }
                con.Close();
            }
            return lstToppings;
        }
        //method to add toppings
        //values are added to the parameters
        //first the connection to the DB is opened
        //the stored procedure is run with the parameters
        //connection is closed
        public void AddTopping(Toppings toppings)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddTopping", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Toppings_id", toppings.Id);
                cmd.Parameters.AddWithValue("@Name", toppings.Name);
                cmd.Parameters.AddWithValue("@Price_Id", toppings.Price_Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateTopping(Toppings toppings)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spUpdateTopping", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Toppings_id", toppings.Id);
                cmd.Parameters.AddWithValue("@Name", toppings.Name);
                cmd.Parameters.AddWithValue("@Price_Id", toppings.Price_Id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Toppings GetToppingsData(int? Id)
        {
            Toppings toppings = new Toppings();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Toppings WHERE Toppings_id=" + Id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    toppings.Id = Convert.ToInt32(rdr["Toppings_id"]);
                    toppings.Name = rdr["Name"].ToString();
                    toppings.Price_Id = Convert.ToInt32(rdr["Price_Id"]);
                }
            }
            return toppings;
        }

        public void DeleteToppings(int? Id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
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
