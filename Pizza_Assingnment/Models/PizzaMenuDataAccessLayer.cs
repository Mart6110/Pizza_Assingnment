using Pizza_Assingnment.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Models
{
    public class PizzaMenuDataAccessLayer
    {
        //variable named connectionString, there is set equal to the ConnectionString used to make the connection to the database
        string connectionString = ConnectionString.CName;

        //eunumerable there interakts with the public class PizzaMenu
        //this is used to get all data from the table in the database
        public IEnumerable<PizzaMenu> GetAllPizzaMenu()
        {
            //make a list named lstPizzaMenu from the PizzaMenu class
            List<PizzaMenu> lstPizzaMenu = new List<PizzaMenu>();

            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                //open the connection to the database
                //make a SQL data reader, named rdr and sets it to SQL command and execute the command
                SqlCommand cmd = new SqlCommand("spGetAllMenuPizza", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //while loop there runs when the SQL data reader works through the database
                while (rdr.Read())
                {
                    //makes a object 
                    //asign the object name and values
                    //and add the object to the list
                    PizzaMenu pizzaMenu = new PizzaMenu();
                    pizzaMenu.Id = Convert.ToInt32(rdr["Pizza_id"]);
                    pizzaMenu.Name = rdr["Name"].ToString();
                    pizzaMenu.Toppings = rdr["Toppings"].ToString();
                    pizzaMenu.Price = Convert.ToInt32(rdr["Price"]);

                    lstPizzaMenu.Add(pizzaMenu);
                }
                //close the connection to the database
                con.Close();
            }
            //return the data to the list
            return lstPizzaMenu;
        }
    }
}
