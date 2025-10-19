using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entity
{
    internal class Plan:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int DurationDays { get; set; }
        public bool IsActive { get; set; }

        #region relationships
        #region Plan - Membership (M : M)

        public ICollection<MemberShip> MemberShips { get; set; }

        #endregion
        #endregion
    }
}
