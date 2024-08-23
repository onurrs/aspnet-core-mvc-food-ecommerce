using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Data.Models
{
	public class Category
	{
		public int CategoryID { get; set; }
		public string CategoryName { get; set; }
		public string? CategoryDescription { get; set; }

        public bool Status { get; set; }

        public List<Food> Foods { get; set; }
	}
}
