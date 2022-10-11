﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Models
{
    public class DrinkMenu
    {
        public int Id { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public int Size { set; get; }
        [Required]
        public int Price { set; get; }
    }
}
