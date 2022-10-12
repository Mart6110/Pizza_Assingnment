using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Models
{
    //public class named Prices
    public class Prices
    {
        //variables with get and set
        public int Id { get; set; }
        [Required]
        public int Price { get; set; }
    }
}
