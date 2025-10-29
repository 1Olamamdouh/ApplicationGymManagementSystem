using GymManagementDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repository.Interfaces
{
    public interface IPlanRepository
    {
        // Interface methods for PlanRepository
        //  CRUD operations
        //GetAll, GetById, Add, Update, Delete
        //________________________________________________________//
        //GetAllPlans
        IEnumerable<Plan> GetAllPlans();
        //GetPlanById
        Plan? GetPlanById(int id);
        //AddPlan
        int AddPlan(Plan plan);
        //UpdatePlan
        int UpdatePlan(Plan plan);
        //DeletePlan
        int DeletePlan(int id);


    }
}
