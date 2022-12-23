using NuVirtualApi.Database;
using NuVirtualApi.Domain.Interfaces.Manager;
using NuVirtualApi.Domain.Models.Request.Meal;
using NuVirtualApi.Domain.Models.Response.Meal;

namespace NuVirtualApi.Domain.Managers
{
    public class MealManager : IMealManager
    {
        private readonly DatabaseContext _databaseContext;

        public MealManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool CreateMeal(CreateMealRequest request)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMeal(int mealId)
        {
            throw new NotImplementedException();
        }

        public List<MealViewModel> GetAllMealsByUserIdAndDate(GetAllMealsByUserIdAndDateRequest request)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMeal(UpdateMealRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
