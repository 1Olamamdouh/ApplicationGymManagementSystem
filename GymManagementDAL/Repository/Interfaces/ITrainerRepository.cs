using GymManagementDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repository.Interfaces
{
    internal interface ITrainerRepository
    {
        // Define method signatures for trainer repository operations
        //GetAll Trainers (Collection)
        IEnumerable<Trainer> GetAllTrainers();
        //GetById Trainer 
        Trainer? GetTrainerById(int trainerId);
        //Add Trainer
        int AddTrainer(Trainer trainer);
        //Update Trainer
        int UpdateTrainer(Trainer trainer);
        //Delete Trainer
        int DeleteTrainer(int trainerId);
    }
}
