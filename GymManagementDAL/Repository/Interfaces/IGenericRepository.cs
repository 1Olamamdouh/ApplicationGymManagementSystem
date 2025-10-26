using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, new()
    {
         TEntity? GetById(int id); 
         IEnumerable<TEntity> GetAll(); //collection for any class
         int Add(TEntity entity);
         int Update(TEntity entity);
         int Delete(TEntity entity);



    }
}
