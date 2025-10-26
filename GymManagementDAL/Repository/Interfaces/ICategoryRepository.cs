using GymManagementDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repository.Interfaces
{
    internal interface ICategoryRepository
    {
        // Interface methods for CategoryRepository
        //  CRUD operations
        //GetAll, GetById, Add, Update, Delete
        //________________________________________________________//
        //GetAllCatergory
        IEnumerable<Category?> GetAllGatergrey();
        //GetCatergoryById
        Category? GetCategoryById(int id);
        //AddCatergory
        int AddCategory(Category category);
        //UpdateCatergory
        int UpdateCategory(Category category);
        //DeleteCatergory
        int DeleteCategory(int id);


    }
}
 