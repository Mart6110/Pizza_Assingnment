using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Utility
{
    public static class ConnectionString
    {
        private static string cName = "Data Source=PIZZASERVER;Initial Catalog=ZBCPizza;User ID=sa;Password=Kode12345!";
        public static string CName { get => cName; }
    }
}
