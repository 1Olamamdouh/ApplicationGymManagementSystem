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
    internal class PlanRepository : IPlanRepository
    {
        private readonly GymDbContext _dbContext;

        //private readonly GymDbContext _dbContext = new GymDbContext();

        public PlanRepository(GymDbContext dbContext) {
            _dbContext = dbContext;
        }
        public int AddPlan(Plan plan)
        {
            _dbContext.Plans.Add(plan);
            return _dbContext.SaveChanges();
        }

     public int DeletePlan(int id)
        {
            _dbContext.Plans.Remove(GetPlanById(id)!);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Plan> GetAllPlans() => _dbContext.Plans.ToList();
        public Plan? GetPlanById(int id) => _dbContext.Plans.Find(id);


        public int UpdatePlan(Plan plan)
        {
            _dbContext.Plans.Update(plan);
            return _dbContext.SaveChanges();
        }   
    }
}
