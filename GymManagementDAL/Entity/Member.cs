using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entity
{
    internal class Member : GymUser
    {
        //JoinDate==CreatedAt

        public string? phone { get; set; }



        #region All RelationShips

        #region Member - HealthRecord(1:1)
        public HealthRecord HealthRecord { get; set; }
        #endregion

        #region Memder - Membership(Plan) (M : M)

        public ICollection<MemberShip> MemberShips { get; set; }
        #endregion

        #region Member - Session (M : M)
        public ICollection<MemberSession> MemberSessions { get; set; }

        #endregion


        #endregion
    }
}
