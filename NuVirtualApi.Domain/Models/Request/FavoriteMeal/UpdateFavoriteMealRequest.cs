using NuVirtualApi.Database.Enums;

namespace NuVirtualApi.Domain.Models.Request.FavoriteMeal
{
    public class UpdateFavoriteMealRequest
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public MealTypeEnum Type { get; set; }
		public int Carbohydrate { get; set; }
		public int Lipid { get; set; }
		public int Protein { get; set; }
		public int Calorie { get; set; }
		public int UserId { get; set; }
		public int MealId { get; set; }
	}
}
