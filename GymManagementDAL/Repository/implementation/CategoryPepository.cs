using GymManagementDAL.Data.Context;
using GymManagementDAL.Entity;
using GymManagementDAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repository.implementation
{
    internal class CategoryPepository : ICategoryRepository
    {
        private readonly GymDbContext _dbContext;

        //private readonly GymDbContext _dbContext = new GymDbContext();

        public CategoryPepository(GymDbContext dbContext) {
            _dbContext = dbContext;
        }


        public int AddCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            return _dbContext.SaveChanges();
        }

        public int DeleteCategory(int id)
        {
            _dbContext.Categories.Remove(GetCategoryById(id));
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAllGatergrey() => _dbContext.Categories.ToList();

        public Category? GetCategoryById(int id) => _dbContext.Categories.Find();

     public int UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            return _dbContext.SaveChanges();
        }


    }
}
