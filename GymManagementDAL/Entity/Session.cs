using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entity
{
    internal class Session : BaseEntity
    {
        public string Description { get; set; }
        public int Capacity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        #region Relationships

        #region Session - Category (M : 1)
        public int CategoryId { get; set; } // Foreign Key
        public Category Category { get; set; }
        #endregion

        #region Session - Trainer (M : 1)
        public int TrainerId { get; set; } // Foreign Key
        public Trainer Trainer { get; set; }
        #endregion

        #region Session - Member (M : M)
        //public ICollection<MemberShip> MemberShips { get; set; }
        #endregion

        #endregion
    }
}
