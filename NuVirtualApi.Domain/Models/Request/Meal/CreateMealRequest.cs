using NuVirtualApi.Database.Enums;
using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.Meal
{
    public class CreateMealRequest
    {
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public int Type { get; set; }
		public bool IsFavorite { get; set; }
		[Required]
		public DateTime Date { get; set; }
		public int Carbohydrate { get; set; }
		public int Lipid { get; set; }
		public int Protein { get; set; }
		public int Calorie { get; set; }
		public string Notes { get; set; }
		[Required]
		public int UserId { get; set; }
	}
}
