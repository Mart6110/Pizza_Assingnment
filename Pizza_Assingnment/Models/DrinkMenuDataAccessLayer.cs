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
        string connectionString = ConnectionString.CName;

        public IEnumerable<DrinkMenu> GetAllDrinkMenu()
        {
            List<DrinkMenu> lstDrinkMenu = new List<DrinkMenu>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllMenuDrink", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DrinkMenu drinkMenu = new DrinkMenu();
                    drinkMenu.Id = Convert.ToInt32(rdr["Drink_id"]);
                    drinkMenu.Name = rdr["Name"].ToString();
                    drinkMenu.Size = Convert.ToInt32(rdr["Size"]);
                    drinkMenu.Price = Convert.ToInt32(rdr["Price"]);

                    lstDrinkMenu.Add(drinkMenu);
                }
                con.Close();
            }
            return lstDrinkMenu;
        }
    }
}
