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
    internal class TrainerRepository : ITrainerRepository
    {
        private readonly GymDbContext _dbContext;

        //private readonly GymDbContext _dbContext = new GymDbContext();

        public TrainerRepository(GymDbContext dbContext) {
            _dbContext = dbContext;
        }

        public int AddTrainer(Trainer trainer)
        {  
            _dbContext.Trainers.Add(trainer);
            return _dbContext.SaveChanges();
        }

        public int DeleteTrainer(int trainerId)
        {
            _dbContext.Trainers.Remove(GetTrainerById(trainerId)!);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Trainer> GetAllTrainers() => _dbContext.Trainers.ToList();

        public Trainer? GetTrainerById(int trainerId) => _dbContext.Trainers.Find(trainerId);

        public int UpdateTrainer(Trainer trainer)
        {
            _dbContext.Trainers.Update(trainer);
            return _dbContext.SaveChanges();

        }
    }
}
