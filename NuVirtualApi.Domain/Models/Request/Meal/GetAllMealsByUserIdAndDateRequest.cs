using System.ComponentModel.DataAnnotations;

namespace NuVirtualApi.Domain.Models.Request.Meal
{
    public class GetAllMealsByUserIdAndDateRequest
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
