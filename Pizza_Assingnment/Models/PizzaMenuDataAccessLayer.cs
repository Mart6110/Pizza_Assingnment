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
        string connectionString = ConnectionString.CName;

        public IEnumerable<PizzaMenu> GetAllPizzaMenu()
        {
            List<PizzaMenu> lstPizzaMenu = new List<PizzaMenu>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllMenuPizza", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    PizzaMenu pizzaMenu = new PizzaMenu();
                    pizzaMenu.Id = Convert.ToInt32(rdr["Pizza_id"]);
                    pizzaMenu.Name = rdr["Name"].ToString();
                    pizzaMenu.Toppings = rdr["Toppings"].ToString();
                    pizzaMenu.Price = Convert.ToInt32(rdr["Price"]);

                    lstPizzaMenu.Add(pizzaMenu);
                }
                con.Close();
            }
            return lstPizzaMenu;
        }
    }
}
