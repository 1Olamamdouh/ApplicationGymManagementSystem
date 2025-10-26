using GymManagementDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagementDAL.Repository.Interfaces
{
    internal interface IMemberRepository
    {
        // Define method signatures for member repository operations
        //GetAll Members (Collection)
        IEnumerable<Member> GetAllMembers();
        //GetById Member 
        Member? GetMemberById(int memberId);
        //Add Member
        int AddMember(Member member);
        //Update Member
        int UpdateMember(Member member);
        //Delete Member
        int DeleteMember(int memberId);




    }
}
