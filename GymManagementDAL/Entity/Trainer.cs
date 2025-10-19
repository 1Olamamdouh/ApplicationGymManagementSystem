using GymManagementDAL.Entity.Enums;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entity
{
    internal class Trainer:GymUser
    {
        
        //HireDate==CreateAt
        public Specialities Specialities { get; set; }


        #region Relationships
        #region trainer - Session (1 : M) 

        public ICollection<Session> Sessions { get; set; }

        #endregion

        #endregion

    }
}
