using NuVirtualApi.Database;
using NuVirtualApi.Database.EntityModels;
using NuVirtualApi.Database.Enums;
using NuVirtualApi.Domain.Interfaces.Manager;
using NuVirtualApi.Domain.Models.Request.FavoriteMeal;
using NuVirtualApi.Domain.Models.Response.FavoriteMeal;

namespace NuVirtualApi.Domain.Managers
{
    public class FavoriteMealManager : IFavoriteMealManager
    {
        private readonly DatabaseContext _databaseContext;

        public FavoriteMealManager(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public bool AddFavoriteMealToDailyMeals(AddFavoriteMealToDailyMealsRequest request)
        {
            FavoriteMeal favoriteMeal = _databaseContext.FavoriteMeals.Where(m => m.Id == request.FavoriteMealId).FirstOrDefault();

            User mealUser = _databaseContext.Users.Where(u => u.Id == request.UserId).FirstOrDefault();

            if (mealUser == null)
            {
                return false;
            }

            Meal newMeal = new Meal()
            {
                Name = favoriteMeal.Name,
                Type = favoriteMeal.Type,
                IsFavorite = true,
                Date = request.Date,
                Carbohydrate = favoriteMeal.Carbohydrate,
                Lipid = favoriteMeal.Lipid,
                Protein = favoriteMeal.Protein,
                Calorie = favoriteMeal.Calorie,
                Notes = "",
                User = mealUser
            };

            _databaseContext.Meals.Add(newMeal);
            int result = _databaseContext.SaveChanges();

            return result == 1 ? true : false;
        }

        public bool CreateFavoriteMeal(int mealId, int userId)
        {
            Meal meal = _databaseContext.Meals.Where(u => u.Id == mealId).FirstOrDefault();

            if (userId == null)
            {
                return false;
            }

            if (meal.IsFavorite)
            {
                FavoriteMeal newFavoriteMeal = new FavoriteMeal()
                {
                    Name = meal.Name,
                    Type = meal.Type,
                    Carbohydrate = meal.Carbohydrate,
                    Lipid = meal.Lipid,
                    Protein = meal.Protein,
                    Calorie = meal.Calorie,
                    SourceMealId = mealId,
                    UserId = userId
                };

                _databaseContext.FavoriteMeals.Add(newFavoriteMeal);
                _databaseContext.SaveChanges();
            }

            return true;
        }

        public int DeleteFavoriteMeal(int favoriteMealId)
        {
            FavoriteMeal favoriteMeal = _databaseContext.FavoriteMeals.Where(m => m.Id == favoriteMealId).FirstOrDefault();
            Meal meal = _databaseContext.Meals.Where(m => m.Id == favoriteMeal.SourceMealId).FirstOrDefault();
            User user = _databaseContext.Users.Where(u => u.Id == favoriteMeal.UserId).FirstOrDefault();

            if (user == null || meal == null)
            {
                return 0;
            }

            if (favoriteMeal == null)
            {
                return 0;
            }

            _databaseContext.FavoriteMeals.Remove(favoriteMeal);
            _databaseContext.SaveChanges();

            return meal.Id;       
        }

        public List<FavoriteMealViewModel> GetAllFavoriteMealsByUserId(int userId)
        {
            List<FavoriteMeal> favoriteMeals = _databaseContext.FavoriteMeals.Where(m => m.UserId == userId).ToList();

            List<FavoriteMealViewModel> favoriteMealViewModels = new List<FavoriteMealViewModel>();

            favoriteMeals.ForEach(favoriteMeal =>
            {
                favoriteMealViewModels.Add(new FavoriteMealViewModel()
                {
                    Id = favoriteMeal.Id,
                    Name = favoriteMeal.Name,
                    Type = favoriteMeal.Type,
                    Carbohydrate = favoriteMeal.Carbohydrate,
                    Lipid = favoriteMeal.Lipid,
                    Protein = favoriteMeal.Protein,
                    Calorie = favoriteMeal.Calorie,
                    MealId = favoriteMeal.SourceMealId,
                    UserId = userId
                });
            });

            return favoriteMealViewModels;
        }

        public FavoriteMealViewModel GetFavoriteMealById(int favoriteMealId)
        {
            FavoriteMeal favoriteMeal = _databaseContext.FavoriteMeals.Where(m => m.Id == favoriteMealId).FirstOrDefault();

            if (favoriteMeal != null)
            {
                return new FavoriteMealViewModel()
                {
                    Id = favoriteMeal.Id,
                    Name = favoriteMeal.Name,
                    Type = favoriteMeal.Type,
                    Carbohydrate = favoriteMeal.Carbohydrate,
                    Lipid = favoriteMeal.Lipid,
                    Protein = favoriteMeal.Protein,
                    Calorie = favoriteMeal.Calorie,
                    MealId = favoriteMeal.SourceMealId,
                    UserId = favoriteMeal.UserId
                };
            }

            return null;
        }

        public bool UpdateFavoriteMeal(UpdateFavoriteMealRequest request)
        {
            User user = _databaseContext.Users.Where(u => u.Id == request.UserId).FirstOrDefault();
            FavoriteMeal favoriteMeal = _databaseContext.FavoriteMeals.Where(m => m.Id == request.Id).FirstOrDefault();

            if (user == null || favoriteMeal == null)
            {
                return false;
            }

            favoriteMeal = new FavoriteMeal()
            {
                Id = favoriteMeal.Id,
                Name = request.Name,
                Type = request.Type,
                Carbohydrate = request.Carbohydrate,
                Lipid = request.Lipid,
                Protein = request.Protein,
                Calorie = request.Calorie,
                SourceMealId = request.MealId,
                UserId = user.Id
            };
            _databaseContext.ChangeTracker.Clear();
            _databaseContext.FavoriteMeals.Update(favoriteMeal);
            _databaseContext.SaveChanges();

            return true;
        }

        public bool UpdateFavoriteMealByMealId(int mealId, int userId) //si encore favoris ou pas (se baser sur meal)
        {
            Meal meal = _databaseContext.Meals.Where(u => u.Id == mealId).FirstOrDefault();

            if (meal == null)
            {
                return false;
            }

            try
            {
                FavoriteMeal favoriteMeal = _databaseContext.FavoriteMeals.Where(m => m.SourceMealId == meal.Id).FirstOrDefault();

                if (meal.IsFavorite && favoriteMeal != null)
                {
                    return true;
                }

                if (meal.IsFavorite && favoriteMeal == null)
                {                    
                    return CreateFavoriteMeal(mealId, userId);
                }

                if (!meal.IsFavorite && favoriteMeal != null)
                {
                    _databaseContext.FavoriteMeals.Remove(favoriteMeal);
                    _databaseContext.SaveChanges();

                    return true;
                }

                if (!meal.IsFavorite && favoriteMeal == null)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return true;
            }            

            return true;
        }
    }
}
