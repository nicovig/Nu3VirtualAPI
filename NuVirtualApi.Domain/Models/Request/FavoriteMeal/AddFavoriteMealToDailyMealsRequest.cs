using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.FavoriteMeal
{
    public class AddFavoriteMealToDailyMealsRequest
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int FavoriteMealId { get; set; }
        public int UserId { get; set; }
        
    }
}
