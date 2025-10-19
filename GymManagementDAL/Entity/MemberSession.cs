using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Entity
{
    internal class MemberSession:BaseEntity
    {

        public int MemberId { get; set; } // Foreign key to Member
        public Member member { get; set; }
        public int SessionId { get; set; } // Foreign key to Session
        public Session Session { get; set; }
        public bool IsAttended { get; set; } // To track attendance
    }
}
