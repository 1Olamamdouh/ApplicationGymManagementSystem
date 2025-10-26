using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entity
{
    public class Category: BaseEntity
    {
        public string CategoryName { get; set; }


        #region relationships

        #region Category - Session (1 : M)
        public ICollection<Session> Sessions { get; set; }
        #endregion

        #endregion

    }
}
