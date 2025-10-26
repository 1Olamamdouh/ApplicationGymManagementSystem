using GymManagementDAL.Data.Context;
using GymManagementDAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repository.implementation
{
    public class GenericImplementation<TEntity> : IGenericRepository<TEntity> where TEntity : class, new()
    {
        private readonly GymDbContext _dbContext;

        public GenericImplementation(GymDbContext dbContext) {
            _dbContext = dbContext;
        }

        public int Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> GetAll() => _dbContext.Set<TEntity>().ToList();

        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find();

        public int Update(TEntity entity)
        {
          _dbContext.Set<TEntity>().Update(entity);
            return _dbContext.SaveChanges();
        }   
    }
}
