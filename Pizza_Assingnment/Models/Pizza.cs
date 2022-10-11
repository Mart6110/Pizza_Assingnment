using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pizza_Assingnment.Models
{
	public class Pizza
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public byte Tomato_Sauce { get; set; }
		[Required]
		public byte Cheese { get; set; }
		public string Topping_1 { get; set; }
		public string Topping_2 { get; set; }
		public string Topping_3 { get; set; }
		public string Topping_4 { get; set; }
		public string Topping_5 { get; set; }
		[Required]
		public int Price_id { get; set; }

	}
}
