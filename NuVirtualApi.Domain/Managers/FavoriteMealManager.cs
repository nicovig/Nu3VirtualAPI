using NuVirtualApi.Database;
using NuVirtualApi.Database.EntityModels;
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

        public bool CreateFavoriteMeal(int mealId)
        {
            Meal meal = _databaseContext.Meals.Where(u => u.Id == mealId).FirstOrDefault();
            int userId = meal.User.Id;
            User user = _databaseContext.Users.Where(u => u.Id == userId).FirstOrDefault();

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
                    Meal = meal,
                    User = user
                };

                _databaseContext.FavoriteMeals.Add(newFavoriteMeal);
                _databaseContext.SaveChanges();
            }

            return true;
        }

        public bool DeleteFavoriteMeal(int favoriteMealId)
        {
            FavoriteMeal favoriteMeal = _databaseContext.FavoriteMeals.Where(m => m.Id == favoriteMealId).FirstOrDefault();
            Meal meal = _databaseContext.Meals.Where(m => m.Id == favoriteMeal.Meal.Id).FirstOrDefault();
            User user = _databaseContext.Users.Where(u => u.Id == favoriteMeal.User.Id).FirstOrDefault();

            if (user == null || meal == null)
            {
                return false;
            }

            meal = new Meal()
            {
                Id = meal.Id,
                Name = meal.Name,
                Type = meal.Type,
                IsFavorite = false,
                Date = meal.Date,
                Carbohydrate = meal.Carbohydrate,
                Lipid = meal.Lipid,
                Protein = meal.Protein,
                Calorie = meal.Calorie,
                Notes = meal.Notes,
                User = user
            };
            _databaseContext.ChangeTracker.Clear();
            _databaseContext.Meals.Update(meal);
            _databaseContext.SaveChanges();


            if (favoriteMeal == null)
            {
                return false;
            }

            _databaseContext.FavoriteMeals.Remove(favoriteMeal);
            _databaseContext.SaveChanges();

            return true;
        }

        public List<FavoriteMealViewModel> GetAllFavoriteMealsByUserId(int userId)
        {
            List<FavoriteMeal> favoriteMeals = _databaseContext.FavoriteMeals.Where(m => m.User.Id == userId).ToList();

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
                    MealId = favoriteMeal.Meal.Id,
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
                    MealId = favoriteMeal.Meal.Id,
                    UserId = favoriteMeal.User.Id
                };
            }

            return null;
        }

        public bool UpdateFavoriteMeal(UpdateFavoriteMealRequest request)
        {
            User user = _databaseContext.Users.Where(u => u.Id == request.UserId).FirstOrDefault();
            Meal meal = _databaseContext.Meals.Where(u => u.Id == request.MealId).FirstOrDefault();
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
                Meal = meal,
                User = user
            };
            _databaseContext.ChangeTracker.Clear();
            _databaseContext.FavoriteMeals.Update(favoriteMeal);
            _databaseContext.SaveChanges();

            return true;
        }

        public bool UpdateFavoriteMealByMealId(int mealId) //si encore favoris ou pas (se baser sur meal)
        {
            Meal meal = _databaseContext.Meals.Where(u => u.Id == mealId).FirstOrDefault();
            User user = _databaseContext.Users.Where(u => u.Id == meal.User.Id).FirstOrDefault();

            if (user == null || meal == null)
            {
                return false;
            }

            try
            {
                FavoriteMeal favoriteMeal = _databaseContext.FavoriteMeals.Where(m => m.Meal.Id == meal.Id).FirstOrDefault();

                if (meal.IsFavorite && favoriteMeal != null)
                {
                    return true;
                }

                if (!meal.IsFavorite && favoriteMeal != null)
                {
                    _databaseContext.FavoriteMeals.Remove(favoriteMeal);
                    _databaseContext.SaveChanges();

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
