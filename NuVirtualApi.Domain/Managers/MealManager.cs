using NuVirtualApi.Database;
using NuVirtualApi.Database.EntityModels;
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
            User mealUser = _databaseContext.Users.Where(u => u.Id == request.UserId).FirstOrDefault();

            if (mealUser == null)
            {
                return false;
            }

            Meal newMeal = new Meal()
            {
                Name = request.Name,
                Type = request.Type,
                IsFavorite = request.IsFavorite,
                Date = request.Date,
                Carbohydrate = request.Carbohydrate,
                Lipid = request.Lipid,
                Protein = request.Protein,
                Calorie = request.Calorie,
                Notes = request.Notes,
                User = mealUser
            };

            _databaseContext.Meals.Add(newMeal);
            _databaseContext.SaveChanges();

            return true;
        }

        public bool DeleteMeal(int mealId)
        {
            Meal meal = _databaseContext.Meals.Where(m => m.Id == mealId).FirstOrDefault();

            if (meal == null)
            {
                return false;
            }
            _databaseContext.Meals.Remove(meal);
            _databaseContext.SaveChanges();

            return true;
        }

        public List<MealViewModel> GetAllMealsByUserIdAndDate(GetAllMealsByUserIdAndDateRequest request)
        {
            List<Meal> meals = _databaseContext.Meals.Where(m => m.User.Id == request.UserId 
                                                              && m.Date.Day == request.Date.Day 
                                                              && m.Date.Month == request.Date.Month 
                                                              && m.Date.Year == request.Date.Year).ToList();

            List<MealViewModel> mealViewModels = new List<MealViewModel>();

            meals.ForEach(meal =>
            {
                mealViewModels.Add(new MealViewModel()
                {
                    Id = meal.Id,
                    Name = meal.Name,
                    Type = meal.Type,
                    IsFavorite = meal.IsFavorite,
                    Date = meal.Date,
                    Carbohydrate = meal.Carbohydrate,
                    Lipid = meal.Lipid,
                    Protein = meal.Protein,
                    Calorie = meal.Calorie,
                    Notes = meal.Notes,
                    UserId = meal.User.Id
                });
            });

            return mealViewModels;
        }

        public MealViewModel GetMealByMealId(int mealId)
        {
            Meal meal = _databaseContext.Meals.Where(m => m.Id == mealId).FirstOrDefault();

            if (meal != null) {
                return new MealViewModel()
                {
                    Id = meal.Id,
                    Name = meal.Name,
                    Type = meal.Type,
                    IsFavorite = meal.IsFavorite,
                    Date = meal.Date,
                    Carbohydrate = meal.Carbohydrate,
                    Lipid = meal.Lipid,
                    Protein = meal.Protein,
                    Calorie = meal.Calorie,
                    Notes = meal.Notes,
                    UserId = meal.User.Id
                };
            } 

            return null;
        }

        public bool UpdateMeal(UpdateMealRequest request)
        {
            User user = _databaseContext.Users.Where(u => u.Id == request.UserId).FirstOrDefault();
            Meal meal = _databaseContext.Meals.Where(m => m.Id == request.Id).FirstOrDefault();

            if (user == null || meal == null)
            {
                return false;
            }

            meal = new Meal()
            {
                Id = meal.Id,
                Name = request.Name,
                Type = request.Type,
                IsFavorite = request.IsFavorite,
                Date = request.Date,
                Carbohydrate = request.Carbohydrate,
                Lipid = request.Lipid,
                Protein = request.Protein,
                Calorie = request.Calorie,
                Notes = request.Notes,
                User = user
            };

            _databaseContext.Meals.Update(meal);
            _databaseContext.SaveChanges();

            return true;
        }
    }
}
