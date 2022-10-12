using Pizza_Assingnment.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Models
{
    public class DrinkMenuDataAccessLayer
    {
        //variable named connectionString, there is set equal to the ConnectionString used to make the connection to the database
        string connectionString = ConnectionString.CName;

        //eunumerable there interakts with the public class DrinkMenu
        //this is used to get all data from the table in the database
        public IEnumerable<DrinkMenu> GetAllDrinkMenu()
        {
            //make a list named lstDrinkMenu from the DrinkMenu class
            List<DrinkMenu> lstDrinkMenu = new List<DrinkMenu>();

            //naming the sqlConnection named con, and make a new connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //make the SQL command, and select wiich connection to use
                //asign the SQL command a commandtype
                //open the connection to the database
                //make a SQL data reader, named rdr and sets it to SQL command and execute the command
                SqlCommand cmd = new SqlCommand("spGetAllMenuDrink", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                //while loop there runs when the SQL data reader works through the database
                while (rdr.Read())
                {
                    //makes a object 
                    //asign the object name and values
                    //and add the object to the list
                    DrinkMenu drinkMenu = new DrinkMenu();
                    drinkMenu.Id = Convert.ToInt32(rdr["Drink_id"]);
                    drinkMenu.Name = rdr["Name"].ToString();
                    drinkMenu.Size = Convert.ToInt32(rdr["Size"]);
                    drinkMenu.Price = Convert.ToInt32(rdr["Price"]);

                    lstDrinkMenu.Add(drinkMenu);
                }
                //close the connection to the database
                con.Close();
            }
            //return the data to the list
            return lstDrinkMenu;
        }
    }
}
